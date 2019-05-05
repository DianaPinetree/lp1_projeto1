using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    /// <summary>
    /// Contains the functions to render the board
    /// </summary>
    static class Renderer
    {
        /// <summary>
        /// Draws the whole state of the board
        /// </summary>
        /// <param name="board"></param>
        static public void DrawBoard(Board board)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Get the rows and cols of the board
            int rows = board.boardState.GetLength(0);
            int cols = board.boardState.GetLength(1);

            // Print out the top of the board
            Console.WriteLine(" _____________________________");

            // For loop to print the inside
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine("|     |     |     |     |     |");
                for (int j = 0; j < cols; j++)
                {
                    // CellState to save what state the current cell has
                    CellColor color;
                    CellType type;

                    // Get the color and the type of the current cell
                    color = board.boardState[i, j].Color;
                    type = board.boardState[i, j].Type;

                    // Check what is the type of the current cell and print
                    // the corresponding type
                    switch (type)
                    {
                        case (CellType.Empty):
                            PrintEmpty(color, j);
                            break;
                        case (CellType.Mirror):
                            PrintMirror();
                            break;
                        case (CellType.Portal):
                            PrintPortal(color, j);
                            break;
                    }

                }
                // Print the bottom of the board
                Console.WriteLine();
                Console.WriteLine("|_____|_____|_____|_____|_____|");
            }

        }

        /// <summary>
        /// Prints the empty cells of a respective color with an assigned index
        /// </summary>
        /// <param name="color"> Color you want to print </param>
        /// <param name="board"> 
        /// Board variable for the state of the board
        /// </param>
        public static void DrawBoardColor(CellColor color, Board board)
        {
            // Get the rows and cols of the board
            int rows = board.boardState.GetLength(0);
            int cols = board.boardState.GetLength(1);

            int cellIndex;
            char cellIndexChar;
            // Print out the top of the board
            Console.WriteLine(" _____________________________");

            cellIndex = 1;
            // For loop to print the inside
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine("|     |     |     |     |     |");
                for (int j = 0; j < cols; j++)
                {
                    if (board.boardState[i, j].Color == color &&
                        board.boardState[i, j].Type == CellType.Empty)
                    {
                        cellIndexChar = (char)(cellIndex + 48);
                        PrintEmpty(color, j, cellIndexChar);
                        cellIndex++;
                    }
                    else
                        PrintBlank(j);
                }

                // Print the bottom of the board
                Console.WriteLine();
                Console.WriteLine("|_____|_____|_____|_____|_____|");
            }
        }

        /// <summary>
        /// Writes the row of the Portal character of a cell
        /// </summary>
        /// <param name="color">
        /// color of the current cell of type CellColor
        /// </param>
        /// <param name="column">
        /// Current column that is going to be printed
        /// </param>
        private static void PrintPortal(CellColor color, int column)
        {
            // Writes the first character for the middle row of a cell
            Console.Write($"|  ");

            // Checks the color of the cell and changes foreground for the 
            // said color
            switch (color)
            {
                case (CellColor.Red):
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    }
                case (CellColor.Yellow):
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    }
                case (CellColor.Blue):
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    }
            }

            // Writes the representative char and closes the cell row
            // accordingly
            Console.Write($"P");
            Console.ResetColor();
            if (column == 4)
                Console.Write($"  |");
            else
                Console.Write($"  ");
        }

        /// <summary>
        /// Writes the row of the Mirror character of a cell
        /// </summary>
        private static void PrintMirror()
        {
            Console.Write($"|  ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"M");
            Console.ResetColor();
            Console.Write($"  ");
        }

        /// <summary>
        /// Writes the row of an Empty character of a cell
        /// </summary>
        /// <param name="color"></param>
        /// <param name="column"></param>
        private static void PrintEmpty(CellColor color, int column,
            char emptyState = '*')
        {
            Console.Write($"|  ");
            // Checks for the right color
            switch (color)
            {
                case (CellColor.Red):
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    }
                case (CellColor.Yellow):
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    }
                case (CellColor.Blue):
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    }
            }

            // Writes the representative char and closes the cell row
            // accordingly
            Console.Write($"{emptyState}");
            Console.ResetColor();
            if (column == 4)
                Console.Write($"  |");
            else
                Console.Write($"  ");
        }

        private static void PrintBlank(int column)
        {
            Console.Write($"|   ");
            if (column == 4)
                Console.Write($"  |");
            else
                Console.Write($"  ");
        }
    }
}
