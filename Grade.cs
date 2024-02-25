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
            this.grade = gradeName;
            if(gradeName == "A+" || gradeName == "a+")
            {
                this.gradeValue = 4;
            }
            else if (gradeName == "A" ||  gradeName == "a")
            {
                this.gradeValue = 3.75f;
            }
            else if (gradeName == "B+" || gradeName == "b+")
            {
                this.gradeValue = 3.5f;
            }
            else if (gradeName == "B" || gradeName == "b")
            {
                this.gradeValue = 3.25f;
            }
            else if (gradeName == "C+" || gradeName == "c+")
            {
                this.gradeValue = 3.00f;
            }
            else if (gradeName == "c" || gradeName == "c")
            {
                this.gradeValue = 2.75f;
            }
            else if (gradeName == "D+" || gradeName == "d+")
            {
                this.gradeValue = 2.5f;
            }
            else if (gradeName == "D" || gradeName == "d")
            {
                this.gradeValue = 2.25f;
            }
            else if (gradeName == "F" || gradeName == "f")
            {
                this.gradeValue = 0.00f;
            }
            else
            {
                this.gradeValue = 0.00f;
            }
        }

    }
}
