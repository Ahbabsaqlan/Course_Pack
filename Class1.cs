using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Pack
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            int completedCourses;
            bool check = false;
            do
            {
                Console.WriteLine("Please Enter How Many Courses You Have Completed Already");
                string fix = Console.ReadLine();
                if (int.TryParse(fix, out _))
                {
                    completedCourses = int.Parse(Console.ReadLine());
                    Console.WriteLine("Your Completed Courses: "+completedCourses);
                    check = true;
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid Number...");
                }
            }
            while (check == false);

            Console.WriteLine("Please Enter How Many Courses You Have Registered?");
            int? registeredCourses = int.Parse(Console.ReadLine());
            Console.WriteLine("Your Completed Courses: " + registeredCourses);

        }
    }
}
