
using System;

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
        public int GetValue()
        {
            if (Try1 == 'X' || Try2 == 'S') return 10;
            else
            {
                int score1 = (Try1 != '-') ? int.Parse(Try1.ToString()) : 0;
                int score2 = (Try2 != '-') ? int.Parse(Try2.ToString()) : 0;
                return (score1 + score2);
            }
        }
        public int GetValueTry1()
        {
            if (Try1 == 'X' ) return 10;
            else return (Try1 != '-') ? int.Parse(Try1.ToString()) : 0;
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
            if (Turns[index].Try1 == 'X') return Turns[index].GetValue() + Turns[index + 1].GetValue();
            else if (Turns[index].Try2 == 'S') return Turns[index].GetValue() + Turns[index + 1].GetValueTry1();
            else return Turns[index].GetValue();
        }
        public int CalculateTotal()
        {
            int total = 0;
            for (int i =0; i<10;i++) //we are calculating only 10 first frames (last 2 will be used in case of spare\strake on the 10th
            {
                total += CalculateScoreOfOneTurn(i);
            }
            return total;
        }
    }
}
