using System.Diagnostics;

namespace Pacman.Domain.Tests;

public class Board
{
    Direction pacmanDirection = Direction.None;
    (int x, int y) pacmanPosition = (0, 0);

    public (int x, int y) WhereIsPacman()
    {
        return pacmanPosition;
    }

    public Direction WhereIsPacmanLookingTowards()
    {
        return pacmanDirection;
    }

    public void Tick()
    {
        MovePacman();
    }

    void MovePacman()
    {
        if (pacmanDirection == Direction.None)
            return;

        var x = pacmanPosition.x + WhereToMovePacmanTowards().x;
        var y = pacmanPosition.y + WhereToMovePacmanTowards().y;
        pacmanPosition = (x, y);
    }

    (int x, int y) WhereToMovePacmanTowards()
    {
        Debug.Assert(WhereIsPacmanLookingTowards() != Direction.None);
        return WhereIsPacmanLookingTowards().ToTuple();
    }

    public void PacmanLooksTowards(Direction towards)
    {
        Debug.Assert(towards != Direction.None);
        pacmanDirection = towards;
    }
}