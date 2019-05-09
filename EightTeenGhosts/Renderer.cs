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
        static public void DrawBoard(Board board,
            Cell[] p1Ghosts, Cell[] p2Ghosts, Portal[] portals)
        {
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
                    // CellState and CellColor
                    // to save what state the current cell has
                    CellColor color;
                    CellType type;

                    bool isGhost;
                    bool isPortal;
                    Cell ghostCell;
                    Portal portalCell;
                    char playerChar;
                    char portalChar;

                    // Get the color and the type of the current cell
                    color = board.boardState[i, j].Color;
                    type = board.boardState[i, j].Type;
                    isGhost = false;
                    isPortal = false;
                    playerChar = ' ';

                    ghostCell = new Cell(CellType.Ghost);
                    for (int k = 0; k < 9; k++)
                    {
                        if (p1Ghosts[k].Position.x == i
                           && p1Ghosts[k].Position.y == j)
                        {
                            ghostCell.Color = p1Ghosts[k].Color;
                            isGhost = true;
                            playerChar = 'A';
                            break;
                        }
                        else if (p2Ghosts[k].Position.x == i
                           && p2Ghosts[k].Position.y == j)
                        {
                            ghostCell.Color = p1Ghosts[k].Color;
                            isGhost = true;
                            playerChar = 'B';
                            break;
                        }
                        else
                            continue;
                    }

                    portalCell = new Portal(new Position(i,j), color, "Up");
                    for (int k = 0; k < 3; k++)
                    {
                        if (portals[k].Position.x == i
                            && portals[k].Position.y == j)
                        {
                            portalCell.OpenSide = portals[k].OpenSide;
                            portalCell.Color = portals[k].Color;
                            isPortal = true;
                        }
                    }

                    if (isGhost)
                    {
                        PrintCell(ghostCell.Color, j, playerChar);
                    }
                    else if (isPortal)
                    {
                        PrintCell(portalCell.Color, j, 
                            portalCell.GetSideChar());
                    }
                    else
                    {
                        // Check what is the type of the current cell and print
                        // the corresponding type
                        switch (type)
                        {
                            case (CellType.Empty):
                                PrintCell(color, j);
                                break;
                            case (CellType.Mirror):
                                PrintMirror();
                                break;
                        }
                    }
                }
                // Print the bottom of the board
                Console.WriteLine();
                Console.WriteLine("|_____|_____|_____|_____|_____|");
            }
        }

        public static void DrawDungeon(Player currentPlayer)
        {
            // Informative line
            Console.WriteLine("Ghosts in player's Dungeon: ");
            // Top line
            for (int i = 0; i < currentPlayer.Dungeon.Length; i++)
                Console.Write("_______");
            Console.WriteLine();
            for (int i = 0; i < currentPlayer.Dungeon.Length; i++)
                Console.Write("|     |");
            Console.WriteLine();
            // Print lines with ghosts
            foreach (Cell ghost in currentPlayer.Dungeon)
            {
                PrintCell(ghost.Color, 4, 'G');
            }
            Console.WriteLine("|");
            for (int i = 0; i < currentPlayer.Dungeon.Length; i++)
                Console.Write("|_____|");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints the empty cells of a respective color with an assigned index
        /// </summary>
        /// <param name="color"> Color you want to print </param>
        /// <param name="board"> 
        /// Board variable for the state of the board
        /// </param>
        public static void EnumerateBoardColor(CellColor color, Board board, CellType type)
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
                            board.boardState[i, j].Type == type)
                    {
                        cellIndexChar = (char)(cellIndex + 48);
                        PrintCell(color, j, cellIndexChar);
                        cellIndex++;
                    }
                    else
                    {
                        PrintBlank(j);
                    }
                }

                // Print the bottom of the board
                Console.WriteLine();
                Console.WriteLine("|_____|_____|_____|_____|_____|");
            }
        }

        public static void EnumeratePlayerGhosts(Player player, Board board)
        {
            // Get the rows and cols of the board
            int rows = board.boardState.GetLength(0);
            int cols = board.boardState.GetLength(1);

            Cell cell;
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
                    cell = new Cell(CellType.Ghost);
                    foreach (Cell ghost in player.PlayerGhosts)
                    {

                        if (ghost.Position.x == i
                           && ghost.Position.y == j)
                        {
                            cell.Position = ghost.Position;
                            cell.Color = ghost.Color;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (cell.Position != null)
                    {
                        cellIndexChar = (char)(cellIndex + 48);
                        PrintCell(cell.Color, j, cellIndexChar);
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
        private static void PrintCell(CellColor color, int column,
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

        /// <summary>
        /// Prints a simple blank cell
        /// </summary>
        /// <param name="column">
        /// Checks if it's the last column of the board
        /// to insert the closing char
        /// </param>
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
