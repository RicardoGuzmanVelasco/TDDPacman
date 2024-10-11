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

    public void LookTowards(Direction towards)
    {
        WhereIsLookingTowards = towards;
    }

    public void MoveTowards((int x, int y) towards)
    {
        WhereIs += towards;
    }
}