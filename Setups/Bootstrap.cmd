REM I wrote this because the LODS VM image is soooooo out of date. It adds a few modern bits. I found trying to install Edge Chromium using Chocolatey was 
REM problematic. Giving Goolge Chrome a go.

REM add powershell menu to explorer
reg import "Add PowerShell to Context Menu.reg"

REM Install Chocolatey
@"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command "[System.Net.ServicePointManager]::SecurityProtocol = 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"


reg import "C:\Users\Admin\Desktop\MarksFiles\Setups\Add PowerShell to Context Menu.reg"

choco install git.install /WindowsTerminal -y
choco install googlechrome -y



git config --global user.name "Student@DDLS"
git config --global user.email "Student@DDLS"
git config --global core.autocrlf false

choco install dotnet-6.0-sdk -y
choco install dotnetfx -Y
choco install netfx-4.7.2 -Y


choco install notepadplusplus -y

REM Download Edge Chromium (the versions can be found at https://edgeupdates.microsoft.com/api/products?view=enterprise...I used postman to get the JSON
REM @"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command "$response = Invoke-WebRequest -Uri 'REM https://msedge.sf.dl.delivery.mp.microsoft.com/filestreamingservice/files/71c25d04-9596-4481-90c5-a1070a31c64b/MicrosoftEdgeEnterpriseX64.msi -outfile .\\MicrosoftEdgeEnterpriseX64.msi' -Method Get"



REM Remove out-of-date content, add most recent content
rmdir c:\20483-Programming-in-C-Sharp-master /S /Q
rmdir c:\Instructions /S /Q
rmdir c:\Temp /S /Q
del c:\Users\Admin\Downloads\20483-Programming-in-C-Sharp-Master.zip
git clone https://github.com/MicrosoftLearning/20483-Programming-in-C-Sharp C:\Users\Admin\Desktop\LabFiles


