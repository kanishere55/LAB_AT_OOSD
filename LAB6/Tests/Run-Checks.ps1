param([string]$Instance='.\MSSQLSERVER01')
$ErrorActionPreference='Stop'
$labRoot=Split-Path $PSScriptRoot -Parent
$buildTool='C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe'
$compiler='C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\Roslyn\csc.exe'
if(!(Test-Path -LiteralPath $buildTool)){throw 'Can Visual Studio 2022 voi workload .NET desktop development.'}
$outDir=Join-Path $PSScriptRoot 'bin'
New-Item -ItemType Directory -Path $outDir -Force | Out-Null
$sqlText=[IO.File]::ReadAllText((Join-Path $labRoot 'Database\QuanLyHoSoBenhAn.sql')).Replace('QuanLyHoSoBenhAn','QuanLyHoSoBenhAn_Test')
$testSql=Join-Path $outDir 'CreateTestDatabase.sql'
[IO.File]::WriteAllText($testSql,$sqlText,[Text.UTF8Encoding]::new($true))
& sqlcmd -S $Instance -E -f 65001 -b -i $testSql
if($LASTEXITCODE -ne 0){throw 'Tao CSDL test that bai.'}
& $buildTool (Join-Path $labRoot 'QuanLyHoSoBenhAn\QuanLyHoSoBenhAn.sln') /p:Configuration=Release /nologo /v:minimal
if($LASTEXITCODE -ne 0){throw 'Build that bai.'}
$appDir=Join-Path $labRoot 'QuanLyHoSoBenhAn\QuanLyHoSoBenhAn\bin\Release'
Copy-Item -LiteralPath (Join-Path $appDir 'QuanLyHoSoBenhAn.exe') -Destination $outDir
Copy-Item -LiteralPath (Join-Path $appDir 'QuanLyHoSoBenhAn.exe.config') -Destination (Join-Path $outDir 'BusinessChecks.exe.config')
& $compiler /nologo /target:exe "/out:$outDir\BusinessChecks.exe" "/reference:$outDir\QuanLyHoSoBenhAn.exe" /reference:System.Data.dll /reference:System.Configuration.dll (Join-Path $PSScriptRoot 'BusinessChecks.cs')
if($LASTEXITCODE -ne 0){throw 'Bien dich kiem thu that bai.'}
& (Join-Path $outDir 'BusinessChecks.exe') (Join-Path $PSScriptRoot 'BusinessResults.csv') $Instance
if($LASTEXITCODE -ne 0){throw 'Co kiem thu that bai. Xem BusinessResults.csv.'}
Copy-Item -LiteralPath (Join-Path $appDir 'QuanLyHoSoBenhAn.exe.config') -Destination (Join-Path $outDir 'UiWorkflowChecks.exe.config')
& $compiler /nologo /target:exe "/out:$outDir\UiWorkflowChecks.exe" "/reference:$outDir\QuanLyHoSoBenhAn.exe" /reference:System.Data.dll /reference:System.Windows.Forms.dll /reference:System.Drawing.dll (Join-Path $PSScriptRoot 'UiWorkflowChecks.cs')
if($LASTEXITCODE -ne 0){throw 'Bien dich kiem thu luong Form that bai.'}
& (Join-Path $outDir 'UiWorkflowChecks.exe') (Join-Path $PSScriptRoot 'UiWorkflowResults.csv') $Instance
if($LASTEXITCODE -ne 0){throw 'Co kiem thu luong Form that bai.'}
