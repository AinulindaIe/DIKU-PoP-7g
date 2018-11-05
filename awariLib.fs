module Awari
type pit = int
type board = int array
type player = Player1 | Player2

// intentionally many missing implementations and additions
let printBoard (b:board) : unit =
  printf "\n%15s" ""
  for i=0 to 5 do
    let x = 12-i
    printf "|%3d" (b.[x])
  printf  "|\n"

  printf "%11s|%3d|%23s|%3d|\n" "" (b.[13]) "" (b.[6])

  printf "%15s" ""

  for i=0 to 5 do
    printf "|%3d" (b.[i])
  printf  "|\n"

let isHome (b:board) (p:player) (i:pit) : bool =
  match p with
  | Player1 -> if i = 6 then true else false
  | Player2 -> if i = 13 then true else false

/// <summary>
/// Check whether the game is over
/// </summary>
/// <param name="b"> A board to check</param>
/// <returns>True if either side has no beans</returns>
let isGameOver (b:board) : bool =
  if    Array.fold (+) 0 b.[0..5]  = 0 then true
  elif  Array.fold (+) 0 b.[7..12] = 0 then true
  else false

let validMove (s:string) : bool =
  let n = "123456"
  if s.Length > 1 then false
  elif (String.exists (fun c -> c = (char s)) n) then true
  else false

let getMove (b:board) (p:player) (q:string) : pit =
  printfn "%s" q
  let mutable s = System.Console.ReadLine()
  while not (validMove s) do
    printfn "Enter valid pit: "
    s <- System.Console.ReadLine()
  match p with
  |Player1 -> (int s) - 1
  |Player2 -> 6 + (int s)

let distribute (b:board) (p:player) (i:pit) : board * player * pit =
  let finalPit    = (i + b.[i])%14
  let mutable n = b
  for j=1 to b.[i] do
    let index = (i+j)%14
    n.[index] <- b.[index] + 1
  n.[i] <- 0
  if n.[finalPit] = 1 && not (isHome n p finalPit) then
    match p with
    | Player1 -> n.[6] <- n.[6] + n.[12-finalPit] + 1
    | Player2 -> n.[13] <- n.[13] + n.[12-finalPit] + 1
    n.[12-finalPit] <- 0
    n.[finalPit]    <- 0
  (n, p, finalPit)


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
