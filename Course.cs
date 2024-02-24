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

        public Grade Grade;


        public Course(string name, string code, Course firPreReq, Course secPreReq, string Credit)
        {
            this.Name = name;
            this.Code = code;
            this.FirPreReq = firPreReq;
            this.SecPreReq = secPreReq;
            this.Credit = Credit;
        }
        public Course()
        {
            this.Name = "N/A" ;
        }
    }
}
