using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    //this is the snake head class and the apple that the snake eats class
    [Serializable]
    public class Shape
    {
        public int X { get; set; } // this is a public int class called X
        public int Y { get; set; } // this is a public int class called Y
        private Random rnd = new Random(); // create a new random class;
        public Shape()
        {
            // this function is resetting the X and Y to 0
            X = 0;
            Y = 0;  
        }
        public void generateFood(int maxXpos, int maxYpos)// create a new food with a random x and y
        {
            rnd = new Random();
            X = rnd.Next(0, maxXpos);
            Y = rnd.Next(0, maxYpos); 
        }
        ~Shape()
        {
            X = 0;
            Y = 0;
        }
    }
}
