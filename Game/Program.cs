using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            //var screenCenter = new Position((int)Math.Floor(width * 0.5), (int)Math.Floor(height * 0.5));
            //Avatar avatar = new Avatar(screenCenter);
            //Console.SetCursorPosition(avatar.position.X, avatar.position.Y);
            //Console.Write(avatar);

            box.SetParameters(110, 45, ConsoleColor.Blue);
            box.Update();
            box.UpdateScore();
            Avatar avatar = new Avatar(Position.AvatarStartPosition());
            GameWorld.SetLevel();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.D || key.Key == ConsoleKey.RightArrow)
                {
                    avatar.AvatarMove(Move.Left);
                }
                if (key.Key == ConsoleKey.A || key.Key == ConsoleKey.LeftArrow)
                {
                    avatar.AvatarMove(Move.Right);
                }
                if (key.Key == ConsoleKey.Spacebar)
                {
                    avatar.Fire();
                }
            }
        }
    }
}
