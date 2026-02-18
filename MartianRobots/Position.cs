namespace MartianRobots;

public record struct Position(int X, int Y, Direction Direction)
{
    internal Position Copy() => new Position(X, Y, Direction);
    public override string ToString() => $"{X} {Y} {Direction.ToString()[0]}";
}