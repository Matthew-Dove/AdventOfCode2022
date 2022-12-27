namespace Unit.Tests.Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/10
**/
[TestClass]
public class Day10Tests
{
    private const string _exampleData = @"addx 15
addx -11
addx 6
addx -3
addx 5
addx -1
addx -8
addx 13
addx 4
noop
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx -35
addx 1
addx 24
addx -19
addx 1
addx 16
addx -11
noop
noop
addx 21
addx -15
noop
noop
addx -3
addx 9
addx 1
addx -3
addx 8
addx 1
addx 5
noop
noop
noop
noop
noop
addx -36
noop
addx 1
addx 7
noop
noop
noop
addx 2
addx 6
noop
noop
noop
noop
noop
addx 1
noop
noop
addx 7
addx 1
noop
addx -13
addx 13
addx 7
noop
addx 1
addx -33
noop
noop
noop
addx 2
noop
noop
noop
addx 8
noop
addx -1
addx 2
addx 1
noop
addx 17
addx -9
addx 1
addx 1
addx -3
addx 11
noop
noop
addx 1
noop
addx 1
noop
noop
addx -13
addx -19
addx 1
addx 3
addx 26
addx -30
addx 12
addx -1
addx 3
addx 1
noop
noop
noop
addx -9
addx 18
addx 1
addx 2
noop
noop
addx 9
noop
noop
noop
addx -1
addx 2
addx -37
addx 1
addx 3
noop
addx 15
addx -21
addx 22
addx -6
addx 1
noop
addx 2
addx 1
noop
addx -10
noop
noop
addx 20
addx 1
addx 2
addx 2
addx -6
addx -11
noop
noop
noop";

    private Day10 _day10;

    [TestInitialize]
    public void Initialize()
    {
        _day10 = new Day10();
    }

    [TestMethod]
    public void PartOneExample()
    {
        var input = _exampleData;

        var program = _day10.Parse(input);
        var strength = _day10.GetSignalStrength(program, 20, 60, 100, 140, 180, 220);

        Assert.AreEqual(13140, strength);
    }

    [TestMethod]
    public void PartOnePuzzle()
    {
        var input = File.ReadAllText("./Data/day10.txt");

        var program = _day10.Parse(input);
        var strength = _day10.GetSignalStrength(program, 20, 60, 100, 140, 180, 220);

        Assert.AreEqual(12880, strength);
    }

    [TestMethod]
    public void PartTwoExample()
    {
        var input = _exampleData;

        var program = _day10.Parse(input);
        var screen = _day10.Draw(program);

        Assert.AreEqual(@"
##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######.....
", screen);
    }

    [TestMethod]
    public void PartTwoPuzzle()
    {
        var input = File.ReadAllText("./Data/day10.txt");

        var program = _day10.Parse(input);
        var screen = _day10.Draw(program);

        Assert.AreEqual(@"
####..##....##..##..###....##.###..####.
#....#..#....#.#..#.#..#....#.#..#.#....
###..#.......#.#..#.#..#....#.#..#.###..
#....#.......#.####.###.....#.###..#....
#....#..#.#..#.#..#.#....#..#.#.#..#....
#.....##...##..#..#.#.....##..#..#.####.
", screen);
    }
}
