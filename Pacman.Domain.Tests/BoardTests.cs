using FluentAssertions;

namespace Pacman.Domain.Tests;

// se puede mover si mira hacia alguna dirección
//

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

        result.Should().Be(Direction.None);
    }

    [Test]
    public void YouCan_Changes_WherePacmanLooksTowards()
    {
        var sut = new Board();
        
        sut.PacmanLooksTowards(Direction.Up);
        
        sut.WhereIsPacmanLookingTowards().Should().Be(Direction.Up);
    }

    [Test]
    public void Pacman_MovesTowards_WhatItSees()
    {
        
    }
}