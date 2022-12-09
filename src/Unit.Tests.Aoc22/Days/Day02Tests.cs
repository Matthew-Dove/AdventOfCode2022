using System;

namespace Unit.Tests.Aoc22.Days;

/**
 * https://adventofcode.com/2022/day/2
**/
[TestClass]
public class Day02Tests
{
    private const string _exampleData = @"A Y
B X
C Z";

    private Day02 _day02;

    [TestInitialize]
    public void Initialize()
    {
        _day02 = new Day02();
    }

    [TestMethod]
    public void PartOneExample()
    {
        var guide = _exampleData;

        var playbook = _day02.ParsePartOne(guide);
        var shapeScore = _day02.ScoreShape(playbook);
        var roundScore = _day02.ScoreRound(playbook);
        var totalScore = shapeScore + roundScore;

        Assert.AreEqual(15, totalScore);
    }

    [TestMethod]
    public void PartOnePuzzle()
    {
        var guide = File.ReadAllText("./Data/day02.txt");

        var playbook = _day02.ParsePartOne(guide);
        var shapeScore = _day02.ScoreShape(playbook);
        var roundScore = _day02.ScoreRound(playbook);
        var totalScore = shapeScore + roundScore;

        Assert.AreEqual(13009, totalScore);
    }

    [TestMethod]
    public void PartTwoExample()
    {
        var guide = _exampleData;

        var playbook = _day02.ParsePartTwo(guide);
        var shapeScore = _day02.ScoreShape(playbook);
        var roundScore = _day02.ScoreRound(playbook);
        var totalScore = shapeScore + roundScore;

        Assert.AreEqual(12, totalScore);
    }

    [TestMethod]
    public void PartTwoPuzzle()
    {
        var guide = File.ReadAllText("./Data/day02.txt");

        var playbook = _day02.ParsePartTwo(guide);
        var shapeScore = _day02.ScoreShape(playbook);
        var roundScore = _day02.ScoreRound(playbook);
        var totalScore = shapeScore + roundScore;

        Assert.AreEqual(10398, totalScore);
    }
}
