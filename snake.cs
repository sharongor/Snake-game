using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    [Serializable]
    public class cordinates
    {
        public int X { get; set; } // this is a public int class called X
        public int Y { get; set; } // this is a public int class called Y

        public cordinates()
        {
            // this function is resetting the X and Y to 0
            X = 0;
            Y = 0;
        }
    }
    [Serializable]
    public class Snake
    {
        public List<cordinates> body { get; set; }
        public int size { get; set; }
        public void MovePlayer(bool pause, int maxXpos, int maxYpos)
        {
            // if the snake head is active 
            if (!pause)
            {

                for (int i = body.Count - 1; i >= 0; i--)
                {
                    // if the snake head is active 
                    if (i == 0)
                    {
                        // move rest of the body according to which way the head is moving
                        switch (Setting.direction)
                        {
                            case Directions.Right:
                                body[i].X++;
                                break;
                            case Directions.Left:
                                body[i].X--;
                                break;
                            case Directions.Up:
                                body[i].Y--;
                                break;
                            case Directions.Down:
                                body[i].Y++;
                                break;
                        }

                        // if the sanke hits the wall , it will pop out of the opposite direction
                        if (body[i].X < 0)
                        {
                            body[i].X = maxXpos;
                        }
                        if (body[i].X > maxXpos)
                        {
                            body[i].X = 0;
                        }
                        if (body[i].Y < 0)
                        {
                            body[i].Y = maxYpos;
                        }
                        if (body[i].Y > maxYpos)
                        {
                            body[i].Y = 0;
                        }

                        // detect collision with the body
                        // this loop will check if the snake had a collision with other body parts

                        for (int j = 1; j < body.Count; j++)
                        {
                            if (body[i].X == body[j].X && body[i].Y == body[j].Y)
                            {
                                // if so we run the die function
                                die();
                            }
                        }  
                    }
                    else
                    {
                        // if there are no collisions then we continue moving the snake and its parts
                        body[i].X = body[i - 1].X;
                        body[i].Y = body[i - 1].Y;
                    }
                }

            }
        }
        public void paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush snakeColour; // create a new brush called snake colour

            // run a loop to check the snake's parts
            for (int i = 0; i < body.Count; i++)
            {
                if (i == 0)
                {
                    // paint the head of the snake in Black
                    snakeColour = Brushes.Black;
                }
                else
                {
                    // the rest of the body will be Green
                    snakeColour = Brushes.Green;
                }
                //draw snake body and head
                canvas.FillEllipse(snakeColour, new Rectangle(body[i].X * Setting.Width, body[i].Y * Setting.Height,
                Setting.Width, Setting.Height));
            }
        }
        public Snake()
        {
            
        }
        public void startGame()
        {
            body = new List<cordinates>();
            cordinates head = new cordinates{ X = 10, Y = 5 }; // create a new head for the snake
            body.Add(head);
    }
        
        public void eat()//should be in snake class
        {
            // add a part to body

            cordinates sbody = new cordinates
            {
                X = body[body.Count - 1].X,
                Y = body[body.Count - 1].Y

            };
           body.Add(sbody); // add the part to the snakes array 
        }

        private void die()
        {
            // change the game over Boolean to true
            Setting.GameOver = true;
        }

        ~Snake()
        {
            cordinates head = null;
        }
    }   
}
