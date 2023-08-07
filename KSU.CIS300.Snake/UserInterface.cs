/*
 * UserInterface.cs
 * Author: Emma Lucas
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace KSU.CIS300.Snake
{
    /// <summary>
    /// Creates a GUI for the snake game.
    /// </summary>
    public partial class uxSnakeGame : Form
    {
        /// <summary>
        /// Yhe calculated size of a game square 
        /// </summary>
        private int _squareWidth;

        /// <summary>
        ///  Width and height of the game in number of nodes/game squares.
        /// </summary>
        private int _size;

        /// <summary>
        /// Game object that gives the UI access to informing the game when
        /// the user has changed directions, as well as letting the game 
        /// inform the UI of the score and where the snake is.
        /// </summary>
        private Game _game;

        /// <summary>
        /// Initializes a new SolidBrush, giving the snake its color.
        /// </summary>
        private SolidBrush _bodyBrush = new SolidBrush(Color.SteelBlue); 
        
        /// <summary>
        /// Initializes a new SolidBrush, giving the food its color.
        /// </summary>
        private SolidBrush _foodBrush = new SolidBrush(Color.DarkOrange);

        /// <summary>
        /// Gives each snake square an outline.
        /// </summary>
        private Pen _pen = new Pen(Color.LightSteelBlue, 2);

        /// <summary>
        /// This field will allow the UserInterface to cancel or 
        /// stop the async StartMoving method in the Game class.
        /// </summary>
        private CancellationTokenSource _cancelSource = new CancellationTokenSource();

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public uxSnakeGame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This creates a new game with the given size and speed. 
        /// </summary>
        /// <param name="size"> Given size. </param>
        /// <param name="speed"> Given speed. </param>
        private void NewGame(int size, int speed)
        {
           
            _cancelSource.Cancel();
            _size = size;
            _game = new Game(size, speed);
            uxPictureBox.Height = 600;
            uxPictureBox.Width = 600;
            this.Size = new Size(630, 670);
            _squareWidth = uxPictureBox.Width / _size;
            uxScoreCount.DataBindings.Clear();
            uxScoreCount.DataBindings.Add("Text", _game, "Score");
            Progress<SnakeStatus> progress = new Progress<SnakeStatus>();
            progress.ProgressChanged += new EventHandler<SnakeStatus>(CheckProgress);
            _cancelSource = new CancellationTokenSource();
            _game.StartMoving(progress, _cancelSource.Token);
        }

        /// <summary>F
        /// Checks the progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="status"></param>
        private void CheckProgress(object sender, SnakeStatus status)
        {
            Refresh();
            if (status == SnakeStatus.Collision)
            {
                MessageBox.Show("Game over!");
            }
            else if (status == SnakeStatus.Win)
            {
                MessageBox.Show("Game Completed!");
            }
        }

        /// <summary>
        /// Event handler that will draw all of the game graphics. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (_game != null)
            {
                Graphics g = e.Graphics;
                List<GameNode> snake = new List<GameNode>();
                snake = _game.GetSnakePath();
                for (int i = 0; i < snake.Count; i++)
                {
                    Rectangle rect = new Rectangle(snake[i].X * _squareWidth, snake[i].Y * _squareWidth, _squareWidth, _squareWidth);
                    g.FillRectangle(_bodyBrush, rect);
                    g.DrawRectangle(_pen, rect);
                }
                GameNode food = _game.GetFood();
                if (food != null)
                {
                    Rectangle cir = new Rectangle(food.X * _squareWidth, food.Y * _squareWidth, _squareWidth, _squareWidth);
                    g.FillEllipse(_foodBrush, cir);
                }
            }
        }

        /// <summary>
        /// Click event handler for an easy level game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEasyGame_Click(object sender, EventArgs e)
        {
            NewGame(10, 250);
        }

        /// <summary>
        /// Click event handler for a normal level game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNormalGame_Click(object sender, EventArgs e)
        {
            NewGame(20, 150);
        }

        /// <summary>
        /// Click event handler for a hard level game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxHardGame_Click(object sender, EventArgs e)
        {
            NewGame(30, 100);
        }

        /// <summary>
        /// Key down event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSnakeGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                _game.MoveUp();
            }
            else if (e.KeyCode == Keys.Down)
            {
                _game.MoveDown();
            }
            else if (e.KeyCode == Keys.Left)
            {
                _game.MoveLeft();
            }
            else if (e.KeyCode == Keys.Right)
            {
                _game.MoveRight();
            }
            uxPictureBox.Refresh();
        }

        /// <summary>
        /// Preview key down event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSnakeGame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void uxNewGame_Click(object sender, EventArgs e)
        {
            NewGame(30, 100);
        }

    }
}
