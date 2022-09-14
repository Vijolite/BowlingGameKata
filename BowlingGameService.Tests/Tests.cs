using FluentAssertions;
using BowlingGameService;

namespace BowlingGameService.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGeneralCase_NoStrikesNoSpadesNoMissed()
        {
            var bowlingGame = new Game("3/4 3/4 3/4 3/4 1/2 1/2 1/2 1/2 1/2 1/2");
            int total = bowlingGame.CalculateTotal();
            int expectedResult = 46;
            total.Should().Be(expectedResult);
        }
        [Test]
        public void TestGeneralCase_ContainsMissingTriesAsSecondPosition()
        {
            var bowlingGame = new Game("3- 3- 3- 3- 1/2 1/2 1/2 1/2 1/2 1/2");
            int total = bowlingGame.CalculateTotal();
            int expectedResult = 30;
            total.Should().Be(expectedResult);
        }
        [Test]
        public void testgeneralcase_containsmissingtriesasfirstposition()
        {
            var bowlingGame = new Game("-/- -/- -/- -/- -/2 1/2 1/2 1/2 1/2 1/2");
            int total = bowlingGame.CalculateTotal();
            int expectedResult = 17;
            total.Should().Be(expectedResult);
        }
        [Test]
        public void testSpareAtMiddle()
        {
            var bowlingGame = new Game("1/1 1/1 1/1 3/ 1/1 1/2 1/2 1/2 1/2 1/2");
            int total = bowlingGame.CalculateTotal();
            int expectedResult = 34;
            total.Should().Be(expectedResult);
        }
        [Test]
        public void testSpareAtThe10thTurn_1()
        {
            var bowlingGame = new Game("1/1 1/1 1/1 3/ 1/1 1/2 1/2 1/2 1/2 1/ 2/2");
            int total = bowlingGame.CalculateTotal();
            int expectedResult = 43;
            total.Should().Be(expectedResult);
        }
        [Test]
        public void TestStrikeAtMiddle()
        {
            var bowlingGame = new Game("1/1 1/1 1/1 X 1/1 1/2 1/2 1/2 1/2 1/-");
            int total = bowlingGame.CalculateTotal();
            int expectedResult = 33;
            total.Should().Be(expectedResult);
        }
        [Test]
        public void TestStrikeAtThe10thTurn()
        {
            var bowlingGame = new Game("1/1 1/1 1/1 -/- 1/1 1/2 1/2 1/2 1/2 X 1/2");
            int total = bowlingGame.CalculateTotal();
            int expectedResult = 33;
            total.Should().Be(expectedResult);
        }
        [Test]
        public void TestSpareAtThe10thTurn_2()
        {
            var bowlingGame = new Game("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/-");
            int total = bowlingGame.CalculateTotal();
            int expectedResult = 150;
            total.Should().Be(expectedResult);
        }
        [Test]
        public void Test_12_Strikes()
        {
            var bowlingGame = new Game("X X X X X X X X X X X X");
            int total = bowlingGame.CalculateTotal();
            int expectedResult = 300;
            total.Should().Be(expectedResult);
        }

    }
}
