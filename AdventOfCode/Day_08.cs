namespace AdventOfCode;

public class Day_08 : BaseDay
{
    private readonly string input;

    public Day_08()
    {
        input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{SolvePartOne()}");

    public override ValueTask<string> Solve_2() => new($"{SolvePartTwo()}");



    public int SolvePartOne()
    {
        int before = input.Split('\n')
                     .Select(line => line.Length)
                     .Sum();
        int after = input.Split('\n')
                     .Where(line => line.Length >= 2)
                     .Select(line => fixString(line))
                     .Select(line => line.Length)
                     .Sum();

        return before-after;
    }

    public int SolvePartTwo()
    {
        int before = input.Split('\n')
                     .Select(line => line.Length)
                     .Sum();
        int after = input.Split('\n')
                     .Where(line => line.Length > 0)
                     .Select(line => encodeString(line))
                     .Select(line => line.Length)
                     .Sum();

        return after - before;
    }

    string encodeString(string line)
    {
        for(int i = 0; i < line.Length; i++)
        {
            if (line[i].Equals('\\'))
            {
                line = line.Insert(i, "\\");
                i++;
            }
            if (line[i].Equals('\"'))
            {
                line = line.Insert(i, "\\");
                i++;
            }
        }
        line = line.Insert(0, "\"") + "\"";
        return line;
    }
    string fixString(string line)
    {
        line = line.Substring(1, line.Length - 2)
                   .Replace("\\\"", "\"")
                   .Replace("\\\\", "\\");
        while (line.Contains("\\x"))
        {
            int i = line.IndexOf("\\x");
            string hex = line.Substring(i + 2, 2);
            if (!hexToASCII(hex).Equals(string.Empty))
            {
                line = line.Replace("\\x" + hex, hexToASCII(hex));
            }
            else{
                line = line.Replace("\\x" + hex, "/x"+hex);//If invalid hex value, change the slash so it wont try to replace it again
            }
        }
        return line;
    }
    string hexToASCII(string hex)
    {
        string ascii;
        try
        {
            char ch = (char)Convert.ToInt32(hex, 16); ;
            ascii = ch.ToString();
        }
        catch (Exception e)
        {
            ascii = string.Empty;
        }
        return ascii;
    }

}

