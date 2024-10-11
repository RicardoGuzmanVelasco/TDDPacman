using FluentAssertions;
using static Pacman.Domain.Tests.Direction;

namespace Pacman.Domain.Tests;

//movimiento circular.
//obstáculos.

public class BoardCoordsTests
{
    [Test]
    public void ZeroZero_IsInsideTheBoard()
    {
        var sut = new Board(1, 1);
        
        var result = sut.IsInsideTheBoard((0, 0));
        
        result.Should().BeTrue();
    }

    [Test]
    public void SomePosition_IsNotInsideTheBoard()
    {
        new Board(1, 1).IsInsideTheBoard((0, 1)).Should().BeFalse();
        new Board(1, 1).IsInsideTheBoard((1, 0)).Should().BeFalse();

        new Board(3, 3).IsInsideTheBoard((-2, 0)).Should().BeFalse();

        new Board(1, 1).IsInsideTheBoard((-1, 0)).Should().BeFalse();
        new Board(1, 1).IsInsideTheBoard((1, 0)).Should().BeFalse();
        new Board(1, 1).IsInsideTheBoard((0, 1)).Should().BeFalse();
        new Board(1, 1).IsInsideTheBoard((0, -1)).Should().BeFalse();
    }

    [Test]
    public void SomePosition_IsInsideTheBoard()
    {
        new Board(3, 3).IsInsideTheBoard((0, 1)).Should().BeTrue();
        new Board(3, 3).IsInsideTheBoard((1, 0)).Should().BeTrue();
        new Board(3, 3).IsInsideTheBoard((1, 1)).Should().BeTrue();

        new Board(3, 3).IsInsideTheBoard((-1, 0)).Should().BeTrue();
        new Board(3, 3).IsInsideTheBoard((0, -1)).Should().BeTrue();
        new Board(3, 3).IsInsideTheBoard((-1, -1)).Should().BeTrue();
    }

    [Test]
    public void WhereHasSomeCoord_ExistsTheBounds()
    {
        new Board(39, 1).WhereHasExistsTheBounds((-21, 0)).Should().Be(Left);
        new Board(39, 1).WhereHasExistsTheBounds((21, 0)).Should().Be(Right);
        new Board(1, 39).WhereHasExistsTheBounds((0, 21)).Should().Be(Up);
        new Board(1, 39).WhereHasExistsTheBounds((0, -21)).Should().Be(Down);
    }
}