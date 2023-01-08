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
    internal class GoodApple:Circle
    {
        public GoodApple()
        {
        }
        public void bonus(Snake S)
        {

            Setting.Score +=2* Setting.Points; // increases the score by double points for the game
            Setting.Speed = 20;
            S.eat();
        }
        public void paint(object sender, PaintEventArgs e)// drawing the food
        {
            Graphics canvas = e.Graphics;
            canvas.FillEllipse(Brushes.Red, new Rectangle(X * Setting.Width, Y * Setting.Height,
            Setting.Width, Setting.Height));
        }
        //BadApple inherites the Shape destructor

    }
}
