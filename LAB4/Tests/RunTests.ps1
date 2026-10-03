$ErrorActionPreference = 'Stop'
$lab4Folder = Split-Path -Parent $PSScriptRoot
$applicationFolder = Join-Path $lab4Folder 'QuanLyCuaHangOnline\QuanLyCuaHangOnline'
$applicationExe = Join-Path $applicationFolder 'bin\Release\QuanLyCuaHangOnline.exe'
if (-not (Test-Path -LiteralPath $applicationExe)) {
    throw 'Build project voi cau hinh Release truoc khi chay kiem thu.'
}
Copy-Item -LiteralPath $applicationExe -Destination $PSScriptRoot -Force
Copy-Item -LiteralPath (Join-Path $applicationFolder 'App.config') -Destination (Join-Path $PSScriptRoot 'Tests.exe.config') -Force
$compiler = Join-Path $env:WINDIR 'Microsoft.NET\Framework64\v4.0.30319\csc.exe'
& $compiler /nologo /target:exe ('/out:' + (Join-Path $PSScriptRoot 'Tests.exe')) ('/reference:' + (Join-Path $PSScriptRoot 'QuanLyCuaHangOnline.exe')) /reference:System.Data.dll /reference:System.Configuration.dll (Join-Path $PSScriptRoot 'Tests.cs')
if ($LASTEXITCODE -ne 0) { throw 'Khong bien dich duoc chuong trinh kiem thu.' }
& (Join-Path $PSScriptRoot 'Tests.exe') | Tee-Object -FilePath (Join-Path $PSScriptRoot 'TestResults.txt')
if ($LASTEXITCODE -ne 0) { throw 'Co truong hop kiem thu khong dat.' }
