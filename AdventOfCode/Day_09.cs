namespace AdventOfCode;

public class Day_09 : BaseDay
{
    private readonly string input;

    public Day_09()
    {
        input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{SolvePartOne()}");

    public override ValueTask<string> Solve_2() => new($"{SolvePartTwo()}");



    public int SolvePartOne()
    {

        return getTotalDistances().Order().First();

    }

    public int SolvePartTwo()
    {
        return getTotalDistances().OrderDescending().First();
    }

    public List<int> getTotalDistances()
    {
        Dictionary<string, int> distances = new Dictionary<string, int>();
        List<string> cities = new List<string>();

        var lines = input.Split('\n').Where(line => line.Length > 0);

        foreach (var line in lines)
        {
            string c1 = line.Split(" to ")[0];
            string c2 = line.Split(" to ")[1].Split(" = ")[0];
            int dist = Int32.Parse(line.Split(" to ")[1].Split(" = ")[1]);

            distances.Add(c1 + "->" + c2, dist);
            distances.Add(c2 + "->" + c1, dist);

            cities.Add(c1); cities.Add(c2);
        }

        cities = cities.Distinct().ToList();

        List<string> combinations = getPossibleCombinations(cities);

        return combinations.Select(combination => getDistance(combination, distances)).ToList();
    }

    public int getDistance(string combination, Dictionary<string, int> dict)
    {
        List<string> cities = combination.Split("->").ToList();
        int sum = 0;
        for (int i = 0; i < cities.Count() - 1; i++)
        {
            sum += dict[cities[i] +"->"+ cities[i + 1]];
        }
        return sum;
    }

    public List<string> getPossibleCombinations(List<string> l)
    {
        List<string> newList = new List<string>();
        List<string> restOfCombinations;

        if (l.Count() > 1)
        {
            for (int i = 0; i < l.Count(); i++)
            {
                restOfCombinations = new List<string>(l);
                restOfCombinations.RemoveAt(i);
                string current;
                foreach (var x in getPossibleCombinations(restOfCombinations))
                {
                    current = l[i] +"->"+ x;
                    newList.Add(current);
                }
            }
            return newList;
        }
        return l;
    }
}

