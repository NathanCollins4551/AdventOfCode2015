namespace AdventOfCode;

public class Day_02 : BaseDay
{
    private readonly string _input;

    public Day_02()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{SolvePartOne()}");

    public override ValueTask<string> Solve_2() => new($"{SolvePartTwo()}");



    public int SolvePartOne()
    {
        return _input
            .Split('\n')
            .Where(dimensions => dimensions.Length > 0)
            .Select(dimensions => dimensions.Split('x')
                                            .Select(num => Int32.Parse(num))
                                            .Order()
                                            .ToArray()) 
            .Select(d => {
                return ((3 * d[0] * d[1]) + (2 * d[0] * d[2]) + (2 * d[1] * d[2]));
            })
            .Sum();
    }

    public int SolvePartTwo()
    {
        return _input
            .Split('\n')
            .Where(dimensions => dimensions.Length > 0)
            .Select(dimensions => dimensions.Split('x')
                                            .Select(num => Int32.Parse(num))
                                            .Order()
                                            .ToArray())
            .Select(d => {
                return ((2 * d[0]) + (2 * d[1]) + (d[0] * d[1] * d[2]));
            })
            .Sum();
    }





}

