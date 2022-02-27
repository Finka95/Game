using System;
using System.Timers;

namespace Game
{
    static class GameWorld
    {
        private static Timer timer;
        private static double interval = 1000;
        public static Enemy[] enemies = new Enemy[40];

        public static int Level {get; private set;}
        private static char enemy;
        private static Position enemiesCorner = new Position((int)Math.Floor(box.width * 0.25), 4);
        private static char[] enemy_CharArray = { '◯', '▽', '●', '▼' };

        public static void SetLevel(int level = 1)
        {
            enemy = enemy_CharArray[level];
            //timer = new Timer(interval * level);
            //timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            //timer.Enabled = true;
            UpdateWorld(enemiesCorner);
        }

        public static void UpdateWorld(Position pos)
        {
            Position startPosition = pos;
            int posIndex = default;
            for (int i = 0; i < enemies.Length; i++)
            {
                if (i % 10 == 0 && i != 0)
                {
                    if (i % 20 != 0)
                        pos.X += 2;
                    else
                        pos.X -= 2;
                    pos.Y += 3;
                    posIndex = 0;
                }
                enemies[i] = new Enemy(pos + new Position(4 * posIndex, 0), enemy);
                enemies[i].Show();
                posIndex++;
            }

            enemiesCorner = startPosition;
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            UpdateWorld(new Position(enemiesCorner.X + 2, enemiesCorner.Y));
        }
    }

    class Enemy
    {
        public char enemy { get; private set; }
        public Position position { get; private set; }

        public Enemy(Position position, char enemy = '◯')
        {
            this.position = position;
            this.enemy = enemy;
        }

        public void EnemyMove(Move move)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(' ');

            if (move == Move.Left)
                position = new Position(position.X + 1, position.Y);
            else
                position = new Position(position.X - 1, position.Y);
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(enemy);
        }

        public void Show()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(enemy);
        }

        public void KillEnemy()
        {
            enemy = ' ';
            //добавить дым уничтожения
        }
    }
}
