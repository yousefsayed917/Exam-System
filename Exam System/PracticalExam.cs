using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    internal class PracticalExam : Exam
    {
        public override void ShowRightAnwers()
        {
            for (int i = 0; i < MCQQuestions.Count; i++)
            {
                Console.WriteLine($"Q{i + 1}");
                Console.WriteLine(MCQQuestions[i].RightAnswerId);
            }
        }
        public override void CreateExamType()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                MCQQuestions.Add(CreateMCQQuestion());
            }
        }
        public override void AfterFinishingExam()
        {
            for (int i = 0; i < MCQQuestions.Count; i++)
            {
                Answer rightAnswer = new Answer();
                rightAnswer = MCQQuestions[i].Answers[MCQQuestions[i].RightAnswerId - 1];
                Console.WriteLine($"Right Answer Of Question {i + 1}=> {rightAnswer.AnswerText}");
            }
        }
    }
}
