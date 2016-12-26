module GameTest

open Game
open Xunit

[<Fact>]
let ``Any live cell with fewer than two live neighbours dies`` () =
    let game = [
        [ 0; 0; 0; 0; 0 ];
        [ 0; 1; 0; 0; 0 ];
        [ 0; 0; 1; 0; 0 ];
        [ 0; 0; 0; 0; 0 ];
        [ 0; 0; 0; 0; 0 ]
    ]

    let expected = [
        [ 0; 0; 0; 0; 0 ];
        [ 0; 0; 0; 0; 0 ];
        [ 0; 0; 0; 0; 0 ];
        [ 0; 0; 0; 0; 0 ];
        [ 0; 0; 0; 0; 0 ]
    ]

    let actual = play game

    Assert.Equal<int list list>(expected, actual)
    
[<Fact>]
let ``Any live cell with more than three live neighbours dies`` () = 
    let game = [
        [ 0; 0; 0; 0; 0 ];
        [ 0; 1; 0; 1; 0 ];
        [ 0; 0; 1; 0; 0 ];
        [ 0; 1; 0; 1; 0 ];
        [ 0; 0; 0; 0; 0 ]
    ]

    let expected = [
        [ 0; 0; 0; 0; 0 ];
        [ 0; 0; 1; 0; 0 ];
        [ 0; 1; 0; 1; 0 ];
        [ 0; 0; 1; 0; 0 ];
        [ 0; 0; 0; 0; 0 ]
    ]

    let actual = play game

    Assert.Equal<int list list>(expected, actual)




[<Fact>]
let ``Any dead cell with exactly three live neighbours becomes alive`` () = 
    let game = [
        [ 0; 0; 0; 0; 0 ];
        [ 0; 1; 0; 1; 0 ];
        [ 0; 0; 0; 0; 0 ];
        [ 0; 1; 0; 0; 0 ];
        [ 0; 0; 0; 0; 0 ]
    ]

    let expected = [
        [ 0; 0; 0; 0; 0 ];
        [ 0; 0; 0; 0; 0 ];
        [ 0; 0; 1; 0; 0 ];
        [ 0; 0; 0; 0; 0 ];
        [ 0; 0; 0; 0; 0 ]
    ]

    let actual = play game

    Assert.Equal<int list list>(expected, actual)
    
[<Fact>]
let ``Any`` () = 
    let game = [
        [ 0; 0; 0; 0; 0 ];
        [ 0; 0; 0; 0; 0 ];
        [ 0; 0; 0; 0; 0 ];
        [ 0; 0; 0; 1; 1 ];
        [ 0; 0; 0; 1; 1 ]
    ]

    let expected = [
        [ 0; 0; 0; 0; 0 ];
        [ 0; 0; 0; 0; 0 ];
        [ 0; 0; 0; 0; 0 ];
        [ 0; 0; 0; 0; 0 ];
        [ 0; 0; 0; 0; 0 ]
    ]

    let actual = play game

    Assert.Equal<int list list>(expected, actual)

