using System;

namespace Game
{
    static class Menu
    {
        public static string help {get; private set;} = "Click 'ESC' for exit. Use 'LEFT' and 'RIGHT' or 'A' and 'D' for move and 'SPACE' for fire.";
        public static MenuStatus menuStatus {get; private set;}
        public static void Update()
        {
            Console.SetCursorPosition(2, box.height - 3);
            Console.Write(help);
        }
    }
}
