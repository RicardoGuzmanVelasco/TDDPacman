namespace Pacman.Domain.Tests;

public enum Direction
{
    None,
    Up,
    Left,
    Right,
    Down
}

public static class DirectionToTuple
{
    public static (int x, int y) ToTuple(this Direction direction)
    {
        return direction switch
        {
            Direction.None => (0, 0),
            Direction.Up => (0, 1),
            Direction.Down => (0, -1),
            Direction.Left => (-1, 0),
            Direction.Right => (1, 0),
            _ => throw new InvalidOperationException()
        };
    }
}