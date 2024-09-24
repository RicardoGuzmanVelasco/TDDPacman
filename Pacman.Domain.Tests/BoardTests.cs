using FluentAssertions;

namespace Pacman.Domain.Tests;

//dónde está pacman, existe pacman
//

public class BoardTests
{
    [Test]
    public void OurFirstTest()
    {
        var sut = new Board();
        
        var result = sut.WhereIsPacman();
        
        result.Should().Be((0, 0));
    }
}

public class Board
{
    public (int x, int y) WhereIsPacman()
    {
        return (0, 0);
    }
}