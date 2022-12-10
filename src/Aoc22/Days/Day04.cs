namespace Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/4
**/
public class Day04
{
    public Pair[] Parse(string assignments)
    {
        var sections = assignments.Replace("\r", string.Empty).Split('\n');
        var pairs = new Pair[sections.Length];

        for (int i = 0; i < sections.Length; i++)
        {
            var pair = sections[i].Split(',');
            string[] sectionA = pair[0].Split('-'), sectionB = pair[1].Split('-');
            Section
                a = new Section { Start = int.Parse(sectionA[0]), End = int.Parse(sectionA[1]) },
                b = new Section { Start = int.Parse(sectionB[0]), End = int.Parse(sectionB[1]) }
            ;
            pairs[i] = new Pair { A = a, B = b };
        }

        return pairs;
    }

    public int CountContainedPairs(Pair[] pairs)
    {
        var matches = 0;

        foreach (var pair in pairs)
        {
            if (pair.A.Start >= pair.B.Start && pair.A.End <= pair.B.End) matches++;
            else if (pair.B.Start >= pair.A.Start && pair.B.End <= pair.A.End) matches++;
        }

        return matches;
    }

    public int CountOverlappingPairs(Pair[] pairs)
    {
        var matches = 0;

        foreach (var pair in pairs)
        {
            var hash = new HashSet<int>();
            for (int i = pair.A.Start; i <= pair.A.End; i++)
            {
                hash.Add(i);
            }
            for (int j = pair.B.Start; j <= pair.B.End; j++)
            {
                if (hash.Contains(j))
                {
                    matches++;
                    break;
                }
            }
        }

        return matches;
    }
}

public record Section
{
    public int Start { get; set; }
    public int End { get; set; }
}

public record Pair
{
    public Section A { get; set; }
    public Section B { get; set; }
}