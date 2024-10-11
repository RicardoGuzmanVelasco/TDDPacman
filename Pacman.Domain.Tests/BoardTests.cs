using FluentAssertions;
using static Pacman.Domain.Tests.Direction;

namespace Pacman.Domain.Tests;

//movimiento circular.
//obstáculos.

public class BoardTests
{
    [Test]
    public void Pacman_IsAt_ZeroZero()
    {
        var sut = new Board();
        
        var result = sut.WhereIsPacman;
        
        result.Should().Be(Coord.Zero);
    }
    
    [Test]
    public void Pacman_StillsAt_ZeroZero()
    {
        var sut = new Board();

        sut.Tick();
        sut.Tick();
        sut.Tick();
        sut.Tick();
        
        sut.WhereIsPacman.Should().Be(Coord.Zero);
    }

    [Test]
    public void Pacman_DoesNotLooksTowards_AnyDirection_ByDefault()
    {
        var sut = new Board();

        var result = sut.WhereIsPacmanLookingTowards;

        result.Should().Be(None);
    }

    [Test]
    public void YouCan_Change_WherePacmanLooksTowards()
    {
        var sut = new Board();
        
        sut.PacmanLooksTowards(Up);
        
        sut.WhereIsPacmanLookingTowards.Should().Be(Up);
    }

    [Test]
    public void Pacman_Moves_WhenIsLookingTowardsSomewhere()
    {
        var sut = new Board();
        sut.PacmanLooksTowards(Up);
        
        sut.Tick();

        sut.WhereIsPacman.Should().NotBe((0, 0));
    }

    [Test]
    public void Pacman_Moves_Up()
    {
        var sut = new Board();
        sut.PacmanLooksTowards(Up);
        
        sut.Tick();

        sut.WhereIsPacman.X.Should().Be(0);
        sut.WhereIsPacman.Y.Should().BePositive();
    }
    
    [Test]
    public void Pacman_Moves_Down()
    {
        var sut = new Board();
        sut.PacmanLooksTowards(Down);
        
        sut.Tick();

        sut.WhereIsPacman.X.Should().Be(0);
        sut.WhereIsPacman.Y.Should().BeNegative();
    }
    
    [Test]
    public void Pacman_Moves_Left()
    {
        var sut = new Board();
        sut.PacmanLooksTowards(Left);
        
        sut.Tick();

        sut.WhereIsPacman.X.Should().BeNegative();
        sut.WhereIsPacman.Y.Should().Be(0);
    }
    
    [Test]
    public void Pacman_Moves_Right()
    {
        var sut = new Board();
        sut.PacmanLooksTowards(Right);
        
        sut.Tick();

        sut.WhereIsPacman.X.Should().BePositive();
        sut.WhereIsPacman.Y.Should().Be(0);
    }

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
        new Board(40, 1).WhereHasExistsTheBounds((-21, 0)).Should().Be(Left);
        new Board(40, 1).WhereHasExistsTheBounds((21, 0)).Should().Be(Right);
        new Board(1, 40).WhereHasExistsTheBounds((0, 21)).Should().Be(Up);
        new Board(1, 40).WhereHasExistsTheBounds((0, -21)).Should().Be(Down);
    }
}