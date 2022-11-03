using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace consoleGraphicsDriver
{
    internal class Square : Point
    {
        bool fill;
        int width;
        int height;
        public Square(double x, double y, string letter, int width, int height, bool fill) : base(x, y, letter)
        {
            this.posV = new Vector(x, y);
            this.letter = letter;
            this.fill = fill;
            this.width = width;
            this.height = height;
            windCoef = 3;
        }

        public override void HitWalls(int winWidth, int winHeight)
        {
            if (posV.GetY() > (winHeight - height))
            {
                speedV.SetY(speedV.GetY() * bounceCoef);
                posV.SetY(winHeight - height);
            }
            else if ((int)posV.GetY() < 0)
            {
                speedV.SetY(speedV.GetY() * bounceCoef);
                posV.SetY(0);
            }

            if ((int)posV.GetX() > winWidth - width)
            {
                speedV.SetX(speedV.GetX() * bounceCoef);
                posV.SetX(winWidth - width);
            }
            else if ((int)posV.GetX() < 0)
            {
                speedV.SetX(speedV.GetX() * bounceCoef);
                posV.SetX(0);
            }
        }
        public override void Show()
        {
            Screen.DrawRect(letter, posV.GetX(), posV.GetY(), width, height, fill);
        }
    }
}
