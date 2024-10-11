using System.Diagnostics;

namespace Pacman.Domain.Tests;

public class Board
{
    readonly Size size;
    
    public Direction WhereIsPacmanLookingTowards { get; private set; } = Direction.None;
    public Coord WhereIsPacman { get; private set; } = Coord.Zero;

    public Board() { }
    public Board(int cols, int rows) : this(new Size(rows, cols)) { }
    public Board(Size size) { this.size = size; }


    public void Tick()
    {
        MovePacman();
    }

    void MovePacman()
    {
        if (WhereIsPacmanLookingTowards == Direction.None)
            return;

        WhereIsPacman += WhereToMovePacmanTowards();
    }

    (int x, int y) WhereToMovePacmanTowards()
    {
        Debug.Assert(WhereIsPacmanLookingTowards != Direction.None);
        return WhereIsPacmanLookingTowards.ToTuple();
    }

    public void PacmanLooksTowards(Direction towards)
    {
        Debug.Assert(towards != Direction.None);
        WhereIsPacmanLookingTowards = towards;
    }

    public bool IsInsideTheBoard((int x, int y) position)
    {
        var isInsideHorizontal = Math.Abs(position.x) < size.DistanceFromCenterToHorizontalBound();
        var isInsideVertical = Math.Abs(position.y) < size.DistanceFromCenterToVerticalBound();
        return isInsideHorizontal && isInsideVertical;
    }

    public Direction WhereHasExistsTheBounds((int x, int y) position)
    {
        Debug.Assert(!IsInsideTheBoard(position));
        return position.ToDirection();
    }
}