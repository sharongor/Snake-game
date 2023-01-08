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
    class Block:Shape
    {
        public bool checkIfEat(Snake s)// eating a block will terminate the game
        {
            if (s.body[0].X == X && s.body[0].Y == Y)
            {
                Setting.GameOver = true;
                return true;
            }
            return false;
        }

        public void paint(object sender, PaintEventArgs e)// draw food
        {
            Graphics canvas = e.Graphics;
            Rectangle fillRect = new Rectangle(X * Setting.Width, Y * Setting.Height,
                            Setting.Width, Setting.Height);

            canvas.FillEllipse(Brushes.Black, fillRect);
            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Black);

            // Create region for fill.
            Region fillRegion = new Region(fillRect);

            // Fill region to screen.
            e.Graphics.FillRegion(blueBrush, fillRegion);
        }

        //BadApple inherites the Shape destructor

    }
}
