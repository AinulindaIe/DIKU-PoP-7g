module Awari
type pit = // intentionally left empty
type board = // intentionally left empty
type player = Player1 | Player2

/// Print the board
val printBoard : b: board -> unit

/// Check whether a pit is the player 's home
val isHome : b : board -> p : player -> i : pit -> bool

/// Check whether the game is over
val isGameOver : b: board -> bool

/// Get the pit of next move from the user
val getMove : b: board -> p: player -> q: string -> pit

/// Distributing beans counter clockwise ,
/// capturing when relevant
val distribute :
b: board -> p: player -> i: pit -> board * player * pit

/// Interact with the user through getMove to perform
/// a possibly repeated turn of a player
val turn : b: board -> p : player -> board

/// Play game until one side is empty
val play : b: board -> p : player -> board
