// See https://aka.ms/new-console-template for more information

using System.Text;

using MartianRobots;

if (args.Length != 1)
{
    Console.WriteLine("Supply one args with path to input file containing input");
    return 0;
}

var input = File.ReadAllLines(args[0]);


var parts = input[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
var level = new Level(int.Parse(parts[0]), int.Parse(parts[1]));

var output = new StringBuilder();

for (int i = 1; i < input.Length; i += 3)
{
    var position = input[i].Split(" ");
    var x = int.Parse(position[0]);
    var y = int.Parse(position[1]);
    var dir = position[2] switch
    {
        "N" => Direction.North,
        "E" => Direction.East,
        "S" => Direction.South,
        "W" => Direction.West,
    };

    var commands = input[i + 1];
    var robot = new Robot(level, x, y, dir);
    robot.Execute(commands.ToCharArray());
    output.AppendLine(robot.GetState());
}

Console.Write(output.ToString());

return 0;
