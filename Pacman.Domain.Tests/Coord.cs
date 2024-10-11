namespace Pacman.Domain.Tests;

public readonly struct Coord
{
    public int Y { get; }
    public int X { get; }
    
    public Coord(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public static Coord Zero => new(0, 0);
}