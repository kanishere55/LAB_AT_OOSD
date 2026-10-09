param([string]$Server='.\MSSQLSERVER01')
$ErrorActionPreference='Stop'
$lab5Root=Split-Path -Parent $PSScriptRoot
$projectPath=Join-Path $lab5Root 'QuanLyCongTyDuLich\QuanLyCongTyDuLich'
$binary=Join-Path $projectPath 'bin\Release\QuanLyCongTyDuLich.exe'
if (-not (Test-Path -LiteralPath $binary)) { throw 'Build Release trước khi kiểm thử.' }
$testDb='Lab5_Test_'+[Guid]::NewGuid().ToString('N')
$scratch=Join-Path $env:TEMP $testDb
New-Item -ItemType Directory -Path $scratch | Out-Null
$testExe=Join-Path $scratch 'Tests.exe'
Copy-Item -LiteralPath $binary -Destination $scratch
$sql=Get-Content -LiteralPath (Join-Path $lab5Root 'Database\QuanLyCongTyDuLich.sql') -Raw -Encoding UTF8
$sql.Replace('QuanLyCongTyDuLich',$testDb) | Set-Content -LiteralPath (Join-Path $scratch 'Seed.sql') -Encoding UTF8
[xml]$cfg=Get-Content -LiteralPath (Join-Path $projectPath 'App.config') -Raw
$builder=New-Object System.Data.SqlClient.SqlConnectionStringBuilder
$builder['Data Source']=$Server; $builder['Initial Catalog']=$testDb; $builder['Integrated Security']=$true
$cfg.configuration.connectionStrings.add.connectionString=$builder.ConnectionString
$cfg.Save($testExe+'.config')
$compiler=Join-Path $env:WINDIR 'Microsoft.NET\Framework64\v4.0.30319\csc.exe'
& $compiler /nologo /target:exe ('/out:'+$testExe) ('/reference:'+(Join-Path $scratch 'QuanLyCongTyDuLich.exe')) /reference:System.Data.dll /reference:System.Configuration.dll /reference:System.Drawing.dll /reference:System.Windows.Forms.dll (Join-Path $PSScriptRoot 'Tests.cs')
if ($LASTEXITCODE -ne 0) { throw 'Không biên dịch được Tests.cs' }
$exitCode=0
try {
    & sqlcmd -S $Server -E -f 65001 -b -i (Join-Path $scratch 'Seed.sql') | Out-Null
    if ($LASTEXITCODE -ne 0) { throw 'Không tạo được CSDL kiểm thử.' }
    & $testExe forms (Join-Path $lab5Root 'Evidence') | Tee-Object -FilePath (Join-Path $PSScriptRoot 'FormResults.txt')
    if ($LASTEXITCODE -ne 0) { $exitCode=1 }
    & $testExe | Tee-Object -FilePath (Join-Path $PSScriptRoot 'TestResults.txt')
    if ($LASTEXITCODE -ne 0) { $exitCode=1 }
} finally {
    # Chỉ xóa database thử do chính lần chạy này vừa tạo, tên được sinh từ GUID.
    if ($testDb -notmatch '^Lab5_Test_[a-f0-9]{32}$') { throw 'Tên CSDL kiểm thử không hợp lệ.' }
    & sqlcmd -S $Server -E -b -Q "IF DB_ID(N'$testDb') IS NOT NULL BEGIN ALTER DATABASE [$testDb] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [$testDb]; END" | Out-Null
}
if ($exitCode -ne 0) { throw 'Có ca kiểm thử không đạt; xem TestResults.txt và FormResults.txt.' }
