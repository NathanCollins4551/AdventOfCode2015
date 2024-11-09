using System.Collections;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode;

public class Day_07 : BaseDay
{
    private readonly string input;
    IEnumerable<(string, Command, string, string)> instructions;
    List<Tuple<string, int>> values;

    public Day_07()
    {
        input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{SolvePartOne()}");

    public override ValueTask<string> Solve_2() => new($"{SolvePartTwo()}");



    public int SolvePartOne()
    {
        values = new List<Tuple<string, int>>();
        instructions = input
            .Split('\n')
            .Where(line => line.Length > 0)
            .Select(line => getInstructions(line));

        return getValue("a", string.Empty); 
    }

    public int SolvePartTwo()
    {
        return 0;
    }

    public int getValue(string target, string prev)
    {
        //Console.WriteLine(target);

        //if number, add to values list and return number
        if (int.TryParse(target, out int num))
        {
            values.Add(new Tuple<string, int>(prev, num));//("ab", 123)
            return num;
        }
        //check if target value is already found
        var foundValues = values.Where(x => x.Item1.Equals(target));
        if (foundValues.Count() > 0)
        {
            return foundValues.First().Item2;
        }
        //find tagert value
        else
        {
            var instruction = instructions.Single(x => x.Item1.Equals(target));
            if (instruction.Item2.Equals(Command.NOT))
            {
                return compliment(getValue(instruction.Item3, target));
            }
            else if (instruction.Item2.Equals(Command.AND))
            {
                return getValue(instruction.Item3, target) & getValue(instruction.Item4, target);
            }
            else if (instruction.Item2.Equals(Command.OR))
            {
                return getValue(instruction.Item3, target) | getValue(instruction.Item4, target);
            }
            else if (instruction.Item2.Equals(Command.RSHIFT))
            {
                return getValue(instruction.Item3, target) >> getValue(instruction.Item4, target);
            }
            else if (instruction.Item2.Equals(Command.LSHIFT))
            {
                return getValue(instruction.Item3, target) << getValue(instruction.Item4, target);
            }
            else
            {
                return getValue(instruction.Item3, target);
            }
        }
    }

    public (string, Command, string, string) getInstructions(string line)
    {
        string name = line.Split(" -> ")[1];
        line = line.Split(" -> ")[0];
        Command command;
        string input1 = string.Empty;
        string input2 = string.Empty;
        if (line.Contains(" RSHIFT "))
        {
            command = Command.RSHIFT;
            line = line.Replace(" RSHIFT ", ",");
            input1 = line.Split(',')[0];
            input2 = line.Split(',')[1];
        }
        else if (line.Contains(" LSHIFT "))
        {
            command = Command.LSHIFT;
            line = line.Replace(" LSHIFT ", ",");
            input1 = line.Split(',')[0];
            input2 = line.Split(',')[1];
        }
        else if (line.Contains(" OR "))
        {
            command = Command.OR;
            line = line.Replace(" OR ", ",");
            input1 = line.Split(',')[0];
            input2 = line.Split(',')[1];
        }
        else if (line.Contains(" AND "))
        {
            command = Command.AND;
            line = line.Replace(" AND ", ",");
            input1 = line.Split(',')[0];
            input2 = line.Split(',')[1];
        }
        else if(line.Contains("NOT "))
        {
            command = Command.NOT;
            line = line.Replace("NOT ", string.Empty);
            input1 = line;
        }
        else
        {
            command = Command.SET;
            input1 = input1 = line;

        }
        return (name, command, input1, input2);
    }

    public int compliment(int num)
    {
        string b0 = Convert.ToString(num, 2).PadLeft(16,'0');
        var bRev = b0.PadLeft(16, '0');
        string b1 = string.Empty;
        foreach (char c in bRev)
        {
            if (c == '0')
            {
                b1 += '1';
            }
            else if (c == '1')
            {
                b1 += '0';
            }
        }
        int number = Convert.ToInt32(b1,2);
        return number;
    }
    public enum Command
    {
        NOT,
        AND,
        OR,
        LSHIFT,
        RSHIFT,
        SET
    }
}