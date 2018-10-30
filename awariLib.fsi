module Awari
///  Each player has a set of regular pits and one home pit. A pit holds zero or more beans
type pit = // intentionally left empty
/// A board consists of pits.
type board = // intentionally left empty
/// A game is played between two players
type player = Player1 | Player2

/// <summary>
/// Print the board
/// </summary>
/// <param name="b"> A board to be printed </param>
/// <returns>() - it just prints</returns>
/// , e.g.,
/// <remarks>
/// Output is for example,
/// <code>
///      3  3  3  3  3  3
///   0                    0
///      3  3  3  3  3  3
/// </code>
/// where player 1 is bottom row and rightmost home
/// </remarks>
val printBoard : b:board -> unit

/// <summary>
/// Check whether a pit is the player's home
/// </summary>
/// <param name="b">A board to check</param>
/// <param name="p">The player, whos home to check</param>
/// <param name="i">A regular or home pit of a player</param>
/// <returns>True if either side has no beans</returns>
val isHome : b:board -> p:player -> i:pit -> bool

/// <summary>
/// Check whether the game is over
/// </summary>
/// <param name="b"> A board to check</param>
/// <returns>True if either side has no beans</returns>
val isGameOver : b:board -> bool

/// <summary>
/// Get the pit of next move from the user
/// </summary>
/// <param name="b">The board the player is choosing from</param>
/// <param name="p">The player, whose turn it is to choose</param>
/// <param name="q">The string to ask the player</param>
/// <returns>The pit the player has chosen</returns>
val getMove : b:board -> p:player -> q:string -> pit

/// <summary>
/// Distributing beans counter clockwise, capturing when relevant
/// </summary>
/// <param name="b">The present statu of the board</param>
/// <param name="p">The player, whos beans to distribute</param>
/// <param name="i">The regular pit to distribute</param>
/// <returns>A new board after the beans of pit i has been distributed, and which player's pit the last bean landed in</returns>
val distribute : b:board -> p:player -> i:pit -> board * player * pit

/// <summary>
/// Interact with the user through getMove to perform a possibly repeated turn of a player
/// </summary>
/// <param name="b">The present state of the board</param>
/// <param name="p">The player, whose turn it is</param>
/// <returns>A new board after the player's turn</returns>
val turn : b:board -> p:player -> board

/// <summary>
/// Play game until one side is empty
/// </summary>
/// <param name="b">The initial board</param>
/// <param name="p">The player who starts</param>
/// <returns>A new board after one player has won</returns>
val play : b:board -> p:player -> board
