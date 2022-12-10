namespace Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/6
**/
public class Day06
{
    public int GetFirstMarker(string input, int markerLength)
    {
        for (int i = 0; i < input.Length; i++)
        {
            var hash = new HashSet<char>(markerLength);
            for (int j = 0; j < markerLength; j++) hash.Add(input[i + j]);
            if (hash.Count == markerLength) return i + markerLength;
        }
        return -1;
    }
}
