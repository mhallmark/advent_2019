open System.IO

let massToFuelRatio (mass: int) = mass / 3 - 2

let computeFuel (filePath: string) =
    File.ReadLines(filePath)
    |> Seq.map (int)
    |> Seq.sumBy (massToFuelRatio)

printfn "%i" <| computeFuel "data/day1-input.txt"
