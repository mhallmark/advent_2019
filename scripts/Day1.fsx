open System.IO

let massToFuelRatio (mass: int) = mass / 3 - 2

let moduleFuel =
    File.ReadLines("data/day1-input.txt")
    |> Seq.map (int)
    |> Seq.sumBy (massToFuelRatio)

printfn "Module fuel: %i" moduleFuel

let mutable fuels = [ massToFuelRatio moduleFuel ]

while fuels.Head > 0 do
    let fuelMassFuel =
        match massToFuelRatio fuels.Head with
        | sub when sub < 0 -> 0
        | n -> n

    fuels <- fuelMassFuel :: fuels

Seq.iter (printfn "More fuel mass: %i") fuels

let fuelFuel = fuels |> Seq.sum

printfn "Fuel fuel: %i" fuelFuel

let totalFuel = moduleFuel + fuelFuel
printfn "Total fuel: %i" totalFuel
