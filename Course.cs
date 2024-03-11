using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Pack
{
    internal class Course
    {
        public  string Name { get; } 
        public string Code { get; }
        public Course FirPreReq { get; }
        public Course SecPreReq { get; }
        public string Credit { get; }

        public Grade Grade { get; set; }

        public string Retake ;


        public Course(string name, string code, Course firPreReq, Course secPreReq, string credit)
        {
            Name = name;
            Code = code;
            FirPreReq = firPreReq;
            SecPreReq = secPreReq;
            Credit = credit;
            Retake = null;
        }
        public Course()
        {
            Name = "N/A" ;
        }
    }
}
