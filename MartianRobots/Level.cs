using System.Reflection.Emit;

namespace MartianRobots;

public class Level
{
    private readonly int _maxX;
    private readonly int _maxY;
    // This is a tuple of ints rather than a position as scents do not consider direction when they are created or checked
    private readonly HashSet<(int, int)> _scents = new();

    public Level(int maxX, int maxY)
    {
        _maxX = maxX;
        _maxY = maxY;
    }

    internal void AddScent(Position position)
    {
        _scents.Add((position.X, position.Y));
    }

    internal bool HasScent(Position position)
    {
        return _scents.Contains((position.X, position.Y));
    }

    internal bool IsValidPosition(Position position)
    {
        return position.X >= 0 && position.X <= _maxX 
            && position.Y >= 0 && position.Y <= _maxY;
    }

    public string RunRobot(int x, int y, Direction direction, string moves)
    {
        var robot = new Robot(this, x, y, direction);
        robot.Execute(moves.ToCharArray());
        return robot.GetState();
    }
}
