namespace Unit.Tests.Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/6
**/
[TestClass]
public class Day06Tests
{
    private const string _exampleData = @"mjqjpqmgbljsphdztnvjfqwrcgsmlb";

    private Day06 _day06;

    [TestInitialize]
    public void Initialize()
    {
        _day06 = new Day06();
    }

    [TestMethod]
    public void PartOneExample()
    {
        var input = _exampleData;

        var marker = _day06.GetFirstMarker(input, 4);

        Assert.AreEqual(7, marker);
    }

    [TestMethod]
    public void PartOnePuzzle()
    {
        var input = File.ReadAllText("./Data/day06.txt");

        var marker = _day06.GetFirstMarker(input, 4);

        Assert.AreEqual(1356, marker);
    }

    [TestMethod]
    public void PartTwoExample()
    {
        var input = _exampleData;

        var marker = _day06.GetFirstMarker(input, 14);

        Assert.AreEqual(19, marker);
    }

    [TestMethod]
    public void PartTwoPuzzle()
    {
        var input = File.ReadAllText("./Data/day06.txt");

        var marker = _day06.GetFirstMarker(input, 14);

        Assert.AreEqual(2564, marker);
    }
}
