using System.Diagnostics;

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
        Debug.Assert(towards != Direction.None);
        WhereIsLookingTowards = towards;
    }

    public void Move() => WhereIs += WhereIsLookingTowards.ToTuple();
}