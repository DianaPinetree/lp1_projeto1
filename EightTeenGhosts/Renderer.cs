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

            //Declare all chars needed to print out the board
            char emptyState = '\u00A4';
            char Mirror = '\u06E9';

            //Get the rows and cols of the board
            int rows = board.boardState.GetLength(0);
            int cols = board.boardState.GetLength(1);

            //Print out the top of the board
            Console.WriteLine(" _____________________________");

            //For loop to print the inside
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine("|     |     |     |     |     |");
                for (int j = 0; j < cols; j++)
                {
                    //CellState to save what state the current cell has
                    CellState state;

                    //Check what state it has and print a proper character
                    state = board.boardState[i, j];
                    switch (state)
                    {
                        case (CellState.EmptyRed):
                            {
                                if (j == 4)
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
                        case (CellState.EmptyBlue):
                            {
                                if (j == 4)
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
                        case (CellState.EmptyYellow):
                            {
                                if (j == 4)
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
                        case (CellState.Mirror):
                            {
                                Console.Write($"|  ");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write($"M");
                                Console.ResetColor();
                                Console.Write($"  ");
                                break;
                            }
                        case (CellState.Portal):
                            {
                                Console.Write($"|  ");
                                switch (i)
                                {
                                    case (0):
                                        {
                                            Console.ForegroundColor = 
                                                ConsoleColor.Red;
                                            break;
                                        }
                                    case (2):
                                        {
                                            Console.ForegroundColor =
                                                ConsoleColor.Yellow;
                                            break;
                                        }
                                    case (4):
                                        {
                                            Console.ForegroundColor =
                                                ConsoleColor.Blue;
                                            break;
                                        }
                                }
                                Console.Write($"P");
                                Console.ResetColor();
                                if(i == 2)
                                    Console.Write($"  |");
                                else
                                    Console.Write($"  ");
                                break;
                            }
                        default:
                            {
                                if (j == 4)
                                {
                                    Console.Write($"|   ");
                                    Console.Write($"  |");
                                }
                                else
                                {
                                    Console.Write($"|   ");
                                    Console.Write($"  ");
                                }
                                break;
                            }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("|_____|_____|_____|_____|_____|");
            }

            Console.Beep();
        }
    }
}
