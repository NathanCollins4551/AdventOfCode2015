namespace AdventOfCode;

public class Day_05 : BaseDay
{
    private readonly string input;

    public Day_05()
    {
        input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{SolvePartOne()}");

    public override ValueTask<string> Solve_2() => new($"{SolvePartTwo()}");



    public int SolvePartOne()
    {
        return input
            .Split("\n")
            .Where(line => line.Length > 0)
            .Select(name => isNicePartOne(name))
            .Sum();
    }

    public int SolvePartTwo()
    {
        return input
            .Split("\n")
            .Where(line => line.Length > 0)
            .Select(name => isNicePartTwo(name))
            .Sum();
    }

    public int isNicePartOne(string name)
    {
        //check for ! double letter
        if (!hasDoubleLetter(name))
        {
            return 0;
        }
        //check for illegal substrings
        if (hasIllegalSubstring(name))
        {
            return 0;
        }
        //check for less than 3 vowels
        if (numVowel(name) < 3)
        {
            return 0;
        }
        return 1;
    }

    public int isNicePartTwo(string name)
    {
        //check for not repeating pair
        if (!hasRepeatingPair(name))
        {
            return 0;
        }
        //check for not letter sandwhich, ex: aba, fnf
        if (!hasLetterSandwhich(name))
        {
            return 0;
        }
        return 1;
    }

    public bool hasDoubleLetter(string name)
    {
        for (int i = 0; i < name.Length -1; i++)
        {
            if (name[i] == name[i+1])
            {
                return true;
            }
        }
        return false;
    }

    public bool hasIllegalSubstring(string name)
    {
        if (name.Contains("ab") || name.Contains("cd") || name.Contains("pq") || name.Contains("xy"))
        {
            return true;
        }
        return false;
    }
    
    public int numVowel(string name)
    {
        int num = 0;
        foreach (char x in name)
        {
            if (x == 'a' || x == 'e' || x == 'i' || x == 'o' || x == 'u')
            {
                num++;
            }
        }
        return num;
    }

    public bool hasRepeatingPair(string name)
    {
        for(int i = 0; i < name.Length-1; i++)
        {
            string pair = name.Substring(i,2);
            if (name.Substring(i + 2).Contains(pair))
            {
                return true;
            }
        }
        return false;
    }

    public bool hasLetterSandwhich(string name)
    {
        if(name.Length > 2)
        {
            for (int i = 0; i < name.Length - 2; i++)
            {
                if (name[i] == name[i + 2]){
                    return true;
                }
            }
        }
        return false;
    }
}

