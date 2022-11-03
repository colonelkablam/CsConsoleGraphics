namespace consoleGraphicsDriver
{
    internal class Point
    {
        protected Vector posV;
        protected Vector speedV;
        protected Vector accV;

        protected double bounceCoef;
        protected double windCoef;
        protected double weight;

        protected string letter;    

        public Point(double x, double y,string letter)
        {
            this.letter = letter;

            posV = new Vector(x, y);
            accV = new Vector(0, 0);
            speedV= new Vector(0, 0);

            bounceCoef = -0.7;
            windCoef = 1.0;
        }

        public virtual void HitWalls(int winWidth, int winHeight)
        {
            if (posV.GetY() > winHeight)
            {
                speedV.SetY(speedV.GetY() * bounceCoef);
                posV.SetY(winHeight);
            }
            else if (posV.GetY() < 0)
            {
                speedV.SetY(speedV.GetY() * bounceCoef);
                posV.SetY(0);
            }

            if (posV.GetX() > winWidth)
            {
                speedV.SetX(speedV.GetX() * bounceCoef);
                posV.SetX(winWidth);
            }
            else if (posV.GetX() < 0)
            {
                speedV.SetX(speedV.GetX() * bounceCoef);
                posV.SetX(0);
            }

        }

        public void Update(Vector g, Vector wind)
        {
            accV.Reset();
            accV.Add(g);
            accV.Add(Vector.Mult(wind, windCoef));
            speedV.Add(accV);
            posV.Add(speedV);
            
        }

        public double GetSpeed()
        {
            return speedV.Magnitude();
        }
        public double GetX()
        {
            return posV.GetX();
        }
        public double GetY()
        {
            return posV.GetY();
        }
        public virtual void Show()
        {
            Screen.DrawPoint(letter, posV.GetX(), posV.GetY());
        }
    }
}
