using System;
using System.Collections.Generic;
using System.Text;

namespace EightTeenGhosts
{
    /// <summary>
    /// Represents a player from the game
    /// </summary>
    class Player
    {
        // The number of ghosts a player has of a certain color
        private int rNum = 0;
        private int bNum = 0;
        private int yNum = 0;

        /// <value>
        /// Gets and Sets the name of the player of a Player instance.
        /// </value>
        public string PlayerName { get; set; }

        // Array for the Player's owned ghosts
        /// <value>
        /// Cell array property for the player's owned ghosts with a get and a
        /// private set
        /// </value>
        public List<Cell> PlayerGhosts { get; set; }

        public List<Cell> Dungeon { get; private set; }

        // Property for the ghosts that have left the castle, player 1 and 2
        /// <value> 
        /// Property array with 2 positions for the ghosts that are outside
        /// the git repository, ghosts that count for the win state.<br>
        /// Can only be changed from inside the Board class.
        /// </value>
        public List<Cell> ghostsOutside { get; private set; }

        // Constructor that receives a player name
        /// <summary>
        /// Constructor that initializes the player's ghost array 
        /// as well as the custom player name
        /// </summary>
        /// <param name="playerName"></param>
        public Player(string playerName)
        {
            PlayerName = playerName;
            InitLists();
        }

        private void InitLists()
        {
            PlayerGhosts = new List<Cell>();
            Dungeon = new List<Cell>();
            ghostsOutside = new List<Cell>();
        }

        /// <summary>
        /// Inserts a new ghost to the player's ghost array
        /// </summary>
        /// <param name="position"> 
        /// Position in the gameBoard of the ghost
        /// </param>
        /// <param name="color">
        /// Color of the ghost
        /// </param>
        public void AppendGhost(Position position, CellColor color)
        {
            // Type that will be added to the array of ghosts
            CellType type = CellType.Ghost;

            for (int i = 0; i < PlayerGhosts.Count; i++)
            {
                if (PlayerGhosts[i] == null)
                {
                    PlayerGhosts[i] = new Cell(type, color, position);
                    break;
                }
            }
        }

        public void RemoveGhost(Position position, string placeArrayName)
        {
            int index;
            index = 0;
            for (int i = 0; i < PlayerGhosts.Count; i++)
            {
                if (PlayerGhosts[i].Position == position)
                    index = i;
            }
            if (placeArrayName == "Dungeon")
            {
                Dungeon[index] = PlayerGhosts[index];
                PlayerGhosts[index].Position.x = 6;
            }
            else if (placeArrayName == "Outside")
            {
                ghostsOutside[index] = PlayerGhosts[index];
                PlayerGhosts[index].Position.x = 7;
            }
        }

        /// <summary>
        /// Class to get a color from player input
        /// </summary>
        /// <returns> Returns a Color of type CellColor</returns>
        public CellColor PickColor()
        {
            // Color and player input
            CellColor color;
            int playerColor;

            // Ask the color and get the input
            Console.WriteLine("What color of ghost do you want to place? " +
                "red: 1, blue: 2, yellow: 3");
            playerColor = Convert.ToInt32(Console.ReadLine());

            // Compare and return the corresponding color
            if (playerColor == 1 && rNum < 3)
            {
                color = CellColor.Red;
                rNum++;
                Console.WriteLine("Red Ghosts placed: {0}", rNum);
                return color;
            }
            else if (playerColor == 2 && bNum < 3)
            {
                color = CellColor.Blue;
                bNum++;
                Console.WriteLine("Blue Ghosts placed: {0}", bNum);
                return color;
            }
            else if (playerColor == 3 && yNum < 3)
            {
                color = CellColor.Yellow;
                yNum++;
                Console.WriteLine("Yellow Ghosts placed: {0}", yNum);
                return color;
            }
            else
            {
                Console.WriteLine("Pick a valid color or " +
                    "one that still has ghosts for you to place.");
                return PickColor();
            }
        }

        public int PickAction()
        {
            int action;

            action = Convert.ToInt32(Console.ReadLine());
            return action;
        }



        public Position GetPosition(Board board)
        {
            // Return position, player input number and cell number vars
            int inputIndex;

            // Get a number between 1 and 9 from the player
            inputIndex = Convert.ToInt32(Console.ReadLine());

            // Force it to be between 1 and 9
            inputIndex = Math.Clamp(inputIndex, 1, 9);
            int cellIndex = 0;
            // get the corresponding position
            for (int i = 0; i < board.boardState.GetLength(1); i++)
            {
                for (int j = 0; j < board.boardState.GetLength(0); j++)
                {
                    foreach (Cell ghost in PlayerGhosts)
                    {
                        if (ghost.Position.x == i && ghost.Position.y == j)
                            cellIndex++;

                        if (cellIndex == inputIndex)
                            return new Position(i, j);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets a a position with a user input from a number from 1 to 6
        /// <br>6 being the max number of empty cells in 
        /// any given moment of 1 color
        /// </summary>
        /// <param name="board">
        /// Board on where to get the position from
        /// </param>
        /// <param name="color">
        /// What color you want to search for in the board
        /// </param>
        /// <returns>
        /// Returns the position x,y of the cell chosen by the player
        /// </returns>
        public Position GetPosition(Board board, CellColor color)
        {
            // Return position, player input number and cell number vars
            Position cellPosition;
            int inputIndex;
            int cellIndex;

            // Get a number between 1 and 6 from the player
            inputIndex = Convert.ToInt32(Console.ReadLine());

            // Force it to be between 1 and 6
            inputIndex = Math.Clamp(inputIndex, 1, 6);
            cellIndex = 1;

            // get the corresponding position
            for (int i = 0; i < board.boardState.GetLength(0); i++)
            {
                for (int j = 0; j < board.boardState.GetLength(1); j++)
                {
                    // If the color is the same as the parameter and the cell
                    // is empty, add 1 to cellIndex
                    if (board.boardState[i, j].Color == color &&
                        board.boardState[i, j].Type == CellType.Empty)
                    {
                        // Check if the index is the same as the player input
                        if (inputIndex == cellIndex)
                        {
                            // Create a new position with the x,y coordinates
                            cellPosition = new Position(i, j);
                            return cellPosition;
                        }
                        cellIndex++;
                    }
                }
            }
            return null;
        }

        public void MoveGhost(Position position, Board board)
        {
            string moveInput;
            int indexInArray;

            indexInArray = PlayerGhosts.IndexOf
                (PlayerGhosts.Find(x => x.Position.x == position.x && x.Position.y == position.y));

           
            Console.WriteLine("What direction are you headed to?\n" +
                "w - up; a - left; s - down; d - right");
            moveInput = Console.ReadLine();

            switch (moveInput)
            {
                case ("w"):
                    if (PlayerGhosts[indexInArray].Position.x> 0)
                        PlayerGhosts[indexInArray].Position.x--;
                    break;
                case ("a"):
                    if (PlayerGhosts[indexInArray].Position.y > 0)
                        PlayerGhosts[indexInArray].Position.y--;
                    break;
                case ("s"):
                    if (PlayerGhosts[indexInArray].Position.x < 5)
                        PlayerGhosts[indexInArray].Position.x++;
                    break;
                case ("d"):
                    if (PlayerGhosts[indexInArray].Position.y < 5)
                        PlayerGhosts[indexInArray].Position.y++;
                    break;
                default:
                    break;
            }

            MirrorInteractionCheck(PlayerGhosts[indexInArray], board);
        }

        public void MirrorInteractionCheck(Cell cell, Board board)
        {
            Position m1 = board.boardState[1, 1].Position;
            Position m2 = board.boardState[1, 3].Position;
            Position m3 = board.boardState[3, 1].Position;
            Position m4 = board.boardState[3, 3].Position;

            if (cell.Position.x == m1.x && cell.Position.y == m1.y)
                cell.Position = MirrorChoice(m1, m2, m3, m4);
            else if (cell.Position.x == m2.x && cell.Position.y == m2.y)
                cell.Position = MirrorChoice(m2, m1, m3, m4);
            else if (cell.Position.x == m3.x && cell.Position.y == m3.y)
                cell.Position = MirrorChoice(m3, m1, m2, m4);
            else if (cell.Position.x == m4.x && cell.Position.y == m4.y)
                cell.Position = MirrorChoice(m4, m1, m2, m3);
        }

        private Position MirrorChoice(Position mirrorEntered, Position mirror1,
            Position mirror2, Position mirror3)
        {
            int choiceInput;
            Position newDestination = new Position();

            Console.WriteLine($"Choose the position of the Mirror room you" +
                $"to move to:\n(1 - ({mirror1.y}, {mirror1.x}); 2 - " +
                $"({mirror2.y}, {mirror2.x}); 3 - ({mirror3.y}, {mirror3.x})");

            choiceInput = Convert.ToInt32(Console.ReadLine());

            switch (choiceInput)
            {
                case (1):
                    newDestination.x = mirror1.x;
                    newDestination.y = mirror1.y;
                    break;
                case (2):
                    newDestination.x = mirror2.x;
                    newDestination.y = mirror2.y;
                    break;
                case (3):
                    newDestination.x = mirror3.x;
                    newDestination.y = mirror3.y;
                    break;
            }
            return newDestination;
        }
    }
}
