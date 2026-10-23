$ErrorActionPreference='Stop'
$labRoot=Split-Path $PSScriptRoot -Parent
$outDir=Join-Path $PSScriptRoot 'bin'
New-Item -ItemType Directory -Path $outDir -Force | Out-Null
$appDir=Join-Path $labRoot 'QuanLyHoSoBenhAn\QuanLyHoSoBenhAn\bin\Release'
Copy-Item -LiteralPath (Join-Path $appDir 'QuanLyHoSoBenhAn.exe') -Destination $outDir
Copy-Item -LiteralPath (Join-Path $appDir 'QuanLyHoSoBenhAn.exe.config') -Destination (Join-Path $outDir 'FormChecks.exe.config')
$compiler='C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\Roslyn\csc.exe'
& $compiler /nologo /target:exe "/out:$outDir\FormChecks.exe" "/reference:$outDir\QuanLyHoSoBenhAn.exe" /reference:System.Windows.Forms.dll /reference:System.Drawing.dll /reference:System.Data.dll (Join-Path $PSScriptRoot 'FormChecks.cs')
if($LASTEXITCODE -ne 0){throw 'Bien dich FormChecks that bai.'}
& (Join-Path $outDir 'FormChecks.exe') (Join-Path $labRoot 'Evidence')
if($LASTEXITCODE -ne 0){throw 'Co kiem tra giao dien that bai. Xem Evidence\FormResults.csv.'}
Copy-Item -LiteralPath (Join-Path $appDir 'QuanLyHoSoBenhAn.exe.config') -Destination (Join-Path $outDir 'DatabaseEvidence.exe.config')
& $compiler /nologo /target:exe "/out:$outDir\DatabaseEvidence.exe" "/reference:$outDir\QuanLyHoSoBenhAn.exe" /reference:System.Data.dll /reference:System.Windows.Forms.dll /reference:System.Drawing.dll (Join-Path $PSScriptRoot 'DatabaseEvidence.cs')
if($LASTEXITCODE -ne 0){throw 'Bien dich kiem tra CSDL that bai.'}
& (Join-Path $outDir 'DatabaseEvidence.exe') (Join-Path $labRoot 'Evidence')
if($LASTEXITCODE -ne 0){throw 'Doi chieu CSDL that bai.'}
