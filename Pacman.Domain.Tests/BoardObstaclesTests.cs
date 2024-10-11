using FluentAssertions;

namespace Pacman.Domain.Tests;

public class BoardObstaclesTests
{
    [Test]
    public void Moves_IfNotBlocked()
    {
        var sut = Board.Start();
        sut.Block(new Coord(2, 2)); //api!!! 
        
        sut.Tick();

        sut.WhereIsPacman.Should().NotBe(Coord.Zero);
    }
}