/* 
 * GameBoard.cs
 * Author: Emma Lucas
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSU.CIS300.Snake
{
    /// <summary>
    /// Direction of the snake.
    /// </summary>
    public enum Direction
    {
        Up,
        Down, 
        Left,
        Right,
        None
    }

    /// <summary>
    /// Status of the snake.
    /// </summary>
    public enum SnakeStatus
    {
        Moving,
        InvalidDirection, 
        Eating,
        Collision,
        Win
    }

    /// <summary>
    /// Responsible for making the snake grow 
    /// or move into a new place on the board. 
    /// </summary>
    public class GameBoard
    {
        /// <summary>
        /// Returns the game node that contains the food.
        /// </summary>
        public GameNode Food { get; set; }

        /// <summary>
        /// Array for storing the nodes of the game baord.
        /// </summary>
        public GameNode[,] Grid { get; private set; }

        /// <summary>
        /// Maintains a reference to where the head of the
        /// snake is currently located.
        /// </summary>
        public GameNode Head { get; set; }

        /// <summary>
        /// Maintains a reference to where the tail of the
        /// snake is currently located.
        /// </summary>
        public GameNode Tail { get; set; }

        /// <summary>
        /// Keeps track of how big the snake is at any given
        /// time.
        /// </summary>
        public int SnakeSize { get; private set; }

        /// <summary>
        /// Keeps track of the dimension (n) of the board.
        /// </summary>
        private int _size;

        /// <summary>
        /// Array that contains all four possible directions
        /// to make it easier to find adjacent nodes to
        /// search when finding the shortest path in the 
        /// board.
        /// </summary>
        private Direction[] _aiDirection = new Direction[] { Direction.Up, Direction.Down, Direction.Left, Direction.Right};

        /// <summary>
        /// Contains the directions left and right.
        /// </summary>
        private Direction[] _leftRight = new Direction[] { Direction.Right, Direction.Left, };

        /// <summary>
        /// Contains the directions up and down.
        /// </summary>
        private Direction[] _upDown = new Direction[] { Direction.Up, Direction.Down }; 

        /// <summary>
        /// Initializes a new Random object.
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Constructor that initializes the game board of given size. 
        /// </summary>
        /// <param name="size"></param>
        public GameBoard(int size)
        {
            _size = size;
            Grid = new GameNode[_size, _size];
            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    Grid[x, y] = new GameNode(x, y);
                }
            }
            Grid[(_size / 2), (_size / 2)].Data = GridData.SnakeHead;
            Head = Tail = Grid[(_size / 2), (_size / 2)];
            SnakeSize = 1;
            AddFood();
        }

        /// <summary>
        /// Randomly places the snake food on the board. 
        /// </summary>
        public void AddFood()
        {
            bool check = false;
            while (!check)
            {
                int randX = _random.Next(_size);
                int randY = _random.Next(_size);
                GameNode snakeFood = Grid[randX, randY];
                if (snakeFood.Data == GridData.Empty)
                {
                    check = true;
                    snakeFood.Data = GridData.SnakeFood;
                    Food = snakeFood;
                }
                else
                {
                    check = false;
                }
            }
        }

        /// <summary>
        ///  Helper method that will return the node that would be 
        ///  next from current if were headed in the given direction. 
        /// </summary>
        /// <param name="dir"> Given direction. </param>
        /// <param name="current"> Current node. </param>
        /// <returns></returns>
        public GameNode GetNextNode(Direction dir, GameNode current)
        {
            if (dir == Direction.Up && current.Y - 1 >= 0)
            {
                return Grid[current.X, current.Y - 1];
            }
            else if (dir == Direction.Down && current.Y + 1 < _size)
            {
                return Grid[current.X, current.Y + 1];
            }
            else if (dir == Direction.Left && current.X - 1 >= 0)
            {
                return Grid[current.X - 1, current.Y];
            }
            else if (dir == Direction.Right && current.X + 1 < _size)
            {
                return Grid[current.X + 1, current.Y];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Main logic on how the snake moves through the game board.
        /// </summary>
        /// <param name="dir"> Given direction. </param>
        /// <returns></returns>
        public SnakeStatus MoveSnake(Direction dir)
        {
            GameNode nextNode = GetNextNode(dir, Head);
            if (nextNode == null)
            {
                return SnakeStatus.Collision;
            }
            if (nextNode.SnakeEdge == Head)
            {
                return SnakeStatus.InvalidDirection;
            }
            if (nextNode.Data == GridData.SnakeBody)
            {
                return SnakeStatus.Collision;
            }
            GridData data = nextNode.Data;
            nextNode.Data = GridData.SnakeHead;
            Head.Data = GridData.SnakeBody;
            Head.SnakeEdge = nextNode;
            if (data == GridData.SnakeFood)
            {
                Head = nextNode;
                SnakeSize++;
                if (SnakeSize == Grid.Length)
                {
                    return SnakeStatus.Win;
                }
                AddFood();
                return SnakeStatus.Eating;
            }
            else
            {
                if (Head != Tail)
                {
                    Tail.Data = GridData.Empty;
                    GameNode gameNode = Tail.SnakeEdge;
                    Tail.SnakeEdge = null;
                    Tail = gameNode;
                }
                else
                {
                    SnakeSize++;
                }
                Head = nextNode;
                return SnakeStatus.Moving;
            }
        }

        /// <summary>
        /// Returns a list of game nodes that contain the snake starting from the tail.
        /// </summary>
        /// <returns></returns>
        public List<GameNode> GetSnakePath()
        {
            List<GameNode> gameNodes = new List<GameNode>();
            GameNode temp = Tail;
            while (temp != null)
            {
                gameNodes.Add(temp);
                temp = temp.SnakeEdge;
            }
            return gameNodes;
        }

        private List<Direction> BuildPath(Dictionary<GameNode, (GameNode, Direction)> path, GameNode dest)
        {
            throw new NotImplementedException();
        }

        public List<Direction> FindShortestAiPath(GameNode dest)
        {
            throw new NotImplementedException();
        }

        public Queue<Direction> FindLongestAiPath()
        {
            throw new NotImplementedException();
        }
    }
}
