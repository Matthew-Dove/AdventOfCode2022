namespace Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/10
**/
public class Day10
{
    public Program[] Parse(string input) => input.Replace("\r", string.Empty).Split('\n').Select(x => new Program(x)).ToArray();

    public int GetSignalStrength(Program[] program, params int[] targetCycles)
    {
        var signalStrength = 0;

        for (int i = 0; i < targetCycles.Length; i++)
        {
            signalStrength += GetRegister(program, targetCycles[i]) * targetCycles[i];
        }

        return signalStrength;
    }

    private int GetRegister(Program[] program, int targetCycle)
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

    private int[] Execute(Program[] program)
    {
        var positions = new List<int>();
        var register = 1;

        for (int i = 0; i < program.Length; i++)
        {
            positions.Add(register); // noop, or the first cycle of addx.
            if (program[i].Cycles == 2) 
            {
                positions.Add(register); // second cycle of addx.
                register += program[i].Value; // after the second cycle of addx the register is updated.
            }
        }

        return positions.ToArray();
    }

    public string Draw(Program[] program)
    {
        var sb = new StringBuilder().AppendLine();
        var positions = Execute(program);

        for (int i = 0; i < 240; i++)
        {
            var register = positions[i];
            var crt = i % 40;
            var print = '.';

            if (register == crt - 1 || register == crt || register == crt + 1)
            {
                print = '#';
            }

            sb.Append(print);
            if ((i + 1) % 40 == 0) sb.AppendLine();
        }

        return sb.ToString();
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
