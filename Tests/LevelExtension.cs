using System;
using System.Collections.Generic;
using System.Text;

using MartianRobots;

namespace Tests;

public static class LevelExtension
{
    extension(Level level)
    {
        public string RunRobot(int x, int y, Direction direction, string moves)
        {
            var robot = new Robot(level, x, y, direction);
            robot.Execute(moves.ToCharArray());
            return robot.GetState();
        }
    }
}
