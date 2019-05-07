using System;
using System.Text;

namespace EightTeenGhosts
{
    /// <summary>
    /// Program class contains Main. Runs the game and takes optional arguments
    /// </summary>
    class Program
    {
        /// <summary>
        /// Initializes a new game and runs it, takes in arguments from the 
        /// console to run with a different game mode
        /// </summary>
        /// <param name="args">
        /// Array where the parameters passed through the console are stored
        /// </param>
        static void Main(string[] args)
        {
            //
            //Console.OutputEncoding = System.Text.Encoding.Unicode;

            // Board layout
            Console.WriteLine("The board is displayed " +
                "in the following manner:\n" +
                "\t3 Portals, one of each color, " +
                "all facing the edge of the board at the start:\n" +
                "\t\tA red Portal in the top row and the middle column\n" +
                "\t\tA blue Portal in the bottom row and the middle column\n" +
                "\t\tA yellow Portal in the middle row " +
                "and the right column\n" +
                "\t4 Mirrors:\n" +
                "\t\t2 in the 2nd row, in the 2nd and 4th columns\n" +
                "\t\t2 in the 4th row, in the 2nd and 4th columns\n" +
                "The rest of the rooms are carpets " +
                "that you will use to place your ghosts.\n\n" +
                "Board Legend:\n" +
                "M › Mirrors\n" +
                "P › Portals\n" +
                "* › Empty rooms/cells\n" +
                "A › Player A ghosts\n" +
                "B › Player B ghosts\n");

            Game game = new Game();
            game.Run();
        }
    }
}
