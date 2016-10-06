////  CHARTING 
//#load "D:\GitCode\GenericTesting\GenericTesting\packages\FSharp.Charting.0.90.14\FSharp.Charting.fsx"
//
//open FSharp.Charting
//
//let linear x = 2.0 * x
//
//let quadratic x = x ** 2.0
//[ for x in 1.0 .. 100.0 -> (x, linear x)] |> Chart.Line
//[ for x in -10.0 .. 0.1 .. 10.0 -> (x, quadratic x)] |> Chart.Line
//[ for x in -10.0 .. 0.1 .. 10.0 -> (x, sin x)] |> Chart.Line

//distance examples
//let distance x y = x - y |> abs
//
//let distanceFrom5 = distance 5
//
//distanceFrom5 -5
//
//(distance 5) 2

////infix operator to chain logic together
//let (|><|) x y = x - y |> abs
//
//5 |><| 2 |><| 10

//Lambda examples for square and distance
//List.map (fun x -> x * x) [1;2;3;4;5]

//(fun (x:int) (y:int) -> x - y |> abs) 20 40

////Recursive Functions
//let rec length = function
//    | [] -> 0
//    | x::xs -> 1 + length xs
//
//length [1;2;3;4;8]
//
//let rec factorial n =
//    if n < 2 then
//        1
//    else
//        n * factorial (n-1)
//
//// Recursive function that implements the looping
//// (it takes previous two elements, a and b)
//let rec fibsRec a b =
//  if a + b < 400 then
//    // The current element
//    let current = a + b
//    // Calculate all remaining elements recursively 
//    // using 'b' as 'a' and 'current' as 'b' (in the next iteration)
//    let rest = fibsRec b current  
//    // Return the remaining elements with 'current' appended to the 
//    // front of the resulting list (this constructs new list, 
//    // so there is no mutation here!)
//    current :: rest
//  else 
//    [] // generated all elements - return empty list once we're done
//
//// generate list with 1, 2 and all other larger fibonaccis
//let fibs = fibsRec 0 1
//let fibs2 = fibsRec 2 8

////Functional Composition
//let minus1 x = x - 1
//let times2 = (*) 2
//
//times2 (minus1 9)
////Or compositionly with piping, giving preference with composition means
//times2 >> minus1 <| 9
//times2 << minus1 <| 9