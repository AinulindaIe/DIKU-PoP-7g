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

  printf "%12s|%3d|%21s|%3d|\n" "" (b.[13]) "" (b.[6])

  printf "%15s" ""

  for i=1 to 6 do
    printf "|%3d" (b.[i])
  printf  "|\n"

let isHome (b:board) (p:player) (i:pit) : bool =
  match p with
  | Player1 -> if i = 6 then true else false
  | Player2 -> if i = 13 then true else false

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
  printfn "Enter valid pit: "
  let mutable s = System.Console.ReadLine()
  while not (validMove s) do
    printfn "Enter valid pit: "
    s <- System.Console.ReadLine()
  match p with
  |Player1 -> (int s) - 1
  |Player2 -> 6 + (int s)

let distribute (b:board) (p:player) (i:pit) : board * player * pit =
  let mutable index = 0
  match p with
  | Player1 -> index <- i
  | Player2 -> index <- i + 6
  let mutable newB = b
  let mutable newI = 0
  newB.[index] <- 0
  for i = 1 to b.[index] + 1 do
    newI <- (i+index)%14
    newB.[newI] <- b.[newI] + 1
  if newB.[newI] = 1 then
    match p with
    | Player1 -> newB.[6] <-  newB.[6] + newB.[newI] + newB.[12-newI]
    | Player2 -> newB.[13] <- newB.[6] +  newB.[newI] + newB.[12-newI]
    newB.[newI] <- 0
    newB.[12-newI] <- 0
  (newB, p, newI)

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
