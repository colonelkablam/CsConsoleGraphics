using System.Diagnostics;

namespace consoleGraphicsDriver
{
    internal class Program
    {
        static int winW = Console.WindowWidth - 5;
        static int winH = Console.WindowHeight - 2;

        static public int GetWinH()
        {
            return winH;
        }
        static public int GetWinW()
        {
            return winW;
        }
        static void Main(string[] args)
        {
            bool gameLoop = true;

            Vector gravity = new Vector(0, 0.01);
            Vector wind = new Vector(0.001, 0);

            // make a blob objects
            Point[] blobs = new Point[10];
            Random r = new Random();
            for (int i = 0; i < blobs.Length; i++)
            {
                double xV = r.Next(5, Console.WindowWidth - 5);
                double yV = r.Next(1, Console.WindowHeight - Console.WindowHeight / 2);
                blobs[i] = new Point(xV, yV, $"{i}");
            }

            // make a square obj
            Square block1 = new Square(40, 5, "#", 6, 3, true);
            Square block2 = new Square(20, 5, "@", 7, 4, false);

            // initialise screen
            Screen.InitiateDisplay(".", "/");

            //Stopwatch stopwatch = Stopwatch.StartNew();

            while (gameLoop)
            {

                Screen.ResetScreenArray();
                for (int i = 0; i < blobs.Length; i++)
                {
                    blobs[i].Update(gravity, wind);
                    blobs[i].HitWalls(winW, winH - 2);
                    blobs[i].Show();
                    string dispData = Convert.ToString($"X:{Math.Round(blobs[i].GetX(), 2)} Y:{Math.Round(blobs[i].GetY(), 2)}");
                    Screen.messageLine(i, Convert.ToString(i), dispData);
                }

                block1.Update(gravity, wind);
                block1.HitWalls(winW, winH - 2);
                block1.Show();

                block2.Update(gravity, wind);
                block2.HitWalls(winW, winH - 2);
                block2.Show();

                Screen.ScreenArrayToConsoleString();
                Thread.Sleep(32); // pause main loop - approx 30fps

                gameLoop = true;

            }
        }   // end of main function


    }
}