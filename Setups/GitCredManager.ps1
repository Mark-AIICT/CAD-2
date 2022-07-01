$Action = New-ScheduledTaskAction -Execute 'cmd' -Argument '/C git credential-manager-core configure' 
$Trigger = New-ScheduledTaskTrigger -AtStartup
$Settings = New-ScheduledTaskSettingsSet
$Task = New-ScheduledTask -Action $Action -Trigger $Trigger -Settings $Settings
$principal=new-scheduledtaskprincipal -userid 'NT AUTHORITY\SYSTEM' -runLevel highest -LogonType ServiceAccount 
Register-ScheduledTask RegGitCredMgr -Action $Action -trigger $Trigger -Principal $principal 