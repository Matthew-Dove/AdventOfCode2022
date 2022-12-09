namespace Unit.Tests.Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/3
**/
[TestClass]
public class Day03Tests
{
    private const string _exampleData = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

    private Day03 _day03;

    [TestInitialize]
    public void Initialize()
    {
        _day03 = new Day03();
    }

    [TestMethod]
    public void PartOneExample()
    {
        var supplies = _exampleData;

        var priorities = _day03.ParsePartOne(supplies);
        var score = _day03.Score(priorities);

        Assert.AreEqual(157, score);
    }

    [TestMethod]
    public void PartOnePuzzle()
    {
        var supplies = File.ReadAllText("./Data/day03.txt");

        var priorities = _day03.ParsePartOne(supplies);
        var score = _day03.Score(priorities);

        Assert.AreEqual(8493, score);
    }

    [TestMethod]
    public void PartTwoExample()
    {
        var supplies = _exampleData;

        var priorities = _day03.ParsePartTwo(supplies);
        var score = _day03.Score(priorities);

        Assert.AreEqual(70, score);
    }

    [TestMethod]
    public void PartTwoPuzzle()
    {
        var supplies = File.ReadAllText("./Data/day03.txt");

        var priorities = _day03.ParsePartTwo(supplies);
        var score = _day03.Score(priorities);

        Assert.AreEqual(2552, score);
    }
}
