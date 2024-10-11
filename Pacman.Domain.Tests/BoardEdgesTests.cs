using FluentAssertions;

namespace Pacman.Domain.Tests;

public class BoardEdgesTests
{
    [Test]
    public void Edges_InOddSizes()
    {
        new Board(3, 3).TopLeft.Should().Be(new Coord(-1, 1));
        new Board(3, 3).TopRight.Should().Be(new Coord(1, 1));
        new Board(3, 3).BottomLeft.Should().Be(new Coord(-1, -1));
        new Board(3, 3).BottomRight.Should().Be(new Coord(1, -1));
    }
}