
open System
open Awari

printfn "\n%s" (""
+ "     _____                             _         \n"
+ "    / _   |  __ __  ___  ___   ____   |_|        \n"
+ "   / / |  | |  |  |/  / /   | |  _ \\   _        \n"
+ "  / /__|  | |        / / /| | | |_| | | |        \n"
+ " /  ____  | |   /|  / / /_| | |    /  | |        \n"
+ "/_ /    |_| |__/ |_/ /_/  |_| |_|\\_\\  |_|      \n")
printf "Enter name player #1: "
//let player1Name = Console.ReadLine()

//printf "Hi %s, Enter name player #2: " player1Name
//let player2Name = Console.ReadLine()
//printfn "Hi %s! Alright let's play awari" player2Name
<<<<<<< HEAD
let b = [|0; 3;3;3;3;3;3; 0; 3;3;3;3;3;3;|]
let b1 = [|0; 0;0;0;0;0;0; 0; 3;3;3;3;3;3;|]
printBoard b
printfn "isHome Player1 0 %b" (isHome b Player1 0)
printfn "isHome Player2 0 %b" (isHome b Player2 0)
printfn "isHome Player1 7 %b" (isHome b Player1 7)
printfn "isHome Player2 7 %b" (isHome b Player2 7)

printfn "isGameOver b %b" (isGameOver b)
printfn "isGameOver b1 %b" (isGameOver b1)

// let c = Console.ReadLine()
=======
let b =   [|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|]
play b Player1
//printBoard b
//printBoard b1
//printfn "%b" (isHome b Player1 0)
//let c = Console.ReadLine()
>>>>>>> 395075ea98352da7e9c4a21d5e9b216f9bfacdb6
//printfn "%b" (isGameOver b)
//printfn "%b" (isGameOver b1)
//let endB = (play b Player1)
//printfn "%A" endB
