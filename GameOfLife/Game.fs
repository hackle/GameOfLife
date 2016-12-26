module Game

let mapRow (rowIdx, vals) =
    vals
    |> List.indexed
    |> List.map (fun (colIdx, v) -> (rowIdx, colIdx, v))

let toCells game =
    game
    |> List.indexed
    |> List.map mapRow
    |> List.concat

let findCell row col cells =
    List.exists (fun (r, c, v) -> r = row && col = c && v = 1) cells    

let countNeighbors row col cells =
    [
        (row - 1, col - 1); (row - 1, col); (row - 1, col + 1);
        (row, col - 1); (row, col + 1);
        (row + 1, col - 1); (row + 1, col); (row + 1, col + 1)
    ]
    |> List.sumBy (fun (r, c) -> if (findCell r c cells) then 1 else 0)

let mutate cells (r, c, v) =
    let cntNeig = countNeighbors r c cells
    
    let nextVal =
        match v with
        | 1 when cntNeig < 2 -> 0
        | 1 when cntNeig >= 3 -> 0
        | 0 when cntNeig = 3 -> 1
        | _ -> v

    (r, c, nextVal)
    
let fromCells cells =
    cells
    |> List.groupBy (fun (r, _, _) -> r)
    |> List.map (fun (r, cells) -> cells)
    |> List.map (List.map (fun (_, _, v) -> v))

let play game =
    let cells = toCells game
    
    cells
    |> List.map (mutate cells)
    |> fromCells