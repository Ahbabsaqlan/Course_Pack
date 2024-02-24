using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Course_Pack
{
    internal class All_Courses : Course
    {
        public static int courseSize=57;
        public static int completedCourses;
        public static Course[] courses = new Course[courseSize];
        public static Course[] CompletedCourses = new Course[courseSize];
        public static Course[] AvailableCourses= new Course[courseSize];
        public static Course[] registerCourse=new Course[courseSize];
        public  Course[] temp = new Course[courseSize];

        public void showCourses()
        {
            Console.WriteLine("All Courses For CSE Below...\n");
            for (int i = 0; i < courses.Length; i++)
            {
                Console.WriteLine("(" + (i + 1) + ") "+courses[i].Name + " , " + courses[i].Code + " , " + courses[i].Credit);
            }
        }
        public void searchCourse(string courseCode)
        {
            bool check = false;
            for (int i = 0; i < courses.Length; i++)
            {
                if (courses[i].Code == courseCode)
                {
                    Console.WriteLine("Course Name: " + courses[i].Name + "\nCredit: " + courses[i].Credit + "\nFirst PreRequisite: " + courses[i].FirPreReq.Name + "\nSecond PreRequisite: " + courses[i].SecPreReq.Name + "\n");
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                Console.WriteLine("Oops..It's seems Wrong.\nMaybe Your Given Course Code Is Wrong Or In MisFormat\nTry Again Carefully...");
            }
        }

        public int addComCourse()
        {
            
            int index = 0;
            bool check = false;
            do
            {
                Console.WriteLine("Please Enter How Many Courses You Have Completed Already");
                completedCourses = int.Parse(Console.ReadLine());
                if (completedCourses < courseSize + 1 && completedCourses > 0)
                {
                    check = true;
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid Number...");
                }
            }
            while (check == false);

            Console.WriteLine("Please Add The Courses You Have Done Erlier And Enter The Grade For Every Course.\n(e.g:Select Course Grade A+ or a+  to  F or f And Skip Course By (>) )\nN.B:Please Enter The Grade Carefully For the Accurecy of Your CGPA.");
            for (int i = 0; i < courses.Length; i++)
            {
                if (index < completedCourses)
                {
                    Console.WriteLine("Course Name: " + courses[i].Name);
                    bool flag = false;
                    do
                    {
                        Console.WriteLine("Grade Obtained: ");
                        string addcourse = Console.ReadLine();
                        if (addcourse == ">")
                        {
                            flag = true;
                        }
                        else if (addcourse == "A+" || addcourse == "a+" || addcourse == "A" || addcourse == "a" || addcourse == "B+" || addcourse == "b+" || addcourse == "B" || addcourse == "b" || addcourse == "C+" || addcourse == "c+" || addcourse == "C" || addcourse == "c" || addcourse == "D+" || addcourse == "d+" || addcourse == "D" || addcourse == "d" || addcourse == "F" || addcourse == "f")
                        {
                            CompletedCourses[index++] = courses[i];
                            CompletedCourses[index - 1].Grade = new Grade(addcourse);
                            flag = true;
                        }
                        else
                        {
                            Console.WriteLine("Please Enter Valid Option");
                        }

                    }
                    while (flag == false);
                }
                else
                {
                    break;
                }

            }
            for (int i = 0; i < completedCourses; i++)
            {
                Console.WriteLine("(" + (i + 1) + ") " + CompletedCourses[i].Name + "\n ->  " + CompletedCourses[i].Code + "\n ->  " + CompletedCourses[i].Credit + "\n");
            }
            return index;
        }

        public void cgpaCalculator()
        {
            float cgpa = 0.0f;
            int credit = 0;
            int index=addComCourse();
            for (int i = 0; i < index; i++)
            {
                if (CompletedCourses[i].Credit[0] == '3')
                {
                    cgpa += CompletedCourses[i].Grade.gradeValue*3;
                }
                else if(CompletedCourses[i].Credit[0] == '2')
                {
                    cgpa += CompletedCourses[i].Grade.gradeValue * 2;
                }
                else
                {
                    cgpa += CompletedCourses[i].Grade.gradeValue;
                }
                char cr = CompletedCourses[i].Credit[0];
                credit += (int)Char.GetNumericValue(cr);
            }
            Console.WriteLine("Your CGPA: " + (cgpa/credit)+"\nYour Total Credit Completed: "+credit+"\n");
            
        }
        private void addcourse()
        {
            if (completedCourses < courseSize-1)
            {
                int pool = 0, counter = 0;

                for (int j = 0; j < courses.Length; j++)
                {
                    bool fun = false;
                    for (int k = 0; k < completedCourses; k++)
                    {
                        if (courses[j].Code == CompletedCourses[k].Code)
                        {
                            fun = true;
                        }
                    }
                    if (fun == false)
                    {
                        temp[pool++] = courses[j];
                    }
                }
                for (int i = 0; i < pool; i++)
                {
                    if (temp[i].FirPreReq.Name == "N/A")
                    {
                        AvailableCourses[counter++] = temp[i];
                    }
                    else if (temp[i].SecPreReq.Name == "N/A")
                    {
                        for (int j = 0; j < completedCourses; j++)
                        {
                            if (temp[i].FirPreReq == CompletedCourses[j])
                            {
                                AvailableCourses[counter++] = temp[i];
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < completedCourses; j++)
                        {
                            if (temp[i].FirPreReq == CompletedCourses[j])
                            {
                                for (int k = 0; k < completedCourses; k++)
                                {
                                    if (temp[i].SecPreReq == CompletedCourses[k])
                                    {
                                        AvailableCourses[counter++] = temp[i];
                                        break;
                                    }
                                }
                                break;
                            }

                        }
                    }
                }
                Console.WriteLine("Your Available Courses For Next Semester: \nCredit (Lec-Sci-Com-Lan-Stu)\n");
                for (int i = 0; i < counter; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ") " + AvailableCourses[i].Name + "\n ->  " + AvailableCourses[i].Code + "\n ->  " + AvailableCourses[i].Credit + "\n");
                }



                Console.WriteLine("Do You Want to Take Course To Calculate The Total Cost And See The Available Course After Takeing Those Course?\n");
                bool checker = false;
                do
                {
                    Console.WriteLine("Press (1) Yes (0) No");
                    int fix = int.Parse(Console.ReadLine());
                    if (fix == 1)
                    {
                        registerCourses(counter);
                        checker = true;
                    }
                    else if (fix == 0)
                    {
                        checker = true;
                    }
                    else
                    {
                        Console.WriteLine("Please Enter A Valid Option\n");
                    }
                }
                while (checker == false);
            }
            else
            {
                Console.WriteLine("Congrats...\nYour Bachelor of Science in Computer Science and Enginnering is Done...\n");
            }
        }
        public void showAvaCourse()
        {
            cgpaCalculator();
            addcourse();
        }

        public void registerCourses(int counter)
        {
            int num = 0;
            int cost = 0, totalCredit = 0, labCost = 0;
            int index = completedCourses;
            
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("(" + (i + 1 )+ ") " + AvailableCourses[i].Name + "\n ->  " + AvailableCourses[i].Code + "\n ->  " + AvailableCourses[i].Credit + "\n");
                bool choice = false;
                do
                {
                    Console.WriteLine("To Take Course Press (1) Yes (0) No");
                    int choose = int.Parse(Console.ReadLine());

                    if (choose == 1)
                    {
                        registerCourse[num++] = AvailableCourses[i];
                        CompletedCourses[completedCourses++] = AvailableCourses[i];
                        char cr = AvailableCourses[i].Credit[0];
                        totalCredit += (int)Char.GetNumericValue(cr);
                        cost += (int)Char.GetNumericValue(cr) * 5500;
                        if (AvailableCourses[i].Credit[1] == '1')
                        {
                            labCost += 2000;
                        }
                        else if (AvailableCourses[i].Credit[2] == '1')
                        {
                            labCost += 2500;
                        }
                        choice = true;
                    }
                    else if (choose == 0)
                    {
                        choice = true;
                    }
                    else
                    {
                        Console.WriteLine("Please Enter A Valid Option\n");
                    }
                }
                while (choice==false);
            }
            Console.WriteLine("You Have Taken Those Courses: \nCredit (Lec-Sci-Com-Lan-Stu)\n");
            for (int i = 0; i < num; i++)
            {
                
                Console.WriteLine("(" +( i + 1) + ") " + registerCourse[i].Name + "\n ->  " + registerCourse[i].Code + "\n ->  " + registerCourse[i].Credit + "\n");
            }
            Console.WriteLine("Total Credit Taken: " + totalCredit +"\n"+ "\nYou Have to Pay " + ((cost / 2) + labCost + 3500) + "Tk In The First Instalment.\nYou Have to Pay " + (cost / 4) + "Tk In The Second Instalment.\nYou Have to Pay " + (cost / 4) + "Tk In The Third Instalment\n");
            Console.WriteLine("Total Cost: " + (cost + labCost + 3500 )+ "\n");
            if (completedCourses != 57)
            {
                addcourse();
            }
            else
            {
                Console.WriteLine("Congrats...\nYour Bachelor of Science in Computer Science and Enginnering is Done...");
            }
        }
    }
}
