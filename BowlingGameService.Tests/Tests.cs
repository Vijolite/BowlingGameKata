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
        public void TestGeneralCase_ContainsMissingTries()
        {
            var bowlingGame = new Game("3/- 3/- 3/- 3/- 1/2 1/2 1/2 1/2 1/2 1/2");
            int total = bowlingGame.CalculateTotal();
            int expectedResult = 30;
            total.Should().Be(expectedResult);
        }
    }
}
