using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    /// <summary>
    /// Text class contains methods to write long texts as introduction,
    /// winning and loosing texts and to have a small synopsis.
    /// </summary>
    /// <remarks>
    /// Text class can also be called for a color text method that will print
    /// any string with a given color of ConsoleColor type.
    /// </remarks>
    class Text
    {
        /// <summary>
        /// Displays the startup text
        /// </summary>
        public void StartupText()
        {
            // Small lore intro/Startup text
            Console.WriteLine("During the past 11 years " +
                "a group of ghosts has been forsaken " +
                "inside a small Git repository " +
                "that no longer gets updated...\n" +
                "The poor ghosts are lost " +
                "amongst all the commits and " +
                "endless lines of spaghetti code " +
                "and you need to help them!\n\n" +
                "Welcome to 18Ghosts!");
        }


        /// <summary>
        /// Displays the number of ghosts, their distribution 
        /// and the size of the board in text format
        /// </summary>
        public void BoardComponentsText()
        {
            // Board components
            Console.WriteLine("In this 2 player game " +
                "you and another need to" +
                " help your ghosts escape " +
                "the endless torment that is GitHub.\n" +
                "Each of you has command over 9 ghosts, " +
                "to a total of 18 ghosts. " +
                "Each of you having 3 of each color, " +
                "3 red ghosts, 3 blue ghosts and 3 yellow ghosts.\n" +
                "The git repository (your board) " +
                "is a 25 room/cells area (5x5) and a large dungeon" +
                " (a.k.a the forsaken pit of pull requests).\n");
        }

        /// <summary>
        /// Displays what you need to do in order to win the game
        /// </summary>
        public void GoalsText()
        {
            // Goals
            Console.WriteLine("As previously said, " +
                "you need to help your ghosts escape! " +
                "In order to do so you need to " +
                "guide your ghosts" +
                " to the portals.\n" +
                "You win once 3 of your own ghosts " +
                "have escaped, each ghost must be of a different color.\n");
        }

        /// <summary>
        /// Displays in text format the positions 
        /// of the portals and the mirrors
        /// </summary>
        public void BoardLayoutText()
        {
            // 
            Console.OutputEncoding = System.Text.Encoding.Unicode;

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
        }

        /// <summary>
        /// Displays how movement works
        /// </summary>
        public void MovementsText()
        {
            // Movement & Mirrors
            Console.Write("You can move one(1) of your ghosts orthogonally," +
                "you will never move them diagonally, by one(1) room/cell." +
                "You can move them wherever you please," +
                " if a ghost is standing in a mirror room " +
                "he may move from one mirror room to another, " +
                "regardless of distance and obstacles.");
        }

        /// <summary>
        /// Displays how combat works
        /// </summary>
        public void CombatText()
        {
            // Combat
            Console.WriteLine("You may move into occupied rooms " +
                "and fight the ghost that is currently there.\n" +
                "The winner is determined by their color:\n" +
                "\tRed beats Blue\n" +
                "\tBlue beats Yellow\n" +
                "\tYellow beats Red\n" +
                "Keep in mind you may fight your own ghosts.\n" +
                "\nEach time a ghost is defeated " +
                "it is sent to the dungeon, " +
                "the victor occupying the room.");
        }

        /// <summary>
        /// Displays how the portals work
        /// </summary>
        public void PortalText()
        {
            // Portals
            Console.WriteLine("In order to escape " +
                "a ghost must enter a portal. " +
                "A ghost may only enter the portal " +
                "if the portal is facing his direction. " +
                "Each time a ghost is defeated, " +
                "the portal corresponding to his color " +
                "rotates 90 degrees clockwise.\n" +
                "As soon as the opportunity arises the ghost will leave," +
                "regardless of whose turn it is. " +
                "The ghost needs to be standing in the adjacent room " +
                "to the portal and the portal's opening " +
                "must be facing the direction of the ghost," +
                "A ghost may only leave through " +
                "the portal that matches his color. " +
                "When a ghost leaves he can not return to the board and " +
                "is now free from the endless torment of the coders.");
        }

        /// <summary>
        /// Displays how to get out of the dungeon
        /// </summary>
        public void DungeonText()
        {
            // Dungeon
            Console.WriteLine("The dungeon is a nasty place, every defeated " +
                "ghost ends up there... but fear not for " +
                "he can return from the endless void of merge conflicts.\n" +
                "In order to release a ghost from the dungeon " +
                "you must give it to your opponent, I know but hear me out," +
                "in order to return the ghost to the board your opponent" +
                " must be the one who places it, upon your request. " +
                "In order to place the ghost there must be a " +
                "free carpet room/cell " +
                "(the ones you use to place the ghosts at the start) " +
                "of the same color of the ghost that you want to set free.\n" +
                "If such a room is unavailable " +
                "the ghost can not exit the dungeon.");
        }
    }
}
