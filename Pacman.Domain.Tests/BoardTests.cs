using FluentAssertions;
using static Pacman.Domain.Tests.Direction;

namespace Pacman.Domain.Tests;

// comprobar que se mueve hacia la dirección que queremos.

public class BoardTests
{
    [Test]
    public void Pacman_IsAt_ZeroZero()
    {
        var sut = new Board();
        
        var result = sut.WhereIsPacman();
        
        result.Should().Be((0, 0));
    }
    
    [Test]
    public void Pacman_StillsAt_ZeroZero()
    {
        var sut = new Board();

        sut.Tick();
        sut.Tick();
        sut.Tick();
        sut.Tick();
        
        sut.WhereIsPacman().Should().Be((0, 0));
    }

    [Test]
    public void Pacman_DoesNotLooksTowards_AnyDirection_ByDefault()
    {
        var sut = new Board();

        var result = sut.WhereIsPacmanLookingTowards();

        result.Should().Be(None);
    }

    [Test]
    public void YouCan_Changes_WherePacmanLooksTowards()
    {
        var sut = new Board();
        
        sut.PacmanLooksTowards(Up);
        
        sut.WhereIsPacmanLookingTowards().Should().Be(Up);
    }

    [Test]
    public void Pacman_Moves_WhenIsLookingTowardsSomewhere()
    {
        var sut = new Board();
        sut.PacmanLooksTowards(Up);
        
        sut.Tick();

        sut.WhereIsPacman().Should().NotBe((0, 0));
    }

    [Test]
    public void Pacman_Moves_Up()
    {
        var sut = new Board();
        sut.PacmanLooksTowards(Up);
        
        sut.Tick();

        sut.WhereIsPacman().x.Should().Be(0);
        sut.WhereIsPacman().y.Should().BePositive();
    }
    
    [Test]
    public void Pacman_Moves_Down()
    {
        var sut = new Board();
        sut.PacmanLooksTowards(Down);
        
        sut.Tick();

        sut.WhereIsPacman().x.Should().Be(0);
        sut.WhereIsPacman().y.Should().BeNegative();
    }
}