using System;
using System.Collections.Generic;
using System.Text;

using AwesomeAssertions;

using MartianRobots;

namespace Tests;

public class LostTests
{
    [Fact]
    public void LostIsInOutputWhenRobotLost()
    {
        var level = new Level(0, 0);

        var output = level.RunRobot(0, 0, Direction.North, "F");

        output.Should().Be("0 0 N LOST");
    }

    [Fact]
    public void FurtherCommandsAreNotRunAfterRobotIsLost()
    {
        var level = new Level(0, 0);

        var output = level.RunRobot(0, 0, Direction.North, "FLLF");

        output.Should().Be("0 0 N LOST");
    }
}

