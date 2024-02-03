using System;
using TicTacToe;
class Program
{
    static void Main()
    {
        // Create a game board array to store players' choices
        int[] gameBoard = new int[9];
        // Initialize players
        int player1 = 1;
        int player2 = 2;
        // Game loop
        int currentPlayer = 1;
        Console.WriteLine("Welcome to Tic-Tac-Toe!");
        Console.WriteLine("To play, you will have to indicate the position you want to mark according to the board numbers available.");
        Console.WriteLine("=== EXAMPLE BOARD ===");
        Console.WriteLine(" ");
        Console.WriteLine(" 1 | 2 | 3");
        Console.WriteLine(" --+---+---");
        Console.WriteLine(" 4 | 5 | 6");
        Console.WriteLine(" --+---+---");
        Console.WriteLine(" 7 | 8 | 9");
        Console.WriteLine(" ");
        Console.WriteLine("So, for example, if you wanted to mark the bottom left corner, you would indicate number 7 when asked.");
        Console.WriteLine("Or, if you wanted to mark the top right corner, you would indicate number 3 instead.");
        Console.WriteLine("Occupied spaces will be marked with either an X or an O");
        Console.WriteLine("Let's begin!");
        Supporting supporting = new Supporting();
        for (int i = 0; i < gameBoard.Length; i++)
        {
            // Print the current game board
            Console.WriteLine(" ");
            Console.WriteLine("Current board:\n");
            supporting.PrintBoard(gameBoard);
            // Setting index to fail the while check by default
            int index = gameBoard.Length;
            do
            {
                // Receive the input from the player
                Console.WriteLine($"\nPlayer {currentPlayer}, enter the position of your choice (see instructions chart above):");
                index = int.Parse(Console.ReadLine()) - 1;
                if (index >= gameBoard.Length)
                {
                    Console.WriteLine("Invalid Move - Cell Does not Exist. Try Again!");
                    // Setting index to fail the while check
                    index = gameBoard.Length;
                } 
                else if (gameBoard[index] != 0)
                {
                    Console.WriteLine("Invalid Move - Cell Occupied. Try Again!");
                    // Setting index to fail the while check
                    index = gameBoard.Length;
                }
                else
                {
                    gameBoard[index] = (currentPlayer == 1) ? player1 : player2;
                    currentPlayer = (currentPlayer == 1) ? 2 : 1;
                }
            } while (index >= gameBoard.Length);
            // Check for a winner
            (bool gameOver, int winner) = supporting.GameStatus(gameBoard);
            if (gameOver == true)
            {
                Console.WriteLine("\nGame over!\n");
                // Print the final game board
                supporting.PrintBoard(gameBoard);
                // Tie
                if (winner == 0)
                {
                    Console.WriteLine("It was a tie!");
                    break;
                }
                // One of the players won
                else
                {
                    Console.WriteLine($"Player {winner} wins!");
                    break;
                }
            }
        }
    }
}