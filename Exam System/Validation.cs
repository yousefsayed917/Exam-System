using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    internal class Validation
    {
        public static bool IsString(string s)
        {
            int num;
            if (!string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s) && !(int.TryParse(s, out num)))
                return true;
            else
                return false;
        }
    }
}
