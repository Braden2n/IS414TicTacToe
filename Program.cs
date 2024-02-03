using System;
using TicTacToe;

class Program
{
    static void Main()
    {

        Console.WriteLine("Welcome to Tic-Tac-Toe!");

        // Create a game board array to store players' choices
        int[] gameBoard = new int[9];

        // Initialize players
        char player1 = 'X';
        char player2 = 'O';

        // Game loop
        int currentPlayer = 1;

        Console.WriteLine("Welcome to Tic-Tac-Toe!");
        Console.WriteLine("To play, you will have to indicate the position you want to mark following the instructions chart below.");
        Console.WriteLine("=== INSTRUCTIONS CHART ===");
        Console.WriteLine(" ");
        Console.WriteLine(" 1 | 2 | 3");
        Console.WriteLine(" --+---+---");
        Console.WriteLine(" 4 | 5 | 6");
        Console.WriteLine(" --+---+---");
        Console.WriteLine(" 7 | 8 | 9");
        Console.WriteLine(" ");
        Console.WriteLine("So, for example, if you wanted to mark the bottom left corner, you would indicate number 7 when asked.");
        Console.WriteLine("Or, if you wanted to mark the top right corner, you would indicate number 3 instead.");
        Console.WriteLine("Let's begin!");

        Supporting supporting = new Supporting();

        for (int i = 0; i < gameBoard.Length; i++)
        {
            // Print the current game board
            Console.WriteLine(" ");
            Console.WriteLine("Current board:");
            supporting.PrintBoard(gameBoard);

            // Receive the input from the player
            Console.WriteLine($"Player {currentPlayer}, enter the position of your choice (see instructions chart above):");
            int index = int.Parse(Console.ReadLine()) - 1;

            // Update the game board with the player's choice
            if (gameBoard[index] == 0)
            {
                gameBoard[index] = (currentPlayer == 1) ? player1 : player2;
                currentPlayer = (currentPlayer == 1) ? 2 : 1;
            }
            else
            {
                Console.WriteLine("Invalid move. Cell already taken. Try again.");
            }

            // Check for a winner
            (bool gameOver, int winner) = supporting.GameStatus(gameBoard);
            if (gameOver == true)
            {
                Console.WriteLine("Game over!");

                // Print the final game baord
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
