namespace Unit.Tests.Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/4
**/
[TestClass]
public class Day04Tests
{
    private const string _exampleData = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";

    private Day04 _day04;

    [TestInitialize]
    public void Initialize()
    {
        _day04 = new Day04();
    }

    [TestMethod]
    public void PartOneExample()
    {
        var assignments = _exampleData;

        var pairs = _day04.Parse(assignments);
        var matches = _day04.CountContainedPairs(pairs);

        Assert.AreEqual(2, matches);
    }

    [TestMethod]
    public void PartOnePuzzle()
    {
        var assignments = File.ReadAllText("./Data/day04.txt"); ;

        var pairs = _day04.Parse(assignments);
        var matches = _day04.CountContainedPairs(pairs);

        Assert.AreEqual(524, matches);
    }

    [TestMethod]
    public void PartTwoExample()
    {
        var assignments = _exampleData;

        var pairs = _day04.Parse(assignments);
        var matches = _day04.CountOverlappingPairs(pairs);

        Assert.AreEqual(4, matches);
    }

    [TestMethod]
    public void PartTwoPuzzle()
    {
        var assignments = File.ReadAllText("./Data/day04.txt"); ;

        var pairs = _day04.Parse(assignments);
        var matches = _day04.CountOverlappingPairs(pairs);

        Assert.AreEqual(798, matches);
    }
}
