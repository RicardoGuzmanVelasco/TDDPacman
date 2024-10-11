using FluentAssertions;

namespace Pacman.Domain.Tests;

public class BoardObstaclesTests
{
    [Test]
    public void Moves_IfNotBlocked()
    {
        var sut = Board.Start();
        sut.Block(sut.Corners);
        
        sut.Tick();

        sut.WhereIsPacman.Should().NotBe(Tile.Zero);
    }
}