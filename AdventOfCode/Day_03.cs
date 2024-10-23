using System.Linq.Expressions;

namespace AdventOfCode;

public class Day_03 : BaseDay
{
    private readonly string input;

    public Day_03()
    {
        input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{SolvePartOne()}");

    public override ValueTask<string> Solve_2() => new($"{SolvePartTwo()}");



    public int SolvePartOne()
    {
        int xPos = 0; int yPos = 0;
        var houseList = new List<(int, int)>();
        foreach(char x in input)
        {
            switch (x)
            {
                case '^':
                    // north
                    yPos += 1;
                    break;
                case 'v':
                    yPos -= 1;
                    // south
                    break;
                case '>':
                    xPos += 1;
                    // east
                    break;
                case '<':
                    xPos -= 1;
                    // west
                    break;                
            }
            if (!houseList.Contains((xPos, yPos)))
            {
                houseList.Add((xPos, yPos));
            }
        }
        return houseList.Count;
    }

    public int SolvePartTwo()
    {
        int xPosSanta = 0; int yPosSanta = 0;
        int xPosRobot = 0; int yPosRobot = 0;
        var houseList = new List<(int, int)>();
        for(int i = 0; i < input.Length; i+=2)
        {
            switch (input[i])
            {
                case '^':
                    // north
                    yPosSanta += 1;
                    break;
                case 'v':
                    yPosSanta -= 1;
                    // south
                    break;
                case '>':
                    xPosSanta += 1;
                    // east
                    break;
                case '<':
                    xPosSanta -= 1;
                    // west
                    break;
            }
            if (i+1<input.Length)
            {
                switch (input[i+1])
                {
                    case '^':
                        // north
                        yPosRobot += 1;
                        break;
                    case 'v':
                        yPosRobot -= 1;
                        // south
                        break;
                    case '>':
                        xPosRobot += 1;
                        // east
                        break;
                    case '<':
                        xPosRobot -= 1;
                        // west
                        break;
                }
            }
            if (!houseList.Contains((xPosSanta, yPosSanta)))
            {
                houseList.Add((xPosSanta, yPosSanta));
            }
            if (!houseList.Contains((xPosRobot, yPosRobot)))
            {
                houseList.Add((xPosRobot, yPosRobot));
            }
        }
        return houseList.Count;
    }
}

