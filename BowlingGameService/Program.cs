namespace BowlingGameService
{
    public class Program
    {
        public static void Main()
        { 
            var bowlingGame1 = new Game(new Turn[] 
                               { new Turn('1', '2'), new Turn('1', '2'), new Turn('1', '2'), new Turn('1', '2'), new Turn('1', '2'),
                               new Turn('1', '2'), new Turn('1', '2'), new Turn('1', '2'), new Turn('1', '2'), new Turn('1', '2')
                               });
            bowlingGame1.PrintGame();

            var bowlingGame2 = new Game("3/4 3/4 3/4 3/4 1/2 1/2 1/2 1/2 1/2 1/2");
            bowlingGame2.PrintGame();
            Console.WriteLine(bowlingGame2.CalculateTotal());

            var bowlingGame3 = new Game("1/1 1/1 1/1 X 1/1 1/2 1/2 1/2 1/2 1/2");
            bowlingGame3.PrintGame();
            Console.WriteLine(bowlingGame3.CalculateTotal());
        }

    }
}