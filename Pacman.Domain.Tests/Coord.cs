namespace Pacman.Domain.Tests;

public readonly struct Coord
{
    public int X { get; }
    public int Y { get; }

    public Coord(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public static Coord Zero => new(0, 0);
    
    public static Coord operator +(Coord a, Coord b) => new(a.X + b.X, a.Y + b.Y);
    public static Coord operator +(Coord a, (int x, int y) b) => new(a.X + b.x, a.Y + b.y);
}