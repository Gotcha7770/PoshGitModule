# PoshGitModule
Learn to write powershell Modules in F#

http://webcoder.info/fspsmodule.html

https://docs.microsoft.com/en-us/powershell/scripting/dev-cross-plat/create-standard-library-binary-module?view=powershell-7.1

## PowerShell 7 CheatSheet

To view the Help topic for this cmdlet online:

```powershell
Get-Help $Cmdlet -Online
```
To get PShell version:
```powershell
Get-Host | Select-Object Version
```
To get current supported CLR version:
```powershell
[Environment]::Version
```

To get all installed from repository modules:
```powershell
Get-InstalledModule
```

To get all available modules:
```powershell
Get-Module -ListAvailable
```
