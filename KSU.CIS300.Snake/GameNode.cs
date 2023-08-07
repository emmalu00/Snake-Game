/* 
 * GameNode.cs
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
    /// Information stored at this node. 
    /// </summary>
    public enum GridData 
    {
        Empty, 
        SnakeHead, 
        SnakeBody,
        SnakeFood
    }

    /// <summary>
    /// This class is a simple object that serves as a 
    /// node in the graph that represents the game board. 
    /// </summary>
    public class GameNode
    {
        /// <summary>
        /// The y-coordinate for this node.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The x-coordinate for this node.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Stores the information at this node.
        /// </summary>
        public GridData Data { get; set; }

        /// <summary>
        /// Represents a connection in the
        /// graph to another GameNode.
        /// </summary>
        public GameNode SnakeEdge { get; set; }

        /// <summary>
        /// Default constructor that sets
        /// the x-y coordinate properties.
        /// </summary>
        /// <param name="x"> Given x-coordinate. </param>
        /// <param name="y"> Given y-coordinate. </param>
        public GameNode(int x, int y)
        {
            Y = y;
            X = x;
        }

        /// <summary>
        /// Returns the nodes information as a string.
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            string newString = Data + ": " + "(" + X + ", " + Y + ")";
            return newString;
        }

    }
}
