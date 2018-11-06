module Awari
type pit = int
type board = int array
type player = Player1 | Player2

let printBoard (b:board) : unit =
  System.Console.Clear()
  printfn "     _____                             _ "
  printfn "    / _   |  __ __  ___  ___   ____   |_|"
  printfn "   / / |  | |  |  |/  / /   | |  _ \\   _"
  printfn "  / /__|  | |        / / /| | | |_| | | |"
  printfn " /  ____  | |   /|  / / /_| | |    /  | |"
  printfn "/_ /    |_| |__/ |_/ /_/  |_| |_|\\_\\  |_|\n"
  printfn "              P L A Y E R 2"
  printfn "          6   5   4   3   2   1"
  printfn "         _______________________"
  printfn "        |   |   |   |   |   |   |"
  printf  " P  ____|"
  for i = 0 to 5 do
    let x = 12 - i
    printf "%3d|" (b.[x])
  printfn "____  P"
  printfn " L |    |   |   |   |   |   |   |    | L"
  printfn " A |    |   |   |   |   |   |   |    | A"
  printfn " Y | %2d |   |   |   |   |   |   | %2d | Y" (b.[13]) (b.[6])
  printfn " E |    |   |   |   |   |   |   |    | E"
  printfn " R |____|   |   |   |   |   |   |____| R"
  printf  " 2      |"
  for i = 0 to 5 do
    printf "%3d|" (b.[i])
  printfn "      1"
  printfn "        |___|___|___|___|___|___|"
  printfn "          1   2   3   4   5   6 "
  printfn "              P L A Y E R 1"

let isHome (b:board) (p:player) (i:pit) : bool =
  match p with
  | Player1 -> if i = 6 then true else false
  | Player2 -> if i = 13 then true else false

let isGameOver (b:board) : bool =
  if    Array.fold (+) 0 b.[0..5]  = 0 then true
  elif  Array.fold (+) 0 b.[7..12] = 0 then true
  else false

let validMove (b:board) (p:player) (s:string) : bool =
  let n = "123456"
  if not (s.Length = 1)  then false
  elif not (String.exists (fun c -> c = (char s)) n) then false
  else  match p with
        |Player1 -> if b.[(int s - 1)] = 0 then false else true
        |Player2 -> if b.[(int s) + 6] = 0 then false else true


let getMove (b:board) (p:player) (q:string) : pit =
  printfn "%s" q
  let mutable s = System.Console.ReadLine()
  while not (validMove b p s) do
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
    printBoard b
    if b.[6] > b.[13] then
      printfn "Congratulations Player 1! You've won!"
    else
      printfn "Congratulations Player 2! You've won!"
    printfn "Want to play again? (Y/N)"
    let answer = System.Console.ReadLine()
    match answer with
    | "Y" ->  play [|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player1
    | "N" ->  b
    | _   ->  printfn "couldn't understand, ending game..."
              b
  else
    let newB = turn b p
    let nextP =
      if p = Player1 then
        Player2
      else
        Player1
    play newB nextP
