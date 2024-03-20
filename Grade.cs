using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Pack
{
    internal class Grade
    {
        public float gradeValue;
        public string grade;


        public Grade(string gradeName)
        {
            grade = gradeName;
            if(gradeName == "A+")
            {
                gradeValue = 4f;
            }
            else if (gradeName == "A")
            {
                gradeValue = 3.75f;
            }
            else if (gradeName == "B+")
            {
                gradeValue = 3.5f;
            }
            else if (gradeName == "B")
            {
                gradeValue = 3.25f;
            }
            else if (gradeName == "C+")
            {
                gradeValue = 3.00f;
            }
            else if (gradeName == "c")
            {
                gradeValue = 2.75f;
            }
            else if (gradeName == "D+")
            {
                gradeValue = 2.5f;
            }
            else if (gradeName == "D")
            {
                gradeValue = 2.25f;
            }
            else if (gradeName == "F")
            {
                gradeValue = 0.00f;
            }
            else
            {
                gradeValue = 0.00f;
            }
        }

    }
}
