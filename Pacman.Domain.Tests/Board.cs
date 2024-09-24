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

    public bool IsInsideTheBoard((int x, int y) position)
    {
        var isInsideHorizontal = Math.Abs(position.x) < DistanceFromCenterToHorizontalBound();
        var isInsideVertical = Math.Abs(position.y) < DistanceFromCenterToVerticalBound();
        return isInsideHorizontal && isInsideVertical;
    }

    public Direction WhereHasExistsTheBounds((int x, int y) position)
    {
        Debug.Assert(!IsInsideTheBoard(position));
        
        if (position.x > 0)
            return Direction.Right;
        if (position.y > 0)
            return Direction.Up;
        if (position.x < 0)
            return Direction.Left;
        if (position.y < 0)
            return Direction.Down;

        throw new InvalidOperationException();
    }

    int DistanceFromCenterToVerticalBound() => size.rows / 2 + 1;
    int DistanceFromCenterToHorizontalBound() => size.cols / 2 + 1;
}