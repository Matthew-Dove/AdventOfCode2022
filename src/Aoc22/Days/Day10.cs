namespace Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/10
**/
public class Day10
{
    public Program[] Parse(string input) => input.Replace("\r", string.Empty).Split('\n').Select(x => new Program(x)).ToArray();

    public int GetSignalStrength(Program[] program, params int[] targetCycles)
    {
        var sum = 0;

        for (int i = 0; i < targetCycles.Length; i++)
        {
            var cycleValue = GetCycleValue(program, targetCycles[i]);
            var signalStrength = cycleValue * targetCycles[i];
            sum += signalStrength;
        }

        return sum;
    }

    private int GetCycleValue(Program[] program, int targetCycle)
    {
        int cycles = 0, register = 1;

        for (int i = 0; i < program.Length; i++)
        {
            cycles += program[i].Cycles;
            register += program[i].Value;

            if (cycles >= targetCycle) return register - program[i].Value;
        }

        return 0;
    }
}

public record Program
{
    public int Cycles { get; } = 1;
    public int Value { get; } = 0;

    public Program(string instruction)
    {
        if (instruction[0] == 'a')
        {
            Cycles = 2;
            Value = int.Parse(instruction["addx ".Length..]);
        }
    }
}