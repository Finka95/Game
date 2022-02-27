using System;

namespace Game
{
    public struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public static Position operator +(Position a, Position b) => new Position(a.X + b.X, a.Y + b.Y);
        public static Position operator -(Position a, Position b) => new Position(a.X - b.X, a.Y - b.Y);

        public static bool operator ==(Position a, Position b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Position a, Position b) => a.X != b.X || a.Y != b.Y;

        public static Position AvatarStartPosition()
        {
            return new Position(box.width/2 - 10, box.height - 6);
        }

        public override string ToString()
        {
            return $"[{X}; {Y}]";
        }

        public override bool Equals(object obj)
        {
            if (obj is Position)
            {
                var pos = (Position)obj;
                return this.X == pos.X && this.Y == pos.Y;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
