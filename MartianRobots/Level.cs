namespace MartianRobots;

public class Level
{
    private int _maxX;
    private int _maxY;

    public Level(int maxX, int maxY)
    {
        _maxX = maxX;
        _maxY = maxY;
    }

    internal bool IsValidPosition(int posX, int posY)
    {
        return posX >= 0 && posX <= _maxX 
            && posY >= 0 && posY <= _maxY;
    }
}
