// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Game

let rand = new System.Random()
let getGame size =
    let getRow () =
        [ 0 .. size ]
        |> List.map (fun _ -> if rand.Next() % 3 = 0 then 1 else 0)

    [ 0 .. size] |> List.map (fun _ -> getRow())

let printGame game =
    System.Console.Clear()
    let printRow row =
        row |> List.iter (fun v -> printf "%c" (if v = 1 then 'x' else ' '))
        printfn ""

    game
    |> List.iter printRow
    
// this is just a state monad
type GameBuilder () =
    member x.Return a = fun s -> a, s
    member x.Bind(m, f) =
        fun s -> 
            let a, s' = m s
            f a s'
    member x.While(g, f) =
        match g() with
        | true -> x.Bind(f, fun () -> x.While(g, f))
        | false -> x.Zero()
    member x.Zero() = x.Return ()
    member x.Delay(f) = f ()

let convertToDoable (f: 's -> 's) =
    fun s -> (), f s

let liftUnit (f: 's -> unit) =
    fun s -> f s, s

let withGame = new GameBuilder()

[<EntryPoint>]
let main argv = 
    
    let game = getGame 25
    
    let gs =
        withGame {
            while true do
                do! liftUnit printGame
                do! convertToDoable play
                System.Console.ReadKey() |> ignore
        }

    let final = gs game

    0 // return an integer exit code
