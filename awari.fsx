
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
let b = [|0; 3;3;3;3;3;3; 0; 3;3;3;3;3;3;|]
let b1 = [|0; 0;0;0;0;0;0; 0; 3;3;3;3;3;3;|]
printBoard b
printBoard b1
printfn "%b" (isHome b Player1 0)
let c = Console.ReadLine()
//printfn "%b" (isGameOver b)
//printfn "%b" (isGameOver b1)
//let endB = (play b Player1)
//printfn "%A" endB
