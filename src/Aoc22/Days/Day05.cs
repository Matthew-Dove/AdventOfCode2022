using System.Diagnostics;

namespace Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/5
**/
public class Day05
{
    public Cargo Parse(string input)
    {
        var parition = input.Replace("\r", string.Empty).Split("\n 1");
        var stacks = parition[0].Split('\n');
        var tmp = parition[1].Split('\n');
        var stackCount = int.Parse(tmp.First().TrimEnd().Last().ToString());
        var algorithm = tmp.Skip(2).ToArray();

        var crates = new Stack<char>[stackCount];

        for (int i = 0; i < stackCount; i++)
        {
            crates[i] = new Stack<char>(stacks.Length);
            var offset = i * 4 + 1;

            for (int j = stacks.Length - 1, k = 0; j >= 0; j--, k++)
            {
                var crate = stacks[j][offset];
                if (crate != ' ') crates[i].Push(crate);
            }
        }

        var instructions = new Instruction[algorithm.Length];

        for (int i = 0; i < instructions.Length; i++)
        {
            var split = algorithm[i].Substring(5).Split(" from ");
            var move = split[1].Split(" to ");
            int take = int.Parse(split[0]), source = int.Parse(move[0]) - 1, target = int.Parse(move[1]) - 1;
            instructions[i] = new Instruction { Take = take, Source = source, Target = target };
        }

        return new Cargo { Crates = crates, Instructions = instructions };
    }

    public Cargo Move(Cargo cargo)
    {
        foreach (var instruction in cargo.Instructions)
        {
            for (int i = 0; i < instruction.Take; i++)
            {
                var crate = cargo.Crates[instruction.Source].Pop();
                cargo.Crates[instruction.Target].Push(crate);
            }
        }

        return cargo;
    }

    public Cargo MovePartTwo(Cargo cargo)
    {
        foreach (var instruction in cargo.Instructions)
        {
            var creates = new char[instruction.Take];
            for (int i = 0; i < instruction.Take; i++) creates[i] = cargo.Crates[instruction.Source].Pop();
            creates = creates.Reverse().ToArray();
            for (int i = 0; i < instruction.Take; i++) cargo.Crates[instruction.Target].Push(creates[i]);
        }

        return cargo;
    }

    public string GetTopCrates(Cargo cargo)
    {
        var topCrates = string.Empty;

        foreach (var crate in cargo.Crates)
        {
            topCrates += crate.Peek().ToString();
        }

        return topCrates;
    }
}

public class Cargo
{
    public Stack<char>[] Crates { get; set; }
    public Instruction[] Instructions { get; set; }
}

public class Instruction
{
    public int Take { get; set; }
    public int Source { get; set; }
    public int Target { get; set; }
}