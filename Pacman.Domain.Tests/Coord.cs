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
}