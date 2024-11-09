namespace AdventOfCode;

public class Day_11 : BaseDay
{
    private readonly string input;

    public Day_11()
    {
        input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{SolvePartOne()}");

    public override ValueTask<string> Solve_2() => new($"{SolvePartTwo()}");

    public string SolvePartOne()
    {
        return findNewPswd(input);
    }

    public string SolvePartTwo()
    {
        return findNewPswd(SolvePartOne());
    }

    public string findNewPswd(string s)
    {
        string newPswd = s;
        do
        {
            newPswd = incrementString(newPswd);
        } while(!checkReq(newPswd));

        return newPswd;
    }

    public string incrementString(string s)
    {
        char c = s[s.Length - 1];
        c++;
        s = s.Remove(s.Length-1, 1);
        s += c;
        for(int i = 0; i < s.Length; i++)
        {
            if (s[i].Equals('{'))//ascii value after z
            {
                s = s.Remove(i, 1);
                s = s.Insert(i, "a");
                char t = s[i-1];
                t++;
                s = s.Remove(i-1, 1);
                s = s.Insert(i-1, t.ToString());
            }
        }
        return s;
    }

    public bool checkReq(string s)
    {
        if (!hasIncreasingStraight(s))//condition 1
        {
            return false;
        }
        if (s.Contains('i') || s.Contains('o') || s.Contains('l'))//condition 2
        {
            return false;
        }
        if (!hasTwoPairs(s))//condition 3
        {
            return false;
        }
        return true;
    }

    public bool hasIncreasingStraight(string s)
    {
        for (int i = 0; i < s.Length - 2; i++)
        {
            if ((s[i] - '0').Equals((s[i+1] - '0' )- 1) && (s[i+1] - '0').Equals((s[i+2] - '0') - 1))
            {
                return true;
            }
        }
        return false;
    }

    public bool hasTwoPairs(string s)
    {
        int numOPairs = 0;
        for (int i = 0; i < s.Length - 1; i++)
        {
            if (s[i].Equals(s[i + 1]))
            {
                numOPairs++;
                i++;
            }
        }
        if(numOPairs > 1){
            return true;
        }
        return false;
    }
}

