namespace PoshGitModule

open System.Management.Automation
open RegularExpressions

[<Cmdlet("Clear", "Branches")>]
type ClearBranchesCommand() =
    inherit Cmdlet()

    let executeGit args =
        let script = ScriptBlock.Create($"git {args}")
        script.Invoke()
    
    let expr = ": gone]" //branch is gone from origin marker
    
    let removeBranch name =
        executeGit $"branch -d {name}" |> ignore
        
    let processItems items =
        Seq.filter (isMatch expr) items
        |> Seq.map (fun x -> x.Trim().Split(" ").[0])
        |> Seq.iter (removeBranch)
    
    override x.EndProcessing() =
        //TODO: check for git repository
        x.WriteObject("Starting to cleanup...")
        
        //TODO: error code
        let result = executeGit "branch -vv"
            
        let items = seq { for x in result -> x.ToString() }
        processItems items
            
        x.WriteObject("Job done!")
        base.EndProcessing()
