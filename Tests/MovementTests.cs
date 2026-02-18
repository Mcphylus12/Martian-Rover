using AwesomeAssertions;

using MartianRobots;

namespace Tests;

public class MovementTests
{
    [Fact]
    public void MoveForward()
    {
        var level = new Level(0, 1);

        var output = level.RunRobot(0, 0, Direction.North, "F");

        output.Should().Be("0 1 N");
    }

    [Fact]
    public void TurnLeft()
    {
        var level = new Level(0, 0);

        var output = level.RunRobot(0, 0, Direction.North, "L");

        output.Should().Be("0 0 W");
    }

    [Fact]
    public void FullTurnLeft()
    {
        var level = new Level(0, 0);

        var output = level.RunRobot(0, 0, Direction.North, "LLLL");

        output.Should().Be("0 0 N");
    }

    [Fact]
    public void TurnRight()
    {
        var level = new Level(0, 0);

        var output = level.RunRobot(0, 0, Direction.North, "R");

        output.Should().Be("0 0 E");
    }

    [Fact]
    public void FullTurnRight()
    {
        var level = new Level(0, 0);

        var output = level.RunRobot(0, 0, Direction.North, "RRRR");

        output.Should().Be("0 0 N");
    }
}
