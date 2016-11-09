module Test

let rec determineReturnForNonDegenerateTriangles ls = 
    if ls |> List.length < 3 then printfn "-1"
    else 
      let subset = ls |> List.sortDescending |> List.take(3)
      if (subset.[0] < (subset.[1] + subset.[2])) then
        printfn "%A %A %A" subset.[2] subset.[1] subset.[0]
      else
        determineReturnForNonDegenerateTriangles(ls |> List.sort |> List.take(ls.Length - 1))

let getCircularArrayRotation (ls:List<int>) (k:int) = 
    let nls = List.append (ls |> List.skip(ls.Length - k)) (ls |> List.take(ls.Length - k))
    for i in 0 .. nls.Length-1 do printfn "%d" nls.[i]

let distanceOfApplesAndOranges (rangeOfHouse: List<int>) (orangeAndApplePoints: List<int>) (numerofApplesAndOranges: List<int>) (appleFalls: List<int>) (orangeFalls: List<int>) =
    printfn "%d" (appleFalls |> List.map(fun a -> orangeAndApplePoints.[0] + a) |> List.where(fun x -> x >= rangeOfHouse.[0] && x <= rangeOfHouse.[1])  |> List.length)
    printfn "%d" (orangeFalls |> List.map(fun a -> orangeAndApplePoints.[1] + a) |> List.where(fun x -> x >= rangeOfHouse.[0] && x <= rangeOfHouse.[1])  |> List.length)

let Kangeroo x1 y1 x2 y2 =
    let jump start hop times =  start + (times * hop)
    let mutable i = 0

    if (x1 > x2 && y1 > y2) || (x2 > x1 && y2 > y1) then
        printfn "NO"
        i <- i + 20000
    while i <= 10000 do
    i <- i + 1
    if (jump x1 y1 i) = (jump x2 y2 i) then
        printfn "YES"
        i <- i + 20000
    else if i >= 10000 then
        printfn "NO"