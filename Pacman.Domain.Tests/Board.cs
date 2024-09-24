using System.Diagnostics;

namespace Pacman.Domain.Tests;

public class Board
{
    readonly (int rows, int cols) size = (2, 2);
    Direction pacmanDirection = Direction.None;
    (int x, int y) pacmanPosition = (0, 0);

    public Board() { }
    public Board(int cols, int rows)
    {
        Debug.Assert(rows > 0);
        Debug.Assert(cols > 0);
        size = (rows, cols);
    }

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

    public bool IsInsideTheBoard((int, int) position)
    {
        if(position == (0, 0))
            return true;
        return size == (2, 2);
    }
}