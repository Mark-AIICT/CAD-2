$Action = New-ScheduledTaskAction -Execute 'cmd' -Argument '/C git credential-manager-core configure' 
$Trigger = New-ScheduledTaskTrigger -AtLogOn
$Settings = New-ScheduledTaskSettingsSet
$Task = New-ScheduledTask -Action $Action -Trigger $Trigger -Settings $Settings
$principal=new-scheduledtaskprincipal -userid 'Student\Admin' -runLevel highest 
Register-ScheduledTask RegGitCredMgr -Action $Action -trigger $Trigger -Principal $principal 