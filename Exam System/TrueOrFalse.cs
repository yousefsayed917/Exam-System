using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    internal class TrueOrFalse : Question
    {
        public override int CreateAnswer()
        {
            int num;
            bool flag;
            do
            {
                Console.WriteLine(" Enter The Answer Id (1 For True | 2 For False)");
                flag = int.TryParse(Console.ReadLine()!, out num) && (num == 1 || num == 2);
            } while (!flag);
            return num;
        }
        public override void CreateRightAnswer()
        {
            RightAnswerId = CreateAnswer();
        }
        public override void UserAnswer()
        {
            UserAnswerId = CreateAnswer();
        }
        public override void CreateChoices()
        {
            Answers.Add(new Answer { AnswerId = 1, AnswerText = "True" });
            Answers.Add(new Answer { AnswerId = 2, AnswerText = "False" });
        }
        public string DisplayTFAnswers()
        {
            return $"1-{Answers[0].AnswerText}\t2-{Answers[1].AnswerText}";
        }
        public override void CreateQuestion()
        {
            CreateHeader(2);
            CreateBody();
            CreateMark();
            CreateChoices();
            CreateRightAnswer();
        }


    }
}
