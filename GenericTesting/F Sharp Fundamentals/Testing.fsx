let ls = [3; 9; 2; 15; 3]

let descendAndTake3 ls = ls |> List.sortDescending |> List.take(3)

let result = ls |> List.sortDescending |> List.take(3)