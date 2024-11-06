namespace AdventOfCode;

public class Day_06 : BaseDay
{
    private readonly string input;

    public Day_06()
    {
        input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{SolvePartOne()}");

    public override ValueTask<string> Solve_2() => new($"{SolvePartTwo()}");



    public int SolvePartOne()
    {
        int[,] grid = new int[1000,1000];
        for(int i = 0; i < 1000; i++)
        {
            for(int j = 0; j < 1000; j++)
            {
                grid[i, j] = 0;
            }
        }
        var lines = input
            .Split('\n')
            .Where(line => line.Length > 0)
            .Select(line => {
                var command = Command.OFF;
                if (line.Contains("turn on "))
                {
                    line = line.Replace("turn on ", string.Empty);
                    command = Command.ON;
                }
                else if (line.Contains("toggle "))
                {
                    line = line.Replace("toggle ", string.Empty);
                    command = Command.TOGGLE;
                }
                else
                {
                    line = line.Replace("turn off ", string.Empty);
                }

                line = line.Replace(" through ", ",");
                var indexes = line.Split(",");

                var to = (Int32.Parse(indexes[0]), Int32.Parse(indexes[1]));
                var from = (Int32.Parse(indexes[2]), Int32.Parse(indexes[3]));

                return (command, to, from);
            });
        foreach (var line in lines)
        {
            for (int i = line.to.Item1; i <= line.from.Item1; i++)
            {
                for (int j = line.to.Item2; j <= line.from.Item2; j++)
                {
                    if (line.command.Equals(Command.ON))
                    {
                        grid[i, j] = 1;
                    }
                    else if (line.command.Equals(Command.OFF))
                    {
                        grid[i, j] = 0;
                    }
                    else if (line.command.Equals(Command.TOGGLE))
                    {
                        if (grid[i,j] == 0)
                        {
                            grid[i, j] = 1;
                        }
                        else
                        {
                            grid[i, j] = 0;
                        }
                    }
                }
            }
        }

        int numLightsOn = 0;
        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 1000; j++)
            {
                numLightsOn += grid[i, j];
            }
        }
        return numLightsOn;
    }

    public int SolvePartTwo()
    {
        int[,] grid = new int[1000, 1000];
        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 1000; j++)
            {
                grid[i, j] = 0;
            }
        }
        var lines = input
            .Split('\n')
            .Where(line => line.Length > 0)
            .Select(line => {
                var command = Command.OFF;
                if (line.Contains("turn on "))
                {
                    line = line.Replace("turn on ", string.Empty);
                    command = Command.ON;
                }
                else if (line.Contains("toggle "))
                {
                    line = line.Replace("toggle ", string.Empty);
                    command = Command.TOGGLE;
                }
                else
                {
                    line = line.Replace("turn off ", string.Empty);
                }

                line = line.Replace(" through ", ",");
                var indexes = line.Split(",");

                var to = (Int32.Parse(indexes[0]), Int32.Parse(indexes[1]));
                var from = (Int32.Parse(indexes[2]), Int32.Parse(indexes[3]));

                return (command, to, from);
            });
        foreach (var line in lines)
        {
            for (int i = line.to.Item1; i <= line.from.Item1; i++)
            {
                for (int j = line.to.Item2; j <= line.from.Item2; j++)
                {
                    if (line.command.Equals(Command.ON))
                    {
                        grid[i, j] += 1;
                    }
                    else if (line.command.Equals(Command.OFF))
                    {
                        if (grid[i,j] > 0)
                        {
                            grid[i, j] -= 1;
                        }
                    }
                    else if (line.command.Equals(Command.TOGGLE))
                    {
                        grid[i, j] += 2;
                    }
                }
            }
        }

        int totalBrightness = 0;
        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 1000; j++)
            {
                totalBrightness += grid[i, j];
            }
        }
        return totalBrightness;
    }
    enum Command
    {
        ON,
        OFF,
        TOGGLE
    }
}



