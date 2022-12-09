using System.Collections.Generic;

namespace Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/3
**/
public class Day03
{
    public char[] ParsePartOne(string supplies)
    {
        var rucksacks = supplies.Replace("\r", string.Empty).Split('\n');
        var priorities = new char[rucksacks.Length];

        for (int i = 0; i < rucksacks.Length; i++)
        {
            var midpoint = rucksacks[i].Length / 2;
            string compartmentA = rucksacks[i].Substring(0, midpoint), compartmentB = rucksacks[i].Substring(midpoint, rucksacks[i].Length - midpoint);

            var hashset = new HashSet<char>(compartmentA);

            foreach (var item in compartmentB)
            {
                if (hashset.Contains(item))
                {
                    priorities[i] = item;
                    break;
                }
            }
        }

        return priorities;
    }

    public char[] ParsePartTwo(string supplies)
    {
        var rucksacks = supplies.Replace("\r", string.Empty).Split('\n');
        var priorities = new char[rucksacks.Length / 3];

        for (int i = 0, j = 0; i < rucksacks.Length; i+=3, j++)
        {
            string rucksackA = rucksacks[i + 0], rucksackB = rucksacks[i + 1], rucksackC = rucksacks[i + 2];

            HashSet<char> hashsetA = new HashSet<char>(rucksackA), hashsetB = new HashSet<char>(rucksackB);

            foreach (var item in rucksackC)
            {
                if (hashsetA.Contains(item) && hashsetB.Contains(item))
                {
                    priorities[j] = item;
                    break;
                }
            }
        }

        return priorities;
    }

    public int Score(char[] priorities)
    {
        var score = 0;

        foreach (var item in priorities)
        {
            score += item - (char.IsLower(item) ? 96 : 38);
        }

        return score;
    }
}
