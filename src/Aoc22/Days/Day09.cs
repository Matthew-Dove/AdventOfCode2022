namespace Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/9
**/
public class Day09
{
    public Move[] Parse(string input) => input.Replace("\r", string.Empty).Split('\n').Select(x => new Move(x)).ToArray();

    public int SimulatePartOne(Move[] moves)
    {
        var positions = new HashSet<string>(new[] { "(0,0)" });
        (int r, int c) tail = (0, 0), head = (0, 0);

        for (int i = 0; i < moves.Length; i++)
        {
            for (int j = 0; j < moves[i].Steps; j++)
            {
                var target = head;

                if (moves[i].Direction == Direction.Up) head.r++;
                else if (moves[i].Direction == Direction.Down) head.r--;
                else if (moves[i].Direction == Direction.Left) head.c--;
                else if (moves[i].Direction == Direction.Right) head.c++;

                if (ShouldFollow(tail, head))
                {
                    tail = target;
                    positions.Add($"({tail.c},{tail.r})");
                }
            }
        }

        return positions.Count;
    }

    private bool ShouldFollow((int r, int c) tail, (int r, int x) head)
    {
        for (int r = tail.r - 1; r < tail.r + 2; r++)
        {
            for (int c = tail.c - 1; c < tail.c + 2; c++)
            {
                if (head == (r, c)) return false;
            }
        }
        return true;
    }

    public int SimulatePartTwo(Move[] moves)
    {
        var positions = new HashSet<string>(new[] { "(0,0)" });
        var knots = Enumerable.Repeat<(int r, int c)>((0, 0), 10).ToArray();
        Print(knots);

        for (int i = 0; i < moves.Length; i++)
        {
            for (int j = 0; j < moves[i].Steps; j++)
            {
                if (moves[i].Direction == Direction.Up) knots[0].r++;
                else if (moves[i].Direction == Direction.Down) knots[0].r--;
                else if (moves[i].Direction == Direction.Left) knots[0].c--;
                else if (moves[i].Direction == Direction.Right) knots[0].c++;

                for (int k = 1; k < knots.Length; k++)
                {
                    //Print(knots);
                    if (ShouldFollow(knots[k], knots[k - 1]))
                    {
                        knots[k] = GetPosition(knots[k], knots[k - 1]);
                        if (k + 1 == knots.Length) positions.Add($"({knots[k].c},{knots[k].r})");
                    }
                    else break;
                }
            }
        }

        return positions.Count;
    }

    private static (int, int) GetPosition((int y, int x) tail, (int y, int x) head)
    {
        if (tail.y == head.y)
        {
            if (tail.x < head.x) return (tail.y, tail.x + 1); // Head moved right.
            return (tail.y, tail.x - 1); // Head moved left.
        }

        if (tail.x == head.x)
        {
            if (tail.y < head.y) return (tail.y + 1, tail.x); // Head moved up.
            return (tail.y - 1, tail.x); // Head moved down.
        }

        if (tail.x > head.x && tail.y < head.y) return (tail.y + 1, tail.x - 1); // Head moved top left.

        if (tail.x < head.x && tail.y < head.y) return (tail.y + 1, tail.x + 1); // Head moved top right.

        if (tail.x > head.x && tail.y > head.y) return (tail.y - 1, tail.x - 1); // Head moved bottom left.

        if (tail.x < head.x && tail.y > head.y) return (tail.y - 1, tail.x + 1); // Head moved bottom right.

        return (0, 0); // Won't reach here.
    }

    private void Print((int row, int column)[] knots)
    {
        var grid = new char[20, 20];
        var view = new StringBuilder();

        for (int i = 0; i < knots.Length; i++)
        {
            if (grid[knots[i].row, knots[i].column] == default)
            {
                var target = i.ToString()[0];
                grid[knots[i].row, knots[i].column] = i == 0 ? 'H' : target;
            }
        }

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                var target = grid[i, j];
                view.Append(target == default ? '.' : target);
            }
            view.AppendLine();
        }

        System.Diagnostics.Debug.WriteLine(view.ToString());
    }
}

public enum Direction { Up, Down, Left, Right }

public class Move
{
    public Move(string move)
    {
        var partition = move.Split(" ");
        Direction = partition[0] switch
        {
            "U" => Direction.Up,
            "D" => Direction.Down,
            "L" => Direction.Left,
            "R" => Direction.Right
        };
        Steps = int.Parse(partition[1]);
    }

    public Direction Direction { get; set; }
    public int Steps { get; set; }
}