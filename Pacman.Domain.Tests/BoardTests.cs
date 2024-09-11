using FluentAssertions;

namespace Pacman.Domain.Tests;

public class BoardTests
{
    [Test]
    public void OurFirstTest()
    {
        true.Should().BeTrue();
        Assert.That(true, Is.True);
    }
}