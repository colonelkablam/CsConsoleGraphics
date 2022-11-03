namespace consoleGraphicsDriver
{
    internal class Vector
    {
        double x;
        double y;

        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double GetX()
        {
            return x;
        }
        public double GetY()
        {
            return y;
        }
        public void SetX(double x)
        {
            this.x = x;
        }
        public void SetY(double y)
        {
            this.y = y;
        }
        public double Magnitude()
        {
            return (Math.Sqrt(x * x + y * y));
        }

        public void Reset()
        {
            x = 0;
            y = 0;  
        }
        public void Add(Vector a)
        {
            this.x += a.x;
            this.y += a.y;
        }
        public static Vector Add (Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y);    
        }
        public static Vector Mult(Vector a, double num)
        {
            double tempX = a.x * num;
            double tempY = a.y * num;
            return new Vector(tempX, tempY);
        }
        public static double Magnitude(Vector a)
        {
            return Math.Sqrt(a.x * a.x + a.y * a.y);
        }
    }
}
