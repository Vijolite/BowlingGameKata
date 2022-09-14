
namespace BowlingGameService
{
    public struct Turn
    {
        public char Try1;
        public char Try2;
        public Turn (char try1, char try2)
        {
            Try1 = try1; Try2 = try2;
        }
        public string GetTurn()
        {
            string output;
            if (Try1 == 'X') output = ""+Try1;
            else if (Try2 == 'S') output = Try1 + "\\";
            else if (Try2 == '-') output = (Try1 + "-");
            else output = (Try1 + "\\" + Try2);
            return output;
        }
    }
    public class Game
    {
        public Turn[] Turns { get; private set; }
        public Game(Turn[] turns)
        {
            Turns = turns;
        }

        public Game(string input)
        {
            Turns = ConvertStringToTurns(input);
        }
        private Turn[] ConvertStringToTurns (string input)
        {
            var arrayOfTurns = input.Split();
            var turns = new Turn[arrayOfTurns.Length];
            int index = 0;
            foreach (string item in arrayOfTurns)
            {
                char first; char second;
                if (item[0] == 'X') { first = 'X'; second = '0'; } //strike
                else if (item[1] == '-') { first = item[0]; second = item[1]; } //missed the 2nd
                else if (item.Length == 2 && item[1] == '/') { first = item[0]; second = 'S'; } //spare
                else { first = item[0]; second = item[2]; } //general case - two numbers or -/number

                Turn turn = new Turn(first, second);
                turns[index] = turn;
                index++;
            }
            return turns;
        }
        public void PrintGame()
        {
            string output = "";
            foreach (var turn in Turns)
            {
                output += turn.GetTurn()+" ";
            }
            Console.WriteLine(output);
        }

        private int CalculateScoreOfOneTurn (int index)
        {
            int score1=0;
            int score2=0;

            if (Turns[index].Try2 != 'S')
            {
                score1 = (Turns[index].Try1 != '-') ? int.Parse(Turns[index].Try1.ToString()) : 0;
                score2 = (Turns[index].Try2 != '-') ? int.Parse(Turns[index].Try2.ToString()) : 0;               
            }
            else
                score2 = 10 + ((Turns[index + 1].Try1 != '-') ? int.Parse(Turns[index + 1].Try1.ToString()) : 0);
            return (score1 + score2);
        }
        public int CalculateTotal()
        {
            int total = 0;
            for (int i =0; i<Turns.Length;i++)
            {
                total += CalculateScoreOfOneTurn(i);
            }
            return total;
        }
    }
}
