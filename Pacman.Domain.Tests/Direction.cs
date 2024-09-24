namespace Pacman.Domain.Tests;

public enum Direction
{
    None,
    Up,
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
            _ => throw new InvalidOperationException()
        };
    }
}