<#
.SYNOPSIS
Find and process files in a project folder that are not included in the project. 

.DESCRIPTION
Find and process files in a project folder that are not included in the project. 
Options to delete the files. 

.PARAMETER Project
The path/name for the project file. 

.PARAMETER DeleteFromDisk
Just delete the files from disk. No interaction with any source control.

#>

[CmdletBinding()]
param(
    [Parameter(Position=0, Mandatory=$true)]
    [string]$Project,  
    [switch]$DeleteFromDisk
)

$projectPath = Split-Path $project

$projectPath

$excludeRegex = "\\obj\\|\\bin\\|\\logs\\|\.user|\.csproj|App_Configuration\\"
$fullProjectPath = (Resolve-Path $projectPath).Path

$fullProjectPath

$compileFiles = Select-String -Path $project -Pattern '<compile'  | % { $_.Line -split '\t' } | `
     % {$_ -replace "(<Compile Include=|\s|/>|["">])", ""} | % { "{0}\{1}" -f $projectPath, $_ } | % {(Resolve-Path $_).Path}

$noneFiles = Select-String -Path $project -Pattern '<none'  | % { $_.Line -split '\t' } | `
     % {$_ -replace "(<None Include=|\s|/>|["">])", ""} | % { "{0}\{1}" -f $projectPath, $_ } | % {(Resolve-Path $_).Path}

$contentFiles = Select-String -Path $project -Pattern '<content'  | % { $_.Line -split '\t' } | `
     % {$_ -replace "(<Content Include=|\s|/>|["">])", ""} | % { "{0}\{1}" -f $projectPath, $_ } | % {(Resolve-Path $_).Path}

$embedded = Select-String -Path $project -Pattern '<embeddedresource'  | % { $_.Line -split '\t' } | `
     % {$_ -replace "(<EmbeddedResource Include=|\s|/>|["">])", ""} | % { "{0}\{1}" -f $projectPath, $_ } | % {(Resolve-Path $_).Path}

$projectFiles = ($compileFiles + $noneFiles + $contentFiles + $embedded) | ?{ $_ -like "$fullProjectPath*" }
Write-Host "Project:" $projectFiles.Count

#$projectFiles | %{ $_ }

$diskFiles = gci -Path $path -Recurse | ?{ if($_.Extension) { $_ } else {} } | %{ $_.FullName } | ?{ $_ -notmatch $excludeRegex }
Write-Host "Disk files:" $diskFiles.Count

#$diskFiles | %{ $_ }

$diff = (compare-object $diskFiles $projectFiles  -PassThru) 
Write-Host "Excluded Files:" $diff.Count

$diff | %{ $_ }

#just remove the files from disk
if($DeleteFileOnly)
{
    $diff | % { Remove-Item -Path $_ -Force -Verbose}
}