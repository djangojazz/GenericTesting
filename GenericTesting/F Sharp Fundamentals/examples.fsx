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

////STRINGS
//"It was the best of times,
//it was the worst of times,"
//
//"""This "string" includes double quotes"""
//
//@"This ""string"" includes double quotes"
//
//// try this with and without the @
//@"Verbatim strings\n don't\t encode\n escape sequences"

////INDEXING
//let intro = "It was the best of times,"
//intro.[0]
//intro.[1]
//
//"It was the best of times,
//it was the worst of times,".[3..5]  // [..5] starts from the beginning, [3..] continues till the end

////STRING MODULE
//String.forall System.Char.IsDigit "03454a3"
//
//String.init 10 (fun i -> i * 10 |> string)

////LISTS
//[] // Empty List
//
//[1;2;3]  // Explicit List
//
//1 :: [2;3]  // cons adds to list
//
//1:: (2 :: (3 ::[])) // cons paired up
//1:: 2 :: 3 ::[] // cons paired up without determining scope
//[1..5] //specify range
//
//[1..2..5] // specify range with an incrementor to use
//[1..3..7] // specify range with an incrementor to use
//[10..-1..0] // or do it backwards
//
//['a';'b'] @ ['c';'d'] //joining two lists of same type together
//[1;2;3] @ [4;8] // same as above with numbers

//// LIST COMPREHENSIONS
//[for x in 1..10 do yield 2 * x]
//[for x in 1..10 -> 2 * x]
//
//[
//    for r in 1..8 do
//    for c in 1..8 do
//        if r <> c then
//            yield (r, c)
//]


//// ARRAYS - no cons operator
//[|1;2;3|].[1]

//// TUPLES
//(2, "hat", 2.71828, false)  // different types are totally cool with tuples
//
//fst ("Bob", 55)  //first is a string
//snd ("Bob", 55) // second is an integer
//
//let (name, age) = ("Bob", 55) // defined

//// RECORDS
//type Person = {
//    name: string;
//    age: int
//    } with member this.canDrive = this.age > 17
//
//{name = "Bob"; age = 55}.canDrive
//
//let bob = {name = "bob"; age = 55}
//
////records are immutable, yet you can update them using the 'with' keyword
//{bob with age = 56}

////DISCRIMINATED UNIONS  -- similar to enums
//type Note = A | ASharp | B | C | CSharp | D | DSharp | E | F | FSharp | G | GSharp
//type Octave = One | Two | Three
//type Sound = Rest | Tone of Note * Octave
//
//Tone (C, Two)
//
//match Tone (C, Two) with 
//    | Tone (note, octave) -> sprintf "%A %A" note octave
//    | Rest -> "___"

////GENERICS
//type NamedValue<'a> = {name: string; value: 'a}
//
//{name = "Thing"; value = 1}
//{name = "Thing"; value = "a"}

//PARSER
#r @"D:\GitCode\GenericTesting\GenericTesting\packages\FParsec.1.0.2\lib\net40-client\FParsecCS.dll"
#r @"D:\GitCode\GenericTesting\GenericTesting\packages\FParsec.1.0.2\lib\net40-client\FParsec.dll"

//#load @"D:\GitCode\GenericTesting\GenericTesting\packages\FParsec.1.0.2\lib\net40-client\FParsecCS.dll";
open FParsec

let letters = "abcdefg"

run anyChar letters
    |> sprintf "%+A"

let parsesA = pchar 'a'
run parsesA "abcdefg"
    |> sprintf "%+A"

 // parses out numbers from string
let plistoffloats = (sepBy pfloat (pchar ',' .>> spaces))
run plistoffloats "1.1, 3.7"


// parser out points 
type Point = {x: float; y: float}

let plistoffloats' =  pipe3 pfloat (pchar ',' .>> spaces) pfloat (fun x z y -> {x = x; y = y})
run plistoffloats' "1.1, 3.7"


let ppoint' = between (pchar '(') (pchar ')') plistoffloats'
run ppoint' "(1.1, 3.7)"