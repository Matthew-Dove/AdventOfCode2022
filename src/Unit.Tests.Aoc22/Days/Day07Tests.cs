namespace Unit.Tests.Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/7
**/
[TestClass]
public class Day07Tests
{
    private const string _exampleData = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";

    private Day07 _day07;

    [TestInitialize]
    public void Initialize()
    {
        _day07 = new Day07();
    }

    [TestMethod]
    public void PartOneExample()
    {
        var input = _exampleData;

        var stdout = _day07.Parse(input);
        var directory = _day07.CreateDirectory(stdout);
        var size = _day07.GetSumOfDirectories(directory, 100000);

        Assert.AreEqual(95437, size);
    }

    [TestMethod]
    public void PartOnePuzzle()
    {
        var input = File.ReadAllText("./Data/day07.txt");

        var stdout = _day07.Parse(input);
        var directory = _day07.CreateDirectory(stdout);
        var size = _day07.GetSumOfDirectories(directory, 100000);

        Assert.AreEqual(1427048, size);
    }

    [TestMethod]
    public void PartTwoExample()
    {
        const int fileSystemSize = 70000000, updateSize = 30000000;
        var input = _exampleData;

        var stdout = _day07.Parse(input);
        var directory = _day07.CreateDirectory(stdout);
        var targetSize = updateSize - (fileSystemSize - directory.GetSize());
        var size = _day07.GetClosetDirectorySize(directory, targetSize);

        Assert.AreEqual(24933642, size);
    }

    [TestMethod]
    public void PartTwoPuzzle()
    {
        const int fileSystemSize = 70000000, updateSize = 30000000;
        var input = File.ReadAllText("./Data/day07.txt");

        var stdout = _day07.Parse(input);
        var directory = _day07.CreateDirectory(stdout);
        var targetSize = updateSize - (fileSystemSize - directory.GetSize());
        var size = _day07.GetClosetDirectorySize(directory, targetSize);

        Assert.AreEqual(2940614, size);
    }
}
