namespace Unit.Tests.Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/8
**/
[TestClass]
public class Day08Tests
{
    private const string _exampleData = @"30373
25512
65332
33549
35390";

    private Day08 _day08;

    [TestInitialize]
    public void Initialize()
    {
        _day08 = new Day08();
    }

    [TestMethod]
    public void PartOneExample()
    {
        var input = _exampleData;

        var trees = _day08.Parse(input);
        var visibleTrees = _day08.GetVisible(trees);

        Assert.AreEqual(21, visibleTrees);
    }

    [TestMethod]
    public void PartOnePuzzle()
    {
        var input = File.ReadAllText("./Data/day08.txt"); ;

        var trees = _day08.Parse(input);
        var visibleTrees = _day08.GetVisible(trees);

        Assert.AreEqual(1814, visibleTrees);
    }

    [TestMethod]
    public void PartTwoExample()
    {
        var input = _exampleData;

        var trees = _day08.Parse(input);
        var score = _day08.GetScenicScore(trees);

        Assert.AreEqual(8, score);
    }

    [TestMethod]
    public void PartTwoPuzzle()
    {
        var input = File.ReadAllText("./Data/day08.txt"); ;

        var trees = _day08.Parse(input);
        var score = _day08.GetScenicScore(trees);

        Assert.AreEqual(330786, score);
    }
}
