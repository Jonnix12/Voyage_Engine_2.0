using System;

namespace Voyage_Engine.Rendere_Engine.Vector;

/* 
 * This is our vector 2 class. We made it before changing the Render Engine to MonoGame engine.
 * The MonoGame engine is using their own vector 2 class so we decided to keep this class to show our work but we are not using in to get away with potential bugs
 */


public struct Vector2 // not implemented 
{
    public float X { get; private set; }

    public float Y { get; private set; }

    public float Magnitude { get; }

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
        Magnitude = 1;
    }

    public static Vector2 Zero => new(0, 0);
    public static Vector2 One => new(1, 1);

    public static Vector2 Down => new(0, -1);

    public static Vector2 Up => new(0, 1);

    public static Vector2 Left => new(-1, 0);

    public static Vector2 Right => new(1, 0);

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

        return (float) Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
    }

    public static Vector2 Lerp(Vector2 pointA, Vector2 pointB, float t)
    {
        t = t > 1 ? 1 : t;
        t = t < 0 ? 0 : t;

        return new Vector2(
            pointA.X += (pointA.X - pointA.X) * t,
            pointA.Y += (pointA.Y - pointA.Y) * t
        );
    }

    public static Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta)
    {
        var toVectorX = target.X - current.X;
        var toVectorY = target.Y - current.Y;

        var sqDist = toVectorX * toVectorX + toVectorY * toVectorY;

        if (sqDist == 0 || (maxDistanceDelta >= 0 && sqDist <= maxDistanceDelta * maxDistanceDelta))
            return target;

        var dist = (float) Math.Sqrt(sqDist);

        return new Vector2(current.X + toVectorX / dist * maxDistanceDelta,
            current.Y + toVectorY / dist * maxDistanceDelta);
    }

    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
        return new Vector2(a.X + b.X, a.Y + b.Y);
    }

    public static Vector2 operator -(Vector2 a, Vector2 b)
    {
        return new Vector2(a.X - b.X, a.Y - b.Y);
    }

    public static Vector2 operator *(Vector2 a, Vector2 b)
    {
        return new Vector2(a.X * b.X, a.Y * b.Y);
    }

    public static Vector2 operator /(Vector2 a, Vector2 b)
    {
        return new Vector2(a.X / b.X, a.Y / b.Y);
    }

    public static Vector2 operator -(Vector2 a)
    {
        return new Vector2(-a.X, -a.Y);
    }

    public static Vector2 operator *(Vector2 a, float d)
    {
        return new Vector2(a.X * d, a.Y * d);
    }

    public static Vector2 operator *(float d, Vector2 a)
    {
        return new Vector2(a.X * d, a.Y * d);
    }

    public static Vector2 operator /(Vector2 a, float d)
    {
        return new Vector2(a.X / d, a.Y / d);
    }

    public override string ToString()
    {
        return $" X:{X},Y:{Y} ";
    }
}