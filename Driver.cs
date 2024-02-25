using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Pack
{
    internal class Driver : All_Courses
    {
        public Driver()
        {
            allcourse();
        }
        static void Main(string[] args)
        {
            int Do = -1;
            while (Do != 0)
            {
                Console.WriteLine("\nWhat do you want to Do?\n(1) Show All Courses\n(2) Search a course\n(3) Calculate CGPA\n(4) Show available courses\n(0) Close");
                string _fix = Console.ReadLine();
                if (int.TryParse(_fix, out _))
                {
                    Do = int.Parse(_fix);
                    if (Do == 1)
                    {
                        init.showCourses();
                    }
                    else if (Do == 2)
                    {
                        Console.WriteLine("Please Enter The Course Code.(e.g: CSC1102)");
                        string code = Console.ReadLine();
                        init.searchCourse(code.ToUpper());
                    }
                    else if (Do == 3)
                    {
                        init.cgpaCalculator();
                    }
                    else if (Do == 4)
                    {
                        init.showAvaCourse();
                    }
                    else if (Do == 0)
                    {
                        Console.WriteLine("Thanks...");
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a Valid Option!!!");
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid Option!!!");
                }
            }
        }
    }
}
