using AwesomeAssertions;

using MartianRobots;

namespace Tests;

public class SampleTest
{
    [Fact]
    public void SampleInput()
    {
        var level = new Level(5, 3);

        var robot1Output = RunRobot(level, 1, 1, Direction.East, "RFRFRFRF");
        var robot2Output = RunRobot(level, 3, 2, Direction.North, "FRRFLLFFRRFLL");
        var robot3Output = RunRobot(level, 0, 3, Direction.West, "LLFFFLFLFL");

        robot1Output.Should().Be("1 1 E");
        robot2Output.Should().Be("3 3 N LOST");
        robot3Output.Should().Be("2 3 S");
    }

    private static string RunRobot(Level level, int x, int y, Direction direction, string moves)
    {
        var robot = new Robot(level, x, y, direction);
        robot.Execute(moves.ToCharArray());
        return robot.GetState();
    }
}
