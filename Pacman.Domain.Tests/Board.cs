using System.Diagnostics;

namespace Pacman.Domain.Tests;

public class Board
{
    readonly Size size;
    readonly Pacman pacman = Pacman.Spawn();

    public Board() { }
    public Board(int cols, int rows) : this(new Size(rows, cols)) { }
    public Board(Size size) { this.size = size; }

    public static Board Start(int x, int y)
    {
        var result = new Board(x, y);
        result.PacmanLooksTowards(Direction.Right);
        return result;
    }
    
    public Direction WhereIsPacmanLookingTowards => pacman.WhereIsLookingTowards;
    public Tile WhereIsPacman => pacman.WhereIs;

    public Tile TopLeft => new(-size.Cols / 2, size.Rows / 2);
    public Tile TopRight => new(size.Cols / 2, size.Rows / 2);
    public Tile BottomLeft => new(-size.Cols / 2, -size.Rows / 2);
    public Tile BottomRight => new(size.Cols / 2, -size.Rows / 2);
    public Tile[] Corners => new[] { TopLeft, TopRight, BottomLeft, BottomRight };

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

    public void Block(int x, int y) => Block(new Tile(x, y));
    public void Block(Tile tile)
    {
        
    }
    
    public void Block(params Tile[] tiles)
    {
        foreach (var tile in tiles)
            Block(tile);
    }
}