namespace Pacman.Domain.Tests;

public class Board
{
    Direction pacmanDirection = Direction.None;
    
    public (int x, int y) WhereIsPacman()
    {
        return (0, 0);
    }

    public Direction WhereIsPacmanLookingTowards()
    {
        return pacmanDirection;
    }

    public void Tick()
    {
        
    }

    public void PacmanLooksTowards(Direction towards)
    {
        pacmanDirection = towards;
    }
}