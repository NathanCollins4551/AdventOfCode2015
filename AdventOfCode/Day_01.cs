﻿namespace AdventOfCode;

public class Day_01 : BaseDay
{
    private readonly string input;

    public Day_01()
    {
        input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{SolvePartOne()}");

    public override ValueTask<string> Solve_2() => new($"{SolvePartTwo()}");

   
    
    public int SolvePartOne()
    {
        int floor = 0;
        foreach (char x in input)
        {
            if (x == '(')
            {
                floor++;
            }
            else if (x == ')')
            {
                floor--;
            }
        }
        return floor;
    }
    
public int SolvePartTwo()
    {
        int floor = 0;
        foreach (var x in input.Select((ch,index) => (ch, index)))
        {
            if (x.ch == '(')
            {
                floor++;
            }
            else if (x.ch == ')')
            {
                floor--;
            }
            if(floor == -1)
            {
                return x.index +1;
            }
        }
        return -1;
    }
}

