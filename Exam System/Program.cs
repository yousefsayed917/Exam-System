namespace Exam_System
{
    internal class Program
    {
        public static void RunApp()
        {

            string s;
            Subject subject = new Subject();
            subject.CreateExam(subject.TypeOfExam());
            Console.Clear();
            s = subject.StartExam();
            if ((s == "Y" || s == "y"))
            {
                Console.Clear();
                subject.SubjectExam.ShowExam();
                Console.Clear();
                subject.SubjectExam.AfterFinishingExam();
            }
            else
                System.Environment.Exit(0);
        }
        static void Main(string[] args)
        {
            RunApp();
        }
    }
}
