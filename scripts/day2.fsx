open System.IO

let input =
    File.ReadAllText("data/day2.txt").Split(',')
    |> Seq.map int
    |> Seq.toArray

// Replace index 1 with 12 and index 2 with 2 per instructions.
input.[1] <- 12
input.[2] <- 2

let inline add x y = x + y
let inline mul x y = x * y

let getAction (i: int) =
    match i with
    | 1 -> Some(add)
    | 2 -> Some(mul)
    | _ -> None

let processHasMore (s: array<int>) =
    printfn "next seq op: %i" s.[0]
    s.[0] <> 99

exception ProgramException

let processSequence (i: int) (s: array<int>) =
    let action = getAction s.[0]
    match action with
    | Some fn -> input.[s.[3]] <- fn s.[1] s.[2]
    | None ->
        printfn "ERR: encountered unknown opcode '%i' at sequnce %i" s.[0] i
        raise ProgramException

input
|> Seq.chunkBySize 4
|> Seq.takeWhile processHasMore
|> Seq.iteri processSequence

input |> Seq.iter (printfn "%i")
printfn "Final: %i" input.[0]
