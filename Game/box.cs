using System;

namespace Game
{
    static class box
    {
        public static int width {get; private set;}
        public static int height {get; private set;}
        public static ConsoleColor boxColor {get; private set;}
        public static int score {get; set;}

        public static void SetParameters(int wid, int hei, ConsoleColor cc = ConsoleColor.White) //100, 40
        {
            width = wid;
            height = hei;
            boxColor = cc;
        }
        public static void UpdateScore()
        {
            Console.SetCursorPosition(width - 6, 1);
            Console.Write("score");
            Console.SetCursorPosition(width - 6, 3);
            Console.Write(score);
        }
        public static void Update()
        {
            Console.ForegroundColor = boxColor;
            Console.Write('╔');
            for (int i = 0; i < width; i++)
            {
                Console.Write('═');
                if(i == width - 11)
                    Console.Write('╤');
            }
            Console.Write('╗');

            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < height - 5; i++)
            {
                Console.WriteLine('║');
            }
            Console.WriteLine('╟');
            Console.WriteLine('║');
            Console.Write('╚');


            for (int i = 0; i < width; i++)
            {
                Console.Write('═');
                if(i == width - 11)
                    Console.Write('╧');
            }
            Console.Write('╝');

            for (int i = 1; i < height - 2; i++)
            {
                Console.SetCursorPosition(width - 9, i);
                Console.Write('│');
                if (i == height - 5)
                {
                    Console.SetCursorPosition(width - 9, ++i);
                    Console.Write('┤');
                }
            }

            for (int i = 1; i < height - 2; i++)
            {
                Console.SetCursorPosition(width + 2, i);
                Console.Write('║');
            }

            Console.SetCursorPosition(1, height - 4);
            for (int i = 0; i < width - 10; i++)
            {
                Console.Write('─');
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(2, height - 3);
            Console.Write("Click 'ESC' for exit. Use 'LEFT' and 'RIGHT' or 'A' and 'D' for move and 'ESCAPE' for fire.");
        }
    }
}
