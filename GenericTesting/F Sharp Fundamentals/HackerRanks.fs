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