REM I wrote this because the LODS VM image is soooooo out of date. It adds a few modern bits. 
cd C:\Users\Admin\Desktop\MarksFiles\Setups

REM Create Scheduled Task to register Git cred manager on re-boot
@"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -file "./GitCredManager.ps1"

REM Rearm MS Office
cmd /C "C:\Program Files\Microsoft Office\Office16\OSPPREARM.EXE"

REM add powershell menu to explorer
reg import "Add PowerShell to Context Menu.reg"

REM Copy desktop links
cmd /C copy "C:\Users\Admin\Desktop\MarksFiles\Setups\MarksCode - Shortcut.lnk" "C:\Users\Admin\Desktop"
cmd /C copy "C:\Users\Admin\Desktop\MarksFiles\Setups\Refresh Marks Code.lnk" "C:\Users\Admin\Desktop"


REM Install Chocolatey
@"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command "[System.Net.ServicePointManager]::SecurityProtocol = 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"


reg import "C:\Users\Admin\Desktop\MarksFiles\Setups\Add PowerShell to Context Menu.reg"

choco install git.install /WindowsTerminal -y
choco install googlechrome -y --ignore-checksums
choco install setdefaultbrowser -y
cmd /C "setdefaultbrowser chrome"

REM install octotree & JSON Formatter on chrome
reg add HKLM\SOFTWARE\Policies\Google\Chrome\ExtensionInstallForcelist /v 1 /t REG_SZ /d bkhaagjahfmjljalopjnoealnfndnagc /f
reg add HKLM\SOFTWARE\Policies\Google\Chrome\ExtensionInstallForcelist /v 1 /t REG_SZ /d bcjindcccaagfpapjjmafapmmgkkhgoa /f


git config --global user.name "Student@DDLS"
git config --global user.email "Student@DDLS"
git config --global core.autocrlf false


choco install dotnet-6.0-sdk -y
choco install dotnetfx -Y
choco install netfx-4.7.2 -Y

cmd /C "code --install-extension ms-dotnettools.csharp --force"
cmd /C "code --install-extension ms-dotnettools.vscode-dotnet-runtime --force"
cmd /C "code --install-extension eamodio.gitlens --force"
cmd /C "code --install-extension donjayamanne.githistory --force"


choco install notepadplusplus -y
choco install fiddler -y
choco install postman -y
choco install nuget.commandline -y
choco install docker-desktop -y
choco install visualstudio2022community -y

REM I found trying to install Edge Chromium using Chocolatey was problematic. Giving Google Chrome a go.
REM Download Edge Chromium (the versions can be found at https://edgeupdates.microsoft.com/api/products?view=enterprise...I used postman to get the JSON
REM @"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command "$response = Invoke-WebRequest -Uri 'REM https://msedge.sf.dl.delivery.mp.microsoft.com/filestreamingservice/files/71c25d04-9596-4481-90c5-a1070a31c64b/MicrosoftEdgeEnterpriseX64.msi -outfile .\\MicrosoftEdgeEnterpriseX64.msi' -Method Get"



REM Remove out-of-date content, add most recent content
rmdir c:\20483-Programming-in-C-Sharp-master /S /Q
rmdir c:\Instructions /S /Q
rmdir c:\Temp /S /Q
mkdir c:\Temp
del c:\Users\Admin\Downloads\20483-Programming-in-C-Sharp-Master.zip
git clone https://github.com/Mark-AIICT/MS20483.git C:\Users\Admin\Desktop\LabFiles

REM Remove MS Edge from the TaskBar
@"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -file "./TaskBar.Ps1"

REM Install Adventureworks
@"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -file "./InstallAdventureworks.Ps1"



echo "The lab computer needs to restart to install changes"

cmd /C shutdown -r -f -T 3

