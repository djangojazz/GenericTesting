module Program 

open Test
open System
open System.Linq

let input = "4 2 4"
let spl = "1 2 3 5"


[<EntryPoint>]
let main argv = 
    let input = List.ofArray(input.Split(' ')) |> List.map System.Int32.Parse
    let n = input.[0]
    let k = input.[1]
    let q = input.[2]
    let ls = List.ofArray(spl.Split(' ')) |> List.map System.Int32.Parse
    
    getCircularArrayRotation ls k

    0 // return an integer exit code