using System.Diagnostics;

namespace consoleGraphicsDriver
{
    internal class Program
    {
        static int winW = Console.WindowWidth - 7;
        static int winH = Console.WindowHeight - 3;

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

            // make blob objects
            Point[] blobs = new Point[10];
            Random r = new Random();
            for (int i = 0; i < blobs.Length; i++)
            {
                double xPos = r.Next(5, winW - 5);
                double yPos = r.Next(1, winH - winH / 2);
                blobs[i] = new Point(xPos, yPos, $"{i}");
            }

            // make square objects
            Square[] blocks = new Square[6];
            for (int i = 0; i < blocks.Length; i++)
            {
                double xPos = r.Next(10, winW - 10);
                double yPos = r.Next(1, winH - winH / 2);
                int height = r.Next(3, 7);
                int width = height * 2;
                int fill = r.Next(0, 2);
                bool fillBool;
                if (fill == 0) { fillBool = false; }
                else { fillBool = true; }
                blocks[i] = new Square(xPos, yPos, Convert.ToString(i), width, height, fillBool);
            }

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
                for (int i = 0; i < blocks.Length; i++)
                {
                    blocks[i].Update(gravity, wind);
                    blocks[i].HitWalls(winW, winH - 2);
                    blocks[i].Show();
                }


                Screen.ScreenArrayToConsoleString();
                Thread.Sleep(32); // pause main loop - approx 30fps

                gameLoop = true;

            }
        }   // end of main function


    }
}