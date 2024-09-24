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
        if(pacmanDirection != Direction.None)
            pacmanPosition = (35545, 98980);
    }

    public void PacmanLooksTowards(Direction towards)
    {
        pacmanDirection = towards;
    }
}