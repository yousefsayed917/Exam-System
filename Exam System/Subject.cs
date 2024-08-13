using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    internal class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Exam SubjectExam { get; set; }
        public Subject() { SubjectExam = new Exam(); }
        public int TypeOfExam()
        {
            int num;
            bool flag;
            do
            {
                Console.WriteLine(" Enter The Type Of Exam (1 For Practical | 2 For Final)");
                flag = int.TryParse(Console.ReadLine()!, out num) && (num == 1 || num == 2);
            } while (!flag);
            return num;
        }
        public void CreateExam(int num)
        {
            if (num == 1)
                SubjectExam = new PracticalExam();
            else
                SubjectExam = new FinalExam();

            SubjectExam.TimeOfExam();
            SubjectExam.QuestionNumber();
            Console.Clear();
            SubjectExam.CreateExamType();
        }
        public string StartExam()
        {
            bool flag;
            string s;
            do
            {
                Console.WriteLine("Do You Want To Start Exam (Y/N)");
                s = Console.ReadLine()!;
                flag = Validation.IsString(s) && ((s == "Y" || s == "y") || (s == "N" || s == "n"));
            } while (!flag);
            return s;
        }
    }
}
