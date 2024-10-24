using System.Security.Cryptography;
using System.Text;

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
        int num = 0;
        while (true)
        {
            string md5 = GenerateMD5(input+num.ToString());
            if (md5.Substring(0,5) == "00000")
            {
              return num;
            }
            else
            {
                num++;
            }
        }
    } 

    public int SolvePartTwo()
    {
        int num = 0;
        while (true)
        {
            string md5 = GenerateMD5(input + num.ToString());
            if (md5.Substring(0, 6) == "000000")
            {
                return num;
            }
            else
            {
                num++;
            }
        }
    }

    public string GenerateMD5(string input)
    {
        MD5 md5Hasher = MD5.Create();
        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }
}

