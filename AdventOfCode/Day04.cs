namespace AdventOfCode;

public class Day_04 : BaseDay
{
    private readonly string input;

    public Day_04()
    {
        input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{SolvePartOne()}");

    public override ValueTask<string> Solve_2() => new($"{SolvePartTwo()}");



    public int SolvePartOne()
    {
        return 0;
    }

    public int SolvePartTwo()
    {
        return 0;
    }
}

