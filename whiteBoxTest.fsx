open Awari

//TEST FOR PRINTBOARD    
printfn "Test for printBoard"

//Boardet bliver printet normalt
let mutable input = "[|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|]"
let mutable printBoardExpOut = ()
let mutable printBoardActOut = (printBoard [|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|]) |> ignore
let mutable boolRes = printBoardExpOut = printBoardActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input printBoardExpOut printBoardActOut boolRes

//Boardet bliver printet med mindre end 14 elementer
input <- "[|3;3;3;3;3;0; 3;3;3;3;3;3|]"
printBoardExpOut <- ()
printBoardActOut <- (printBoard [|3;3;3;3;3;0; 3;3;3;3;3;3|]) |> ignore
boolRes <- printBoardExpOut = printBoardActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input printBoardExpOut printBoardActOut boolRes

//TEST FOR ISHOME
printfn ""
printfn "Test for isHome"

//Player1 vælger et homePit
input <- "[|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player1 6"
let mutable isHomeExpOut = true
let mutable isHomeActOut = (isHome [|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player1 6)
boolRes <- isHomeExpOut = isHomeActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input isHomeExpOut isHomeActOut boolRes

//Player1 vælger ikke et homePit
input <- "[|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player1 1"
isHomeExpOut <- false
isHomeActOut <- (isHome [|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player1 1)
boolRes <- isHomeExpOut = isHomeActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input isHomeExpOut isHomeActOut boolRes

//Player2 vælger et homePit
input <- "[|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player2 13"
isHomeExpOut <- true
isHomeActOut <- (isHome [|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player2 13)
boolRes <- isHomeExpOut = isHomeActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input isHomeExpOut isHomeActOut boolRes

//Player2 vælger ikke et homePit
input <- "[|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player2 5"
isHomeExpOut <- false
isHomeActOut <- (isHome [|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player2 5)
boolRes <- isHomeExpOut = isHomeActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input isHomeExpOut isHomeActOut boolRes

//TEST FOR ISGAMEOVER
printfn ""
printfn "Test for isGameOver"

//Spillet er lige startet
input <- "[|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|]"
let mutable isGameOverExpOut = false
let mutable isGameOverActOut = (isGameOver [|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|])
boolRes <- isGameOverExpOut = isGameOverActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input isHomeExpOut isHomeActOut boolRes

//Player1 har alle pits tomme
input <- "[|0;0;0;0;0;0;0; 3;3;3;3;3;3;0|]"
isGameOverExpOut <- true
isGameOverActOut <- (isGameOver [|0;0;0;0;0;0;0; 3;3;3;3;3;3;0|])
boolRes <- isGameOverExpOut = isGameOverActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input isHomeExpOut isHomeActOut boolRes

//Player2 har alle pits tomme
input <- "[|0;0;0;0;0;0;0; 0;0;0;0;0;0;0|]"
isGameOverExpOut <- true
isGameOverActOut <- (isGameOver [|3;3;3;3;3;3;0; 0;0;0;0;0;0;0|])
boolRes <- isGameOverExpOut = isGameOverActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input isHomeExpOut isHomeActOut boolRes

//TEST FOR VALIDMOVE
printfn ""
printfn "Test for validMove"

//Længden af input stringen er ikke 1
input <- "[|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player1 \"12\" "
let mutable validMoveExpOut = false
let mutable validMoveActOut = (validMove [|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player1 "12")
boolRes <- validMoveExpOut = validMoveActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input isHomeExpOut isHomeActOut boolRes

//Input stringen er ikke 1,2,3,4,5,6
input <- "[|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player1 \"7\" "
validMoveExpOut <- false
validMoveActOut <- (validMove [|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player1 "7")
boolRes <- validMoveExpOut = validMoveActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input isHomeExpOut isHomeActOut boolRes

//Input stringen er et tomt pit
input <- "[|0;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player1 \"1\" "
validMoveExpOut <- false
validMoveActOut <- (validMove [|0;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player1 "1")
boolRes <- validMoveExpOut = validMoveActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input isHomeExpOut isHomeActOut boolRes

//Input stringen er et tomt pit
input <- "[|3;3;3;3;3;3;0; 0;3;3;3;3;3;0|] Player2 \"1\" "
validMoveExpOut <- false
validMoveActOut <- (validMove [|3;3;3;3;3;3;0; 0;3;3;3;3;3;0|] Player2 "1")
boolRes <- validMoveExpOut = validMoveActOut

//Input stringen er et validt pit
printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input isHomeExpOut isHomeActOut boolRes
input <- "[|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player1 \"4\" "
validMoveExpOut <- true
validMoveActOut <- (validMove [|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player1 "4")
boolRes <- validMoveExpOut = validMoveActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input isHomeExpOut isHomeActOut boolRes

//TEST FOR DISTRIBUTE
printfn ""
printfn "Test for distribute"

//Player1 vælger pit med 3 bolde i
input <- "[|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player1 2 "
let mutable distributeExpOut = ([|3;3;0;4;4;4;0; 3;3;3;3;3;3;0|], Player1, 5)
let mutable distributeActOut = (distribute [|3;3;3;3;3;3;0; 3;3;3;3;3;3;0|] Player1 2)
boolRes <- distributeExpOut = distributeActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input distributeExpOut distributeActOut boolRes

//Player1 vælger pit med 0 bolde i
input <- "[|3;3;0;4;4;4;0; 3;3;3;3;3;3;0|] Player1 2 "
distributeExpOut <- ([|3;3;0;4;4;4;0; 3;3;3;3;3;3;0|], Player1, 2)
distributeActOut <- (distribute [|3;3;0;4;4;4;0; 3;3;3;3;3;3;0|] Player1 2)
boolRes <- distributeExpOut = distributeActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input distributeExpOut distributeActOut boolRes

//Player1 lander i et tomt pit og tager Player2's bolde
input <- "[|3;0;0;0;0;0;0; 3;3;3;3;3;3;0|] Player1 0 "
distributeExpOut <- ([|0;1;1;0;0;0;4; 3;3;0;3;3;3;0|], Player1, 3)
distributeActOut <- (distribute [|3;0;0;0;0;0;0; 3;3;3;3;3;3;0|] Player1 0)
boolRes <- distributeExpOut = distributeActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input distributeExpOut distributeActOut boolRes

//Player2 lander i et tomt pit og tager Player1's bolde
input <- "[|3;3;3;3;3;3;0; 3;0;0;0;0;0;0|] Player2 0 "
distributeExpOut <- ([|3;3;0;3;3;3;0; 0;1;1;0;0;0;4|], Player2, 10)
distributeActOut <- (distribute [|3;3;3;3;3;3;0; 3;0;0;0;0;0;0|] Player2 7)
boolRes <- distributeExpOut = distributeActOut

printfn "Input: %A, Expected output: %A, Actual output: %A, Result: %A" input distributeExpOut distributeActOut boolRes
