open System.IO

let massToFuelRatio (mass: int) = mass / 3 - 2

let computeFuelForFuel (mass: int) =
    let mutable fuels = [ mass ]

    while fuels.Head > 0 do
        let fuelMassFuel =
            match massToFuelRatio fuels.Head with
            | sub when sub < 0 -> 0
            | n -> n

        fuels <- fuelMassFuel :: fuels

    List.sum fuels

let moduleMasses = File.ReadLines("data/day1-input.txt")

let moduleFuel =
    moduleMasses |> Seq.sumBy (int >> massToFuelRatio)

printfn "Module fuel: %i" moduleFuel

let moduleMassesWithFuelForFuelMassFromModuleMass =
    moduleMasses
    |> Seq.sumBy (int >> massToFuelRatio >> computeFuelForFuel)

printfn "Total fuel: %i" moduleMassesWithFuelForFuelMassFromModuleMass
