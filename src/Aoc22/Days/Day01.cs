namespace Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/1
**/
public class Day01
{
    public int[] Parse(string calories)
    {
        var elf = 0;
        var elfs = new List<int>();
        var foodList = calories.Replace("\r", string.Empty).Split('\n');

        for (int i = 0; i < foodList.Length; i++)
        {
            if (foodList[i] == string.Empty)
            {
                elfs.Add(elf);
                elf = 0;
                continue;
            }

            elf += int.Parse(foodList[i]);
        }

        elfs.Add(elf);
        return elfs.ToArray();
    }

    public int GetTop(int n, int[] aggregatedCalories)
    {
        return aggregatedCalories.OrderBy(x => x).Skip(aggregatedCalories.Length - n).Sum();
    }
}
