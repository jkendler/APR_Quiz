using Quiz.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jkendler_quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Game spiel = new Game();

            Question frage1 = new Question("Wann starb Otto von Bismarck?");
            Answer a = new Answer("1898", true);
            Answer b = new Answer("1897");
            Answer c = new Answer("1945");
            frage1.AddAnswer(a);
            frage1.AddAnswer(b);
            frage1.AddAnswer(c);
            spiel.AddQuestion(frage1);

            Question frage2 = new Question("Welches Tier ist schneller?");
            Answer aa = new Answer("Ente");
            Answer bb = new Answer("Lachs");
            Answer cc = new Answer("Leopard", true);
            frage2.AddAnswer(aa);
            frage2.AddAnswer(bb);
            frage2.AddAnswer(cc);
            spiel.AddQuestion(frage2);

            Question frage3 = new Question("Wo spielt Paulo Dybala?");
            Answer aaa = new Answer("Real Madrid");
            Answer bbb = new Answer("FC Bayern");
            Answer ccc = new Answer("Juventus Turin", true);
            frage3.AddAnswer(aaa);
            frage3.AddAnswer(bbb);
            frage3.AddAnswer(ccc);
            spiel.AddQuestion(frage3);

            var status = Convert.ToInt32(spiel.Status);
            var gamestatus = Convert.ToInt32(GameStatus.Active);



            while (spiel.Status == GameStatus.Active)
            {
                var frage = spiel.NextQuestion;

                var antworten = frage.Answers;

                Console.WriteLine();
                Console.WriteLine(frage.Text);


                foreach (var antwort in antworten)
                {
                    Console.WriteLine(antwort.Text);
                }


                Console.Write("Was ist die Antwort: ");
                int eingabee = Convert.ToInt32(Console.ReadLine());

                antworten[eingabee].IsChecked = true;

                spiel.ValidateCurrentQuestion();



            }

            if (spiel.Status == GameStatus.HasFinished)
            {
                Console.WriteLine("Gewonnen");
            }

            else if (spiel.Status == GameStatus.HasLost)
            {
                Console.WriteLine("Verloren");
            }

            else
            {
                Console.WriteLine("Spiel abgebrochen");
            }

        }
    }
}
