using System;

namespace Voyage_Engine.Rendere_Engine.Vector
{
    public struct Vector2 // not implemented 
    {
        private float x;
        private float y;
        private float _magnitude; // not implemented 

        public float X => x;

        public float Y => y;

        public float Magnitude => _magnitude;

        public Vector2(float x , float y)
        {
            this.x = x;
            this.y = y;
            _magnitude = 1;
        }

        public static Vector2 Zero => new Vector2(0, 0);
        public static Vector2 One => new Vector2(1, 1);

        public static Vector2 Down => new Vector2(0, -1);
        
        public static Vector2 Up => new Vector2(0, 1);
        
        public static Vector2 Left => new Vector2(-1, 0);

        public static Vector2 Right => new Vector2(1, 0);
        
        public static Vector2 Add(Vector2 vectorOne, Vector2 vectorTwo)
        {
            var x = vectorOne.X + vectorTwo.X;
            var y = vectorOne.Y + vectorTwo.Y;

            return new Vector2(x, y);
        }

        public static float Distance(Vector2 pointA, Vector2 pointB)
        {
            var a = Math.Abs(pointA.X - pointB.X);
            var b = Math.Abs(pointA.Y - pointB.Y);

            return (float)Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }

        public static Vector2 Lerp(Vector2 pointA, Vector2 pointB, float t)
        {
            t = t > 1 ? 1 : t;
            t = t < 0 ? 0 : t;

            return new Vector2(
                pointA.x += (pointA.x - pointA.x) * t,
                pointA.y += (pointA.y - pointA.y) * t
            );
        }

        public static Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta)
        {
            float toVectorX = target.x - current.x;
            float toVectorY = target.y - current.y;

            float sqDist = toVectorX * toVectorX + toVectorY * toVectorY;

            if (sqDist == 0 || (maxDistanceDelta >= 0 && sqDist <= maxDistanceDelta * maxDistanceDelta))
                return target;

            float dist = (float)Math.Sqrt(sqDist);

            return new Vector2(current.x + toVectorX / dist * maxDistanceDelta,
                current.y + toVectorY / dist * maxDistanceDelta);
        }
        
        public static Vector2 operator+(Vector2 a, Vector2 b) { return new Vector2(a.x + b.x, a.y + b.y); }
        public static Vector2 operator-(Vector2 a, Vector2 b) { return new Vector2(a.x - b.x, a.y - b.y); }
        public static Vector2 operator*(Vector2 a, Vector2 b) { return new Vector2(a.x * b.x, a.y * b.y); }
        public static Vector2 operator/(Vector2 a, Vector2 b) { return new Vector2(a.x / b.x, a.y / b.y); }
        public static Vector2 operator-(Vector2 a) { return new Vector2(-a.x, -a.y); }
        public static Vector2 operator*(Vector2 a, float d) { return new Vector2(a.x * d, a.y * d); }
        public static Vector2 operator*(float d, Vector2 a) { return new Vector2(a.x * d, a.y * d); }
        public static Vector2 operator/(Vector2 a, float d) { return new Vector2(a.x / d, a.y / d); }
        
        public override string ToString()
        {
            return $" X:{X},Y:{Y} ";
        }
    }
}