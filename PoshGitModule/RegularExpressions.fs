module RegularExpressions

open System.Text.RegularExpressions

let matchSample expr text =
    let r = Regex(expr)
    
    r.Match text

let isMatch expr text =
    let r = matchSample expr text
    
    r.Success
