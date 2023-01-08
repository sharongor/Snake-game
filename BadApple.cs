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
    internal class BadApple:Circle
    {
        public BadApple()
        {
        }
        public void bonus()
        {

            Setting.Score += Setting.Points; // increases the score for the game
            Setting.Speed += 5;
        }
        public void paint(object sender, PaintEventArgs e)// draw food
        {
            Graphics canvas = e.Graphics;
            canvas.FillEllipse(Brushes.Purple, new Rectangle(X * Setting.Width, Y * Setting.Height,
            Setting.Width, Setting.Height));
        }

        //BadApple inherites the Shape destructor

    }
}
