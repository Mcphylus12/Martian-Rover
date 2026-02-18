using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots;

public class Robot
{
    private Level _level;
    private int _xPosition;
    private int _yPosition;
    private Direction _direction;

    public Robot(Level level, int xPos, int yPos, Direction direction)
    {
        _level = level;
        _xPosition = xPos;
        _yPosition = yPos;
        _direction = direction;
    }

    /// <summary>
    /// Built on the assumption all commands including future unknown ones are a single char.
    /// 
    /// </summary>
    public void Execute(char[] chars)
    {
        throw new NotImplementedException();
    }

    public string GetState()
    {
        throw new NotImplementedException();
    }
}

public enum Direction
{
    North,
    East,
    South,
    West
}