module Awari
type pit = int
type board = int array
type player = Player1 | Player2

// intentionally many missing implementations and additions
let printBoard (b:board) : unit =
  printf "\n%15s" ""
  for i=1 to 6 do
    let x = 14-i
    printf "|%3d" (b.[x])
  printf  "|\n"

  printf "%12s|%3d|%21s|%3d|\n" "" (b.[7]) "" (b.[0])

  printf "%15s" ""

  for i=1 to 6 do
    printf "|%3d" (b.[i])
  printf  "|\n"

let isHome (b:board) (p:player) (i:pit) : bool =
  match p with
  | Player1 -> if i = 0 then true else false
  | Player2 -> if i = 7 then true else false

/// <summary>
/// Check whether the game is over
/// </summary>
/// <param name="b"> A board to check</param>
/// <returns>True if either side has no beans</returns>
let isGameOver (b:board) : bool =
  if Array.fold (+) 0 b1.[1..6] then
    true
  elif Array.fold (+) 0 b1.[8..12] then
    true
  else
    false


let getMove (b:board) (p:player) (q:string) : pit =
  let isValidMove q = System.Int32.TryParse someString



let distribute (b:board) (p:player) (i:pit) : board * player * pit =
  (b,p,i)

let turn (b : board) (p : player) : board =
  let rec repeat (b: board) (p: player) (n: int) : board =
    printBoard b
    let str =
      if n = 0 then
        sprintf "Player %A's move? " p
      else
        "Again? "
    let i = getMove b p str
    let (newB, finalPitsPlayer, finalPit)= distribute b p i
    if not (isHome b finalPitsPlayer finalPit) || (isGameOver b) then newB
    else repeat newB p (n + 1)
  repeat b p 0

let rec play (b : board) (p : player) : board =
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
