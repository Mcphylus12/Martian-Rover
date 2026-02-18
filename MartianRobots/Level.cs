using System.Reflection.Emit;

namespace MartianRobots;

public class Level
{
    private int _maxX;
    private int _maxY;
    private HashSet<(int, int)> _scents = new();

    public Level(int maxX, int maxY)
    {
        _maxX = maxX;
        _maxY = maxY;
    }

    internal void AddScent(int xPosition, int yPosition)
    {
        _scents.Add((xPosition, yPosition));
    }

    internal bool HasScent(int xPosition, int yPosition)
    {
        return _scents.Contains((xPosition, yPosition));
    }

    internal bool IsValidPosition(int posX, int posY)
    {
        return posX >= 0 && posX <= _maxX 
            && posY >= 0 && posY <= _maxY;
    }

    public string RunRobot(int x, int y, Direction direction, string moves)
    {
        var robot = new Robot(this, x, y, direction);
        robot.Execute(moves.ToCharArray());
        return robot.GetState();
    }
}
