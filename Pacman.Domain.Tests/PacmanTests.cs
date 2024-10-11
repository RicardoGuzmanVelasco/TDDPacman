using FluentAssertions;

namespace Pacman.Domain.Tests;

public class PacmanTests
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

        result.Should().Be(Direction.None);
    }

    [Test]
    public void YouCan_Change_WherePacmanLooksTowards()
    {
        var sut = new Board();
        
        sut.PacmanLooksTowards(Direction.Up);
        
        sut.WhereIsPacmanLookingTowards.Should().Be(Direction.Up);
    }

    [Test]
    public void Pacman_Moves_WhenIsLookingTowardsSomewhere()
    {
        var sut = new Board();
        sut.PacmanLooksTowards(Direction.Up);
        
        sut.Tick();

        sut.WhereIsPacman.Should().NotBe((0, 0));
    }

    [Test]
    public void Pacman_Moves_Up()
    {
        var sut = new Board();
        sut.PacmanLooksTowards(Direction.Up);
        
        sut.Tick();

        sut.WhereIsPacman.X.Should().Be(0);
        sut.WhereIsPacman.Y.Should().BePositive();
    }
    
    [Test]
    public void Pacman_Moves_Down()
    {
        var sut = new Board();
        sut.PacmanLooksTowards(Direction.Down);
        
        sut.Tick();

        sut.WhereIsPacman.X.Should().Be(0);
        sut.WhereIsPacman.Y.Should().BeNegative();
    }
    
    [Test]
    public void Pacman_Moves_Left()
    {
        var sut = new Board();
        sut.PacmanLooksTowards(Direction.Left);
        
        sut.Tick();

        sut.WhereIsPacman.X.Should().BeNegative();
        sut.WhereIsPacman.Y.Should().Be(0);
    }
    
    [Test]
    public void Pacman_Moves_Right()
    {
        var sut = new Board();
        sut.PacmanLooksTowards(Direction.Right);
        
        sut.Tick();

        sut.WhereIsPacman.X.Should().BePositive();
        sut.WhereIsPacman.Y.Should().Be(0);
    }
}