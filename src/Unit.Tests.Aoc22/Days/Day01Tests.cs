namespace Unit.Tests.Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/1
**/
[TestClass]
public class Day01Tests
{
    private const string _exampleData = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";

    private Day07 _day01;

    [TestInitialize]
    public void Initialize()
    {
        _day01 = new Day07();
    }

    [TestMethod]
    public void PartOneExample()
    {
        var calories = _exampleData;

        var aggregatedCalories = _day01.Parse(calories);
        var highestCalorie = _day01.GetTop(1, aggregatedCalories);

        Assert.AreEqual(24000, highestCalorie);
    }

    [TestMethod]
    public void PartOnePuzzle()
    {
        var calories = File.ReadAllText("./Data/day01.txt");

        var aggregatedCalories = _day01.Parse(calories);
        var highestCalorie = _day01.GetTop(1, aggregatedCalories);
        
        Assert.AreEqual(68442, highestCalorie);
    }

    [TestMethod]
    public void PartTwoExample()
    {
        var calories = _exampleData;

        var aggregatedCalories = _day01.Parse(calories);
        var combinedTopCalories = _day01.GetTop(3, aggregatedCalories);

        Assert.AreEqual(45000, combinedTopCalories);
    }

    [TestMethod]
    public void PartTwoPuzzle()
    {
        var calories = File.ReadAllText("./Data/day01.txt");

        var aggregatedCalories = _day01.Parse(calories);
        var combinedTopCalories = _day01.GetTop(3, aggregatedCalories);

        Assert.AreEqual(204837, combinedTopCalories);
    }
}
