using System;
using System.Timers;
using System.Collections.Generic;
namespace Game
{
    class Avatar
    {
        public char avatar { get; private set; } = '▲';//'⍾';
        public Position position {get;private set;}
        public int lives {get; private set;}
        public List<Rocket> rockets;
        //private event KeyDown;

        public Avatar(Position pos)
        {
            position = pos;
            lives = 3;
            rockets = new List<Rocket>();
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write(avatar);
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);

        }

        public void SetPosition(Position position)
        {
            this.position = position;
        }

        public override string ToString()
        {
            return avatar.ToString();
        }

        public void AvatarMove(Move move)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(' ');

            if (move == Move.Left)
                position = new Position(position.X + 1, position.Y);
            else
                position = new Position(position.X - 1, position.Y);
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(avatar);
        }

        public void Fire()
        {
            rockets.Add(new Rocket(this));
        }

        public void Hit(Rocket rocket)
        {
            rockets.Remove(rocket);
        }
    }

    class Rocket
    {
        private Timer timer;
        private int level;
        public int speed { get; private set; }
        public char rocket { get; private set; }
        public Position position { get; private set; }

        private Avatar dadAvatar;

        public Rocket(Avatar ava, int lvl = 1)
        {
            speed = 200 / lvl;
            rocket = '▵';
            timer = new Timer(speed);
            timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            timer.Enabled = true;
            position = ava.position + new Position(0, -1);
            dadAvatar = ava;
            Show();
        }

        public void Move()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(' ');
            position = new Position(position.X, position.Y - 1);
            if(GameWorld.CheckEnemy(position))
                dadAvatar.Hit(this);
            Show();
        }

        public void Show()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(rocket);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Move();
        }
    }

    enum Move
    {
        Left,
        Right
    }
}
