open System


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

Kangeroo 0 3 4 2