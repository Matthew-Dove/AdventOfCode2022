namespace Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/2
**/
public class Day02
{
    public (Rps Opponent, Rps Strategy)[] ParsePartOne(string guide)
    {
        var plays = guide.Replace("\r", string.Empty).Split('\n');
        var playbook = new (Rps, Rps)[plays.Length];

        for (int i = 0; i < plays.Length; i++)
        {
            Rps opponent = plays[i][0] switch
            {
                'A' => Rps.Rock,
                'B' => Rps.Paper,
                'C' => Rps.Scissors
            },
            strategy = plays[i][2] switch
            {
                'Y' => Rps.Paper,
                'X' => Rps.Rock,
                'Z' => Rps.Scissors
            };

            playbook[i] = new(opponent, strategy);
        }

        return playbook;
    }

    public (Rps Opponent, Rps Strategy)[] ParsePartTwo(string guide)
    {
        const char WIN = 'Z', DRAW = 'Y', LOSE = 'X';
        var plays = guide.Replace("\r", string.Empty).Split('\n');
        var playbook = new (Rps, Rps)[plays.Length];

        for (int i = 0; i < plays.Length; i++)
        {
            var opponent = plays[i][0] switch
            {
                'A' => Rps.Rock,
                'B' => Rps.Paper,
                'C' => Rps.Scissors
            };
            var strategy = plays[i][2] switch
            {
                WIN => GetStrategy(Play.Win, opponent),
                DRAW => GetStrategy(Play.Draw, opponent),
                LOSE => GetStrategy(Play.Lose, opponent)
            };

            playbook[i] = new(opponent, strategy);
        }

        return playbook;
    }

    private Rps GetStrategy(Play target, Rps opponent)
    {
        if (target == Play.Win)
        {
            return opponent switch
            {
                Rps.Rock => Rps.Paper,
                Rps.Paper => Rps.Scissors,
                Rps.Scissors => Rps.Rock
            };
        }

        if (target == Play.Draw)
        {
            return opponent switch
            {
                Rps.Rock => Rps.Rock,
                Rps.Paper => Rps.Paper,
                Rps.Scissors => Rps.Scissors
            };
        }

        return opponent switch
        {
            Rps.Rock => Rps.Scissors,
            Rps.Paper => Rps.Rock,
            Rps.Scissors => Rps.Paper
        };
    }

    public int ScoreShape((Rps Opponent, Rps Strategy)[] playbook)
    {
        var score = 0;

        foreach (var play in playbook)
        {
            score += play.Strategy switch
            {
                Rps.Rock => 1,
                Rps.Paper => 2,
                Rps.Scissors => 3
            };
        }

        return score;
    }

    public int ScoreRound((Rps Opponent, Rps Strategy)[] playbook)
    {
        const int WIN = 6, DRAW = 3, LOSE = 0;
        var score = 0;

        foreach (var play in playbook)
        {
            score += play switch
            {
                (Rps.Rock, Rps.Paper)   or (Rps.Paper, Rps.Scissors)    or (Rps.Scissors, Rps.Rock)     => WIN,
                (Rps.Rock, Rps.Rock)    or (Rps.Paper, Rps.Paper)       or (Rps.Scissors, Rps.Scissors) => DRAW,
                (Rps.Paper, Rps.Rock)   or (Rps.Scissors, Rps.Paper)    or (Rps.Rock, Rps.Scissors)     => LOSE
            };
        }

        return score;
    }
}

public enum Rps { Rock, Paper, Scissors }
public enum Play { Win, Draw, Lose }