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
    public void Execute(char[] commands)
    {
        foreach (var command in commands)
        {
            switch(command)
            {
                case 'F': MoveForward(); break;
                case 'L': TurnLeft(); break;
                case 'R': TurnRight(); break;
            }
        }
    }

    private void TurnLeft()
    {
        switch (_direction)
        {
            case Direction.North: _direction = Direction.West; break;
            case Direction.West: _direction = Direction.South; break;
            case Direction.South: _direction = Direction.East; break;
            case Direction.East: _direction = Direction.North; break;
        }
    }

    private void TurnRight()
    {
        switch (_direction)
        {
            case Direction.North: _direction = Direction.East; break;
            case Direction.West: _direction = Direction.South; break;
            case Direction.South: _direction = Direction.West; break;
            case Direction.East: _direction = Direction.North; break;
        }
    }

    private void MoveForward()
    {
        switch (_direction)
        {
            case Direction.North: _yPosition++; break;
            case Direction.South: _yPosition--; break;
            case Direction.West: _xPosition--; break;
            case Direction.East: _xPosition++; break;
        }
    }

    public string GetState()
    {
        return $"{_xPosition} {_yPosition} {_direction.ToString()[0]}";
    }
}

public enum Direction
{
    North,
    East,
    South,
    West
}