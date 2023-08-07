/*
 * Game.cs
 * Author: Emma Lucas
 * 
 */

using System;
using System.Threading; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace KSU.CIS300.Snake
{
    /// <summary>
    /// Maintain the status of the game and manage moving 
    /// the snake based off the key presses given by the UI.  
    /// </summary>
    public class Game : INotifyPropertyChanged
    {
        /// <summary>
        /// Keeps track of how many points a player has.
        /// </summary>
        private int _score;

        /// <summary>
        /// Indicates how many milliseconds the game should
        /// wait before ticks. It contols how fast the 
        /// snake moves. 
        /// </summary>
        private int _delay;


        /// <summary>
        /// Stores whether the game is currently being played.
        /// </summary>
        public bool Play { get; set; }

        /// <summary>
        /// Returns the private score field.
        /// </summary>
        public int Score 
        { 
            get 
            { 
                return _score; 
            }
            set
            {
                if (_score != value)
                {
                    _score = value;
                    OnPropertyChanged("Score");
                }
            }
        }

        /// <summary>
        /// The reference to the GameBoard object that that contains
        /// the logic for moving the snake on the graph.
        /// </summary>
        public GameBoard Board { get; private set; }

        /// <summary>
        /// The size of the game to create.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// The last direction that the snake successfully moved.
        /// </summary>
        public Direction LastDirection { get; set; }

        /// <summary>
        /// The most recent direction reported by the UI.
        /// </summary>
        public Direction KeyPress { get; private set; }

        /// <summary>
        /// The current status of the snake.
        /// </summary>
        public SnakeStatus Status { get; private set; }

        /// <summary>
        /// Part of implementing the above interface.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructor for the game class.
        /// </summary>
        /// <param name="size"> Size of the snake. </param>
        /// <param name="speed"> Speed of the snake. </param>
        public Game(int size, int speed)
        {
            Size = 30;
            Board = new GameBoard(30);
            _score = 2;
            Play = true;
            Board.MoveSnake(Direction.Up);
            _delay = 100;
        }

        /// <summary>
        /// Asynchronous method that acts as a game clock. 
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="cancelToken"></param>
        /// <returns></returns>
        public async Task StartMoving(IProgress<SnakeStatus> progress, CancellationToken cancelToken)
        {
            while (Play && !cancelToken.IsCancellationRequested)
            {
                Status = Board.MoveSnake(KeyPress);
                progress.Report(Status);
                if (Status == SnakeStatus.Collision)
                {
                    Play = false;
                }
                else if (Status == SnakeStatus.Moving)
                {
                    LastDirection = KeyPress;
                }
                else if (Status == SnakeStatus.Eating)
                {
                    Score++;
                }
                else if (Status == SnakeStatus.InvalidDirection)
                {
                    Status = Board.MoveSnake(LastDirection);
                    progress.Report(Status);
                    if (Status == SnakeStatus.Collision)
                    {
                        Play = false;
                    }
                    else if (Status == SnakeStatus.Eating)
                    {
                        Score++;
                    }
                }
                else if (Status == SnakeStatus.Win)
                {
                    Score++;
                    Play = false;
                }
                await Task.Delay(_delay);
            }
            // To add the AI control, add a check at the beginning
            // of the loop to see if the AI is enabled, if so,
            // override the KeyPress value with the next direction
            // in the path queue.  Once the move has been made,
            // add this direction back to the queue.
        }

        /// <summary>
        /// Property changed event with the appropriate property.
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Returns the result of the GetSnakePath method contained
        /// in the GameBoard class.
        /// </summary>
        /// <returns></returns>
        public List<GameNode> GetSnakePath()
        {
            return Board.GetSnakePath();
        }

        /// <summary>
        /// Returns the food property of the game board.
        /// </summary>
        /// <returns></returns>
        public GameNode GetFood()
        {
            if (Status == SnakeStatus.Win)
            {
                return null;
            }
            return Board.Food;
        }

        /// <summary>
        /// Sets the key press field to be the up direction.
        /// </summary>
        public void MoveUp()
        {
            KeyPress = Direction.Up;
        }

        /// <summary>
        /// Sets the key press field to be the down direction.
        /// </summary>
        public void MoveDown()
        {
            KeyPress = Direction.Down;
        }

        /// <summary>
        /// Sets the key press field to be the left direction.
        /// </summary>
        public void MoveLeft()
        {
            KeyPress = Direction.Left;
        }

        /// <summary>
        /// Sets the key press field to be the right direction.
        /// </summary>
        public void MoveRight()
        {
            KeyPress = Direction.Right;
        }
    }
}
