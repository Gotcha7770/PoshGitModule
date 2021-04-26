namespace PoshGitModule

open System.Management.Automation
open ExecuteProcess
open RegularExpressions

[<Cmdlet("Clear", "Branches")>]
type ClearBranchesCommand() =
    inherit Cmdlet()

    let executeGit args = executeProcess ("git", args)
    let expr = ": gone]" //branch is gone from origin marker
    
    override x.EndProcessing() =
        let result = executeGit "branch -vv"
        let branches =
            result.stdout
            |> Seq.filter (fun x -> isMatch expr x)
            |> Seq.map (fun x -> x.Trim().Split(" ").[0])
            
        for branch in branches do
            executeGit $"branch -d {branch}" |> ignore
            x.WriteObject($"Branch {branch} has been deleted!")
            
        base.EndProcessing()
