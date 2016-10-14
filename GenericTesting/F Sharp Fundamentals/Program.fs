module Program 

open Test
open System
open System.Linq

let ls = [3; 9; 2; 15; 3]
let spl = "1 1 1 3 3"


[<EntryPoint>]
let main argv = 
    let a = spl //|> int
    //let b = Console.ReadLine() |> int
    let items = List.ofArray(spl.Split(' ')) |> List.map System.Int32.Parse
    determineReturnForNonDegenerateTriangles(items)
    0 // return an integer exit code