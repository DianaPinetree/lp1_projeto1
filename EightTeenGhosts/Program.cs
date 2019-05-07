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
            Game game = new Game();
            game.Run();
        }
    }
}
