using System.Diagnostics;

namespace Pacman.Domain.Tests;

public class Board
{
    readonly Size size;
    readonly Pacman pacman = Pacman.Spawn();

    public Board() { }
    public Board(int cols, int rows) : this(new Size(rows, cols)) { }
    public Board(Size size) { this.size = size; }

    public static Board Start()
    {
        var result = new Board();
        result.PacmanLooksTowards(Direction.Right);
        return result;
    }
    
    public Direction WhereIsPacmanLookingTowards => pacman.WhereIsLookingTowards;
    public Coord WhereIsPacman => pacman.WhereIs;

    public Coord TopLeft => new(-size.Cols / 2, size.Rows / 2);
    public Coord TopRight => new(size.Cols / 2, size.Rows / 2);
    public Coord BottomLeft => new(-size.Cols / 2, -size.Rows / 2);
    public Coord BottomRight => new(size.Cols / 2, -size.Rows / 2);

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

    public void Block(int x, int y) => Block(new Coord(x, y));
    public void Block(Coord coord)
    {
        
    }
}