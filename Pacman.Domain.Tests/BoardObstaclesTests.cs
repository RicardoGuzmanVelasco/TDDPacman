using FluentAssertions;

namespace Pacman.Domain.Tests;

public class BoardObstaclesTests
{
    [Test]
    public void Moves_IfNotBlocked()
    {
        var sut = new Board();
        sut.PacmanLooksTowards(Direction.Up);
        sut.Block(new Coord(2, 2)); //api!!! API!!!!!!!!!!!!
        
        sut.Tick();

        sut.WhereIsPacman.Should().NotBe(Coord.Zero);
    }
}