using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    internal class Exam
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<MCQ> MCQQuestions { get; set; } = new List<MCQ>();
        public void TimeOfExam()
        {
            int num;
            bool flag;
            do
            {
                Console.WriteLine("Enter The Time For Exam From (30 min to 180 min)");
                flag = int.TryParse(Console.ReadLine()!, out num) && (num >= 30 && num <= 180);
            } while (!flag);
            Time = num;
        }
        public void QuestionNumber()
        {
            int num;
            bool flag;
            do
            {
                Console.WriteLine("Enter The Number Of Question");
                flag = int.TryParse(Console.ReadLine()!, out num) && num > 0;
            } while (!flag);
            NumberOfQuestions = num;
        }
        public MCQ CreateMCQQuestion()
        {
            Console.Clear();
            MCQ Q1 = new MCQ();
            Q1.CreateQuestion();
            return Q1;
        }
        public virtual void ShowExam()
        {
            for (int i = 0; i < MCQQuestions.Count; i++)
            {
                Console.WriteLine($"{MCQQuestions[i].Header}\tMark {MCQQuestions[i].Mark}");
                Console.WriteLine(MCQQuestions[i].Body);
                Console.WriteLine(MCQQuestions[i].DisplayMCQAnswers());
                MCQQuestions[i].UserAnswer();
            }
        }
        public virtual void CreateExamType() { }
        public virtual void ShowRightAnwers() { }
        public virtual void AfterFinishingExam() { }
    }
}
