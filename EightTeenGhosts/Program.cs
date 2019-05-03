using System;
using System.Text;

namespace EightTeenGhosts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Encoding for UTF8 Chars
            Console.OutputEncoding = Encoding.UTF8;
            Board gameBoard;

            // Initialize a new game board
            gameBoard = new Board();

            // Draw the game board
            Renderer.DrawBoard(gameBoard);

            Console.Read();
        }
    }
}
