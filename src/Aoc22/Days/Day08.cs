using System;

namespace Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/8
**/
public class Day08
{
    public int[,] Parse(string input)
    {
        var forest = input.Replace("\r", string.Empty).Split('\n');
        int rows = forest.Length, columns = forest[0].Length;
        var trees = new int[rows, columns];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                trees[r, c] = int.Parse(forest[r][c].ToString());
            }
        }

        return trees;
    }

    public int GetVisible(int[,] trees)
    {
        var edge = trees.GetLength(0);
        var visible = (edge * 4) - 4;

        for (int r = 1; r < edge - 1; r++)
        {
            for (int c = 1; c < edge - 1; c++)
            {
                var tree = trees[r, c];
                bool isVisibleUp = true, isVisibleDown = true, isVisibleLeft = true, isVisibleRight = true;

                // Up
                for (int ir = r - 1; isVisibleUp && ir >= 0; ir--)
                {
                    if (tree <= trees[ir, c]) isVisibleUp = false;
                }

                // Down
                for (int ir = r + 1; isVisibleDown && ir < edge; ir++)
                {
                    if (tree <= trees[ir, c]) isVisibleDown = false;
                }

                // Left
                for (int ic = c - 1; isVisibleLeft && ic >= 0; ic--)
                {
                    if (tree <= trees[r, ic]) isVisibleLeft = false;
                }

                // Right
                for (int ic = c + 1; isVisibleRight && ic < edge; ic++)
                {
                    if (tree <= trees[r, ic]) isVisibleRight = false;
                }

                if (isVisibleUp || isVisibleDown || isVisibleLeft || isVisibleRight) visible++;
            }
        }

        return visible;
    }

    public int GetScenicScore(int[,] trees)
    {
        var highScore = 0;
        var edge = trees.GetLength(0);

        for (int r = 1; r < edge - 1; r++)
        {
            for (int c = 1; c < edge - 1; c++)
            {
                var tree = trees[r, c];
                int scoreUp = 0, scoreDown = 0, scoreLeft = 0, scoreRight = 0;

                // Up
                for (int ir = r - 1; ir >= 0; ir--)
                {
                    if (tree > trees[ir, c]) scoreUp++;
                    else { scoreUp++; break; }
                }

                // Down
                for (int ir = r + 1; ir < edge; ir++)
                {
                    if (tree > trees[ir, c]) scoreDown++;
                    else { scoreDown++; break; }
                }

                // Left
                for (int ic = c - 1; ic >= 0; ic--)
                {
                    if (tree > trees[r, ic]) scoreLeft++;
                    else { scoreLeft++; break; }
                }

                // Right
                for (int ic = c + 1; ic < edge; ic++)
                {
                    if (tree > trees[r, ic]) scoreRight++;
                    else { scoreRight++; break; }
                }

                var score = scoreUp * scoreDown * scoreLeft * scoreRight;
                if (score > highScore) highScore = score;
            }
        }

        return highScore;
    }
}
