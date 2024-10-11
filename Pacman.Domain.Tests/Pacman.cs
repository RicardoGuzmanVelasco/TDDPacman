using System.Diagnostics;

namespace Pacman.Domain.Tests;

public class Pacman
{
    public Direction WhereIsLookingTowards { get; private set; }
    public Tile WhereIs { get; private set; }
    
    public static Pacman Spawn()
    {
        return new Pacman
        {
            WhereIs = Tile.Zero,
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