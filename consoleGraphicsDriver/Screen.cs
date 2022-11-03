namespace consoleGraphicsDriver

{
    class Screen
    {
        static int windowWidth;
        static int windowHeight;
        static string screenString;
        static string bottomString;
        static string[,] screenArray;
        static string[,] backgroundArray;


        static Screen()
        {
            windowWidth = Program.GetWinW();
            windowHeight = Program.GetWinH();
            screenArray = new string[windowWidth, windowHeight];
            backgroundArray = new string[windowWidth, windowHeight];
            screenString = "";
            bottomString = "";
        }
        public static void InitiateDisplay(string letter, string letter2)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Clear();

            // populate screen array with initial strings
            for (int j = 0; j < windowHeight; j++)
            {
                for (int i = 0; i < windowWidth; i++)
                {
                    if (j != windowHeight - 2)
                    {
                        screenArray[i, j] = letter;
                        backgroundArray[i, j] = letter;
                    }
                    else
                    {
                        screenArray[i, j] = letter2;
                        backgroundArray[i, j] = letter2;
                    }
                }
            }
        }   // end of InitDisplay function

        public static void DrawPoint(string letter, double x, double y)
        {
            int tempX = (int) Math.Round(x-0.1, 2);
            int tempY = (int) Math.Round(y-0.1, 2);
            screenArray[tempX, tempY] = letter;
        }
        public static void DrawRect(string letter, double x, double y, int width, int height, bool fill)
        {
            int tempX = (int)x;
            int tempY = (int)y;

           // screenArray[tempX, tempY] = letter;


            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (fill)
                    {
                        screenArray[tempX + i, tempY + j] = letter;
                    }
                    else if ((j == 0 || j == height - 1 || i == 0 || i == width - 1))
                    {
                        screenArray[tempX + i, tempY + j] = letter;
                    }
                }
            }
        }

        public static void ResetScreenArray()
        {
            // populate screen array with initial strings
            for (int j = 0; j < windowHeight - 1; j++)
            {
                for (int i = 0; i < windowWidth; i++)
                {
                    screenArray[i, j] = backgroundArray[i, j];
                }
            }
        }   // end of clear screen function

        public static void messageLine(int row, string letter, string data)
        {
            string message = $"{letter}: {data}";

            for (int i = 0; i < message.Length - 1; i++)
            {
                screenArray[i, 1 + row] = Convert.ToString(message[i]);
            }
        }
        public static void ScreenArrayToConsoleString()
        {
            // clear console area of existing output/buffer
            Console.Clear();
            // clear screenString ready to re-populate
            screenString = "";
            // populate empty screeString with contents of the array using nested loops
            for (int j = 0; j < windowHeight - 1; j++)
            {
                for (int i = 0; i < windowWidth; i++)
                {
                    screenString += screenArray[i, j];  // add new element from screen arr
                }

                screenString += "\n";   // add new line char at end of row


            }
            // display string
            Console.Write(screenString + bottomString);
            bottomString = $"display text >> {screenString.Length}";
        }
    }
}