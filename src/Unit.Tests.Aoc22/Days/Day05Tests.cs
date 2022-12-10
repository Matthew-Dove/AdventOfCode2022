namespace Unit.Tests.Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/5
**/
[TestClass]
public class Day05Tests
{
    private const string _exampleData = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";

    private Day05 _day05;

    [TestInitialize]
    public void Initialize()
    {
        _day05 = new Day05();
    }

    [TestMethod]
    public void PartOneExample()
    {
        var input = _exampleData;

        var cargo = _day05.Parse(input);
        cargo = _day05.Move(cargo);
        var crates = _day05.GetTopCrates(cargo);

        Assert.AreEqual("CMZ", crates);
    }

    [TestMethod]
    public void PartOnePuzzle()
    {
        var input = File.ReadAllText("./Data/day05.txt");

        var cargo = _day05.Parse(input);
        cargo = _day05.Move(cargo);
        var crates = _day05.GetTopCrates(cargo);

        Assert.AreEqual("RNZLFZSJH", crates);
    }

    [TestMethod]
    public void PartTwoExample()
    {
        var input = _exampleData;

        var cargo = _day05.Parse(input);
        cargo = _day05.MovePartTwo(cargo);
        var crates = _day05.GetTopCrates(cargo);

        Assert.AreEqual("MCD", crates);
    }

    [TestMethod]
    public void PartTwoPuzzle()
    {
        var input = File.ReadAllText("./Data/day05.txt");

        var cargo = _day05.Parse(input);
        cargo = _day05.MovePartTwo(cargo);
        var crates = _day05.GetTopCrates(cargo);

        Assert.AreEqual("CNSFCGJSM", crates);
    }
}
