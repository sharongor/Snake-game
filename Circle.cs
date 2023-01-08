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
    internal class Circle : Shape
    {

        public bool checkIfeat(Snake s, int maxXpos, int maxYpos)
        {
            if (s.body[0].X == X && s.body[0].Y == Y)
            {
                generateFood(maxXpos, maxYpos);
                //if so we run the eat function
                s.eat();
                return true;
            }
            return false;
        }
        public void paint(object sender, PaintEventArgs e)// draw food
        {
            Graphics canvas = e.Graphics;
            canvas.FillEllipse(Brushes.Yellow, new Rectangle(X * Setting.Width, Y * Setting.Height,
            Setting.Width, Setting.Height));
        }

        //Circle has the destructor of Shape
    }
}
