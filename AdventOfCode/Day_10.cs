namespace AdventOfCode;

public class Day_10 : BaseDay
{
    private readonly string input;

    public Day_10()
    {
        input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{SolvePartOne()}");

    public override ValueTask<string> Solve_2() => new($"{SolvePartTwo()}");

    //Both days need optmizied

    public int SolvePartOne()
    {
        string result = input;
        for(int i = 0; i < 40; i++)
        {
            result = lookAndSay(result);
        }
        return result.Length;

    }

    public int SolvePartTwo()
    {
        string result = input;
        for (int i = 0; i < 50; i++)
        {
            result = lookAndSay(result);
        }
        return result.Length;
    } 
    
    public string lookAndSay(string s)
    {
        string newString = string.Empty;
        int count = 0;
        char prev = new char();
        foreach (char c in s)
        {
            if (prev.Equals('\0'))
            {
                prev = c;
                count = 1;
            }
            else
            {
                if (c.Equals(prev))
                {
                    count++;
                }
                else
                {
                    newString += count.ToString() + prev;
                    prev = c;
                    count = 1;
                }
            }
        }
        newString += count.ToString() + prev;
        return newString;
    }
}

