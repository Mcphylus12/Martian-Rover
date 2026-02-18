using AwesomeAssertions;

using MartianRobots;

namespace Tests;

public class SampleTest
{
    [Fact]
    public void SampleInput()
    {
        var level = new Level(5, 3);

        var robot1Output = level.RunRobot(1, 1, Direction.East, "RFRFRFRF");
        var robot2Output = level.RunRobot(3, 2, Direction.North, "FRRFLLFFRRFLL");
        var robot3Output = level.RunRobot(0, 3, Direction.West, "LLFFFLFLFL");

        robot1Output.Should().Be("1 1 E");
        robot2Output.Should().Be("3 3 N LOST");
        robot3Output.Should().Be("2 3 S");
    }
}
