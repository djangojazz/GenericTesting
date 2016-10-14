//let a = Console.ReadLine() |> int
//let b = List.ofArray(Console.ReadLine().Split(' ')) |> List.map System.Int32.Parse

open System
open System.Linq


let ls = [3; 9; 2; 15; 3]
let spl = "1 1 1 3 3"

let rec determineReturnForNonDegenerateTriangles ls  = 
    if ls |> List.length < 3 then printfn "-1"
    else 
      let subset = ls |> List.sortDescending |> List.take(3)
      if (subset.[0] < (subset.[1] + subset.[2])) then
        printfn "%A %A %A" subset.[2] subset.[1] subset.[0]
      else
        determineReturnForNonDegenerateTriangles(ls |> List.sort |> List.take(ls.Length - 1))

let items = List.ofArray(spl.Split(' ')) |> List.map System.Int32.Parse
determineReturnForNonDegenerateTriangles(items)