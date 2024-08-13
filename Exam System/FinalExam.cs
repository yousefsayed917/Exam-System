using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    internal class FinalExam : Exam
    {
        TimeSpan UserExamTime;
        public static List<TrueOrFalse> TFQuestions { get; set; } = new List<TrueOrFalse>();

        public static int TypeOfQuestion()
        {
            int num;
            bool flag;
            do
            {
                Console.WriteLine(" Enter The Type Of Question (1 For MCQ | 2 For True Or False)");
                flag = int.TryParse(Console.ReadLine()!, out num) && (num == 1 || num == 2);
            } while (!flag);
            return num;
        }
        public TrueOrFalse CreateTrueOrFalseQuestion()
        {
            Console.Clear();
            TrueOrFalse TF = new TrueOrFalse();
            TF.CreateQuestion();
            return TF;
        }
        public override void CreateExamType()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {

                if (TypeOfQuestion() == 1)
                {
                    MCQQuestions.Add(CreateMCQQuestion());
                }
                else
                {
                    TFQuestions.Add(CreateTrueOrFalseQuestion());
                }
            }
        }
        public override void ShowExam()
        {
            DateTime StartExamDateTime;
            DateTime EndExamDateTime;
            StartExamDateTime = DateTime.Now;

            for (int i = 0; i < MCQQuestions.Count; i++)
            {
                Console.WriteLine($"{MCQQuestions[i].Header}\tMark {MCQQuestions[i].Mark}");
                Console.WriteLine(MCQQuestions[i].Body);
                Console.WriteLine(MCQQuestions[i].DisplayMCQAnswers());
                MCQQuestions[i].UserAnswer();
            }
            for (int i = 0; i < TFQuestions.Count; i++)
            {
                Console.WriteLine($"{TFQuestions[i].Header}\tMark {TFQuestions[i].Mark}");
                Console.WriteLine(TFQuestions[i].Body);
                Console.WriteLine(TFQuestions[i].DisplayTFAnswers());
                TFQuestions[i].UserAnswer();
            }
            EndExamDateTime = DateTime.Now;
            UserExamTime = EndExamDateTime - StartExamDateTime;
        }

        public override void AfterFinishingExam()
        {
            for (int i = 0; i < MCQQuestions.Count; i++)
            {
                Console.WriteLine($"Qusetion {i + 1} => {MCQQuestions[i].Body}");
                Answer userAnswer = new Answer();
                userAnswer = MCQQuestions[i].Answers[MCQQuestions[i].UserAnswerId - 1];
                Answer rightAnswer = new Answer();
                rightAnswer = MCQQuestions[i].Answers[MCQQuestions[i].RightAnswerId - 1];
                Console.WriteLine($"Your Answer =>{userAnswer.AnswerText}");
                Console.WriteLine($"Right Answer =>{rightAnswer.AnswerText}");
            }
            for (int i = 0; i < TFQuestions.Count; i++)
            {
                Console.WriteLine($"Qusetion {i + 1}=>{TFQuestions[i].Body}");
                Answer userAnswer = new Answer();
                userAnswer = TFQuestions[i].Answers[TFQuestions[i].UserAnswerId - 1];
                Answer rightAnswer = new Answer();
                rightAnswer = TFQuestions[i].Answers[TFQuestions[i].RightAnswerId - 1];
                Console.WriteLine($"Your Answer =>{userAnswer.AnswerText}");
                Console.WriteLine($"Right Answer =>{rightAnswer.AnswerText}");
            }
            CalculateGrade();
            Console.WriteLine($"Time = {UserExamTime}");
        }
        public void CalculateGrade()
        {
            int FullMark = 0;
            int UserMark = 0;
            for (int i = 0; i < MCQQuestions.Count; i++)
            {
                FullMark += MCQQuestions[i].Mark;
                if (MCQQuestions[i].UserAnswerId == MCQQuestions[i].RightAnswerId)
                {
                    UserMark += MCQQuestions[i].Mark;
                }
            }
            for (int i = 0; i < TFQuestions.Count; i++)
            {
                FullMark += TFQuestions[i].Mark;
                if (TFQuestions[i].UserAnswerId == TFQuestions[i].RightAnswerId)
                {
                    UserMark += TFQuestions[i].Mark;
                }
            }
            Console.WriteLine($"Your Grade Is {UserMark} From {FullMark}");
        }
    }
}
