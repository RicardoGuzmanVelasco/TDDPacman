namespace Pacman.Domain.Tests;

public readonly struct Tile
{
    public int X { get; }
    public int Y { get; }

    public Tile(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public static Tile Zero => new(0, 0);
    
    public Tile NextTo(Direction direction) => this + direction.ToTuple();
    
    public static Tile operator +(Tile a, Tile b) => new(a.X + b.X, a.Y + b.Y);
    public static Tile operator +(Tile a, (int x, int y) b) => new(a.X + b.x, a.Y + b.y);
}