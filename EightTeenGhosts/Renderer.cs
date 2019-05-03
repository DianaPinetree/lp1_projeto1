using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    static class Renderer
    {

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
                    // Check what state it has and print a proper character
                    color = board.boardState[i, j].Color;
                    type = board.boardState[i, j].Type;
                    switch (type)
                    {
                        case (CellType.Empty):
                            PrintEmpties(color,j);
                            break;
                        case (CellType.Mirror):
                            PrintMirrors();
                            break;
                        case (CellType.Portal):
                            PrintPortals(color, j);
                            break;
                    }
                    
                }
                Console.WriteLine();
                Console.WriteLine("|_____|_____|_____|_____|_____|");
            }

        }

        private static void PrintPortals(CellColor color, int collumn)
        {
            Console.Write($"|  ");
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
            Console.Write($"P");
            Console.ResetColor();
            if (collumn == 4)
                Console.Write($"  |");
            else
                Console.Write($"  ");
        }

        private static void PrintMirrors()
        {
            Console.Write($"|  ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"M");
            Console.ResetColor();
            Console.Write($"  ");
        }

        private static void PrintEmpties(CellColor color, int collumn)
        {
            char emptyState = '*';

            switch (color)
            {
                case (CellColor.Red):
                    {
                        if (collumn == 4)
                        {
                            Console.Write($"|  ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{emptyState}");
                            Console.ResetColor();
                            Console.Write($"  |");
                        }
                        else
                        {
                            Console.Write($"|  ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{emptyState}");
                            Console.ResetColor();
                            Console.Write($"  ");
                        }
                        break;
                    }
                case (CellColor.Blue):
                    {
                        if (collumn == 4)
                        {
                            Console.Write($"|  ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write($"{emptyState}");
                            Console.ResetColor();
                            Console.Write($"  |");
                        }
                        else
                        {
                            Console.Write($"|  ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write($"{emptyState}");
                            Console.ResetColor();
                            Console.Write($"  ");
                        }
                        break;
                    }
                case (CellColor.Yellow):
                    {
                        if (collumn == 4)
                        {
                            Console.Write($"|  ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{emptyState}");
                            Console.ResetColor();
                            Console.Write($"  |");
                        }
                        else
                        {
                            Console.Write($"|  ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{emptyState}");
                            Console.ResetColor();
                            Console.Write($"  ");
                        }
                        break;
                    }
            }
        }
    }
}
