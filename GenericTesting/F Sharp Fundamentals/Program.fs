module Program 

open Test
open System
open System.Linq

let input1 = "0 3 4 2"

[<EntryPoint>]
let main argv = 
    //let a = List.ofArray(input1.Split(' ')) |> List.map System.Int32.Parse
    let a = Console.ReadLine() |> int

    ViralAdvertising a
    0 // return an integer exit code