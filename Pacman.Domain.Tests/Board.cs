using System.Diagnostics;

namespace Pacman.Domain.Tests;

public class Board
{
    readonly Size size;
    readonly Pacman pacman = Pacman.Spawn();

    public Board() { }
    public Board(int cols, int rows) : this(new Size(rows, cols)) { }
    public Board(Size size) { this.size = size; }
    
    public Direction WhereIsPacmanLookingTowards => pacman.WhereIsLookingTowards;
    public Coord WhereIsPacman => pacman.WhereIs;
    public void PacmanLooksTowards(Direction towards) => pacman.LookTowards(towards);

    public void Tick()
    {
        pacman.Move();
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

    public void Block(Coord coord)
    {
        
    }
    
}