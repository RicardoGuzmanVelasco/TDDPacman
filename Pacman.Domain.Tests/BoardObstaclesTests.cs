using FluentAssertions;
using static Pacman.Domain.Tests.Direction;

namespace Pacman.Domain.Tests;

public class BoardObstaclesTests
{
    [Test]
    public void Moves_IfNotBlocked()
    {
        var sut = Board.Start(3, 3);
        sut.Block(sut.Corners);
        
        sut.Tick();

        sut.WhereIsPacman.Should().NotBe(Tile.Zero);
    }

    [Test]
    public void CannotMove_IfTowardsBlocked()
    {
        var sut = Board.Start(3, 3);
        sut.Block(sut.WhereIsPacman.NextTo(Right));
        
        sut.Tick();
        
        sut.WhereIsPacman.Should().Be(Tile.Zero);
    }
}