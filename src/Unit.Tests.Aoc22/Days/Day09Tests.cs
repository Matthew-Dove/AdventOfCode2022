namespace Unit.Tests.Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/9
**/
[TestClass]
public class Day09Tests
{
    private const string _exampleData = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2";

    private Day09 _day09;

    [TestInitialize]
    public void Initialize()
    {
        _day09 = new Day09();
    }

    [TestMethod]
    public void PartOneExample()
    {
        var input = _exampleData;

        var moves = _day09.Parse(input);
        var position = _day09.SimulatePartOne(moves);

        Assert.AreEqual(13, position);
    }

    [TestMethod]
    public void PartOnePuzzle()
    {
        var input = File.ReadAllText("./Data/day09.txt");

        var moves = _day09.Parse(input);
        var position = _day09.SimulatePartOne(moves);

        Assert.AreEqual(6256, position);
    }

    [TestMethod]
    public void PartTwoExample()
    {
        const string exampleData = @"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20";
        var moves = _day09.Parse(exampleData);
        var position = _day09.SimulatePartTwo(moves);

        Assert.AreEqual(36, position);
    }

    [TestMethod]
    public void PartTwoPuzzle()
    {
        var input = File.ReadAllText("./Data/day09.txt");

        var moves = _day09.Parse(input);
        var position = _day09.SimulatePartTwo(moves);

        Assert.AreEqual(2665, position);
    }
}
