using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    internal abstract class Question
    {
        public string Header { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public int Mark { get; set; }
        public int RightAnswerId { get; set; }
        public int UserAnswerId { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public void CreateHeader(int num)
        {
            if (num == 1)
                Header = "MCQ Question";
            else
                Header = "True Or False Question";

            Console.WriteLine(Header);
        }
        public void CreateBody()
        {
            do
            {
                Console.WriteLine("Enter The Body Of Question : ");
                Body = Console.ReadLine()!;
            } while (!Validation.IsString(Body));
        }
        public void CreateMark()
        {
            int num;
            bool flag;
            do
            {
                Console.WriteLine("Enter The Question Mark : ");
                flag = int.TryParse(Console.ReadLine()!, out num) && num > 0;
            } while (!flag);
            Mark = num;
        }
        public abstract void CreateQuestion();
        public abstract void CreateRightAnswer();
        public abstract void UserAnswer();
        public abstract int CreateAnswer();
        public abstract void CreateChoices();

    }
}
