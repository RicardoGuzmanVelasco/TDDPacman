using FluentAssertions;

namespace Pacman.Domain.Tests;

public class BoardObstaclesTests
{
    [Test]
    public void Moves_IfNotBlocked()
    {
        var sut = Board.Start();
        sut.Block(sut.BottomLeft);
        sut.Block(sut.BottomRight);
        sut.Block(sut.TopLeft);
        sut.Block(sut.TopRight);
        
        sut.Tick();

        sut.WhereIsPacman.Should().NotBe(Coord.Zero);
    }
}