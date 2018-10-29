module Awari
type pit = // intentionally left empty
type board = // intentionally left empty
type player = Player1 | Player2

// intentionally many missing implementations and additions
let printBoard (b:board) : () =

let isHome (b:board) (p:player) (i:pit) : bool =

let isGameOver (b:board) : bool =

let getMove (b:board) (p:player) (q:string) : pit =

let distribute (b:board) (p:player) (i:pit) : board * player * pit =

let turn ( b : board ) (p : player ) : board =
    let rec repeat ( b: board ) ( p: player ) ( n: int ) : board =
        printBoard b
        let str =
            if n = 0 then
                sprintf " Player %A 's move ? " p
            else
                " Again ? "
        let i = getMove b p str
        let ( newB , finalPitsPlayer , finalPit )= distribute b p i
        if not ( isHome b finalPitsPlayer finalPit )
             || ( isGameOver b ) then
            newB
        else
            repeat newB p (n + 1)
    repeat b p 0

let rec play ( b : board ) ( p : player ) : board =
    if isGameOver b then
        b
    else
        let newB = turn b p
        let nextP =
            if p = Player1 then
                Player2
            else
                Player1
        play newB nextP

let play (b:board) (p:player) : board =
