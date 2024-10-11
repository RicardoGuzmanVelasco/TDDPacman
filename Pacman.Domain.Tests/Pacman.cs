namespace Pacman.Domain.Tests;

public class Pacman
{
    public Direction WhereIsLookingTowards { get; private set; }
    public Coord WhereIs { get; private set; }
    
    public static Pacman Spawn()
    {
        return new Pacman
        {
            WhereIs = Coord.Zero,
            WhereIsLookingTowards = Direction.None
        };
    }
}