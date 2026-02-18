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
    private bool _isLost;

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
            if (_isLost)
            {
                return;
            }

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
            case Direction.West: _direction = Direction.North; break;
            case Direction.South: _direction = Direction.West; break;
            case Direction.East: _direction = Direction.South; break;
        }
    }

    private void MoveForward()
    {
        var newPosX = _xPosition;
        var newPosY = _yPosition;

        switch (_direction)
        {
            case Direction.North: newPosY++; break;
            case Direction.South: newPosY--; break;
            case Direction.West: newPosX--; break;
            case Direction.East: newPosX++; break;
        }

        if (!_level.IsValidPosition(newPosX, newPosY))
        {
            _isLost = true;
        }
        else
        {
            _xPosition = newPosX;
            _yPosition = newPosY;
        }
    }

    public string GetState()
    {
        return $"{_xPosition} {_yPosition} {_direction.ToString()[0]}{GetLostString()}";
    }

    private string GetLostString() => _isLost ? " LOST" : string.Empty;
}

public enum Direction
{
    North,
    East,
    South,
    West
}