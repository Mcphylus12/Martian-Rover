using AwesomeAssertions;

using MartianRobots;

namespace Tests;

public class ScentTests
{
    [Fact]
    public void RobotDoesntFollowItsPredeccesorOffBasicEdge()
    {
        var level = new Level(0, 0);

        var robot1Output = level.RunRobot(0, 0, Direction.North, "F");
        var robot2Output = level.RunRobot(0, 0, Direction.North, "F");

        robot1Output.Should().Be("0 0 N LOST");
        robot2Output.Should().Be("0 0 N");
    }
}
