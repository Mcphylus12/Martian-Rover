namespace MartianRobots;

internal class Robot
{
    private readonly Level _level;
    private Position _position;
    private bool _isLost;

    public Robot(Level level, int xPos, int yPos, Direction direction)
    {
        _level = level;
        _position = new Position(xPos, yPos, direction);

        if (!_level.IsValidPosition(_position))
        {
            // These could be immediately marked as lost but its not defined in the spec so im considering it an error
            throw new Exception("Cannot create robots out of bounds");
        }
    }

    /// <summary>
    /// Built on the assumption all commands including future unknown ones are a single char.
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
        switch (_position.Direction)
        {
            case Direction.North: _position.Direction = Direction.West; break;
            case Direction.West: _position.Direction = Direction.South; break;
            case Direction.South: _position.Direction = Direction.East; break;
            case Direction.East: _position.Direction = Direction.North; break;
        }
    }

    private void TurnRight()
    {
        switch (_position.Direction)
        {
            case Direction.North: _position.Direction = Direction.East; break;
            case Direction.West: _position.Direction = Direction.North; break;
            case Direction.South: _position.Direction = Direction.West; break;
            case Direction.East: _position.Direction = Direction.South; break;
        }
    }

    private void MoveForward()
    {
        var newPosition = _position.Copy();

        switch (_position.Direction)
        {
            case Direction.North: newPosition.Y++; break;
            case Direction.South: newPosition.Y--; break;
            case Direction.West: newPosition.X--; break;
            case Direction.East: newPosition.X++; break;
        }

        if (!_level.IsValidPosition(newPosition))
        {
            if (!_level.HasScent(_position))
            {
                _isLost = true;
                _level.AddScent(_position);
            }
        }
        else
        {
            _position = newPosition;
        }
    }

    public string GetState()
    {
        return $"{_position}{GetLostString()}";
    }

    private string GetLostString() => _isLost ? " LOST" : string.Empty;
}