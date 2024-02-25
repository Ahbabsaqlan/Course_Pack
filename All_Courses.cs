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
        public  Course[] temp = new Course[courseSize+20];

        public static Driver init = new Driver(); // Driver Object
       

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
                Console.WriteLine("\nOops..It's seems Wrong.\nMaybe Your Given Course Code Is Wrong Or In MisFormat\nTry Again Carefully...\n");
            }
        }

        private int addComCourse()
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
                    Console.WriteLine("\nCourse Name: " + courses[i].Name);
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
            Console.WriteLine("\nYour Completed Courses: \n");
            for (int i = 0; i < completedCourses; i++)
            {
                Console.WriteLine("(" + (i + 1) + ") " + CompletedCourses[i].Name + "\nCode ->  " + CompletedCourses[i].Code + "\nCredit ->  " + CompletedCourses[i].Credit + "\nGrade ->  " + (CompletedCourses[i].Grade.grade.ToUpper()) + "\n");
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
                            if (courses[j].Grade.gradeValue <= 2.5)
                            {
                                temp[pool++] = courses[j];
                                temp[pool-1].Retake = "(Retake)";
                            }
                            fun = true;
                            break;
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
                    if (AvailableCourses[i].Retake != null)
                    {
                        Console.WriteLine("(" + (i + 1) + ") " + AvailableCourses[i].Name +"   "+ AvailableCourses[i].Retake + "\nCode   ->  " + AvailableCourses[i].Code + "\nCredit ->  " + AvailableCourses[i].Credit + "\nGrade  ->  " + AvailableCourses[i].Grade.grade + "\n");
                    }
                    else
                    {
                        Console.WriteLine("(" + (i + 1) + ") " + AvailableCourses[i].Name + "\nCode   ->  " + AvailableCourses[i].Code + "\nCredit ->  " + AvailableCourses[i].Credit + "\n");
                    }
                }



                Console.WriteLine("Do You Want to Take Course To Calculate The Total Cost And See The Available Course After Takeing Those Course?\n");
                bool checker = false;
                do
                {
                    int fix;
                    Console.WriteLine("Press (1) Yes (0) No");
                    string _fix=Console.ReadLine();
                    if(int.TryParse(_fix, out _))
                    {
                        fix = int.Parse(_fix);
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

        private void registerCourses(int counter)
        {
            int num = 0;
            int cost = 0, totalCredit = 0, labCost = 0;
            
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("(" + (i + 1 )+ ") " + AvailableCourses[i].Name + "\nCode   ->  " + AvailableCourses[i].Code + "\nCredit ->  " + AvailableCourses[i].Credit + "\n");
                bool choice = false;
                do
                {
                    Console.WriteLine("To Take Course Press (1) Yes (0) No");
                    string _fix = Console.ReadLine();
                    if (int.TryParse(_fix, out _))
                    {
                        int choose = int.Parse(_fix);

                        if (choose == 1)
                        {
                            registerCourse[num++] = AvailableCourses[i];
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
                
                Console.WriteLine("(" +( i + 1) + ") " + registerCourse[i].Name + "\nCode   ->  " + registerCourse[i].Code + "\nCredit ->  " + registerCourse[i].Credit + "\n");
            }
            Console.WriteLine("Total Credit Taken: " + totalCredit +"\n"+ "\nYou Have to Pay " + ((cost / 2) + labCost + 3500) + "Tk In The First Instalment.\nYou Have to Pay " + (cost / 4) + "Tk In The Second Instalment.\nYou Have to Pay " + (cost / 4) + "Tk In The Third Instalment\n");
            Console.WriteLine("Total Cost: " + (cost + labCost + 3500 )+ "\n");
            if (completedCourses != 57)
            {
                bool pick = false;
                for (int i = 0; i < num;i ++)
                {
                    if (registerCourse[i].Retake == null)
                    {
                        pick = true;
                        CompletedCourses[completedCourses++] = registerCourse[i];
                    }
                    else
                    {
                        pick=false;
                        Console.WriteLine("\nPlease Add The Grade Of The Retake Courses You Added...\n");
                        for(int j=0;j< num;j++)
                        {
                            if (registerCourse[j].Retake != null)
                            {
                                Console.WriteLine("(" + (i + 1) + ") " + registerCourse[i].Name + "\nCode           ->  " + registerCourse[i].Code + "\nCredit         ->  " + registerCourse[i].Credit + "\nPrevious Grade ->  " + registerCourse[i].Grade.grade + "\n");
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
                                        registerCourse[j].Grade = new Grade(addcourse);
                                        CompletedCourses[completedCourses++] = registerCourse[j];
                                        flag = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please Enter Valid Option");
                                    }

                                }
                                while (flag == false);
                            }

                        }
                        addcourse();
                    }
                }
                if (pick)
                {
                    addcourse();
                }
            }
            else
            {
                Console.WriteLine("Congrats...\nYour Bachelor of Science in Computer Science and Enginnering is Done...");
            }
        }

        public void allcourse()
        {
            Course NP = new Course();     // NoPreRequisite Course Object

            courses[0] = new Course("DIFFERENTIAL CALCULUS & CO-ORDINATE GEOMETRY", "MAT1102", NP, NP, "30000"); // Course Object
            courses[1] = new Course("PHYSICS 1", "PHY1101", NP, NP, "30000");
            courses[2] = new Course("PHYSICS 1 LAB", "PHY1102", NP, NP, "11000");
            courses[3] = new Course("ENGLISH READING SKILLS & PUBLIC SPEAKING", "ENG1101", NP, NP, "30010");
            courses[4] = new Course("INTRODUCTION TO PROGRAMMING", "CSC1102", NP, NP, "30000");
            courses[5] = new Course("INTRODUCTION TO PROGRAMMING LAB", "CSC1103", NP, NP, "10100");
            courses[6] = new Course("INTRODUCTION TO COMPUTER STUDIES", "CSC1101", NP, NP, "10100");
            courses[7] = new Course("Discrete Mathematics", "CSC1204", courses[0], courses[4], "30000");
            courses[8] = new Course("INTEGRAL CALCULUS & ORDINARY DIFFERENTIAL EQUATIONS", "MAT1205", courses[0], NP, "30000");
            courses[9] = new Course("OBJECT ORIENTED PROGRAMMING 1", "CSC1205", courses[4], courses[5], "30100");
            courses[10] = new Course("PHYSICS 2", "PHY1203", courses[1], NP, "30000");
            courses[11] = new Course("PHYSICS 2 LAB", "PHY1204", courses[2], NP, "11000");
            courses[12] = new Course("ENGLISH WRITING SKILLS & COMMUNICATION", "ENG1202", courses[3], NP, "30010");
            courses[13] = new Course("INTRODUCTION TO ELECTRICAL CIRCUITS", "COE2101", courses[1], NP, "30000");
            courses[14] = new Course("INTRODUCTION TO ELECTRICAL CIRCUITS LAB", "COE2102", courses[2], NP, "11000");
            courses[15] = new Course("CHEMISTRY", "CHEM1101", courses[10], NP, "31000");
            courses[16] = new Course("COMPLEX VARIABLE,LAPLACE & Z-TRANSFORMATION", "MAT2101", courses[8], NP, "30000");
            courses[17] = new Course("INTRODUCTION TO DATABASE", "CSC2108", courses[9], NP, "30100");
            courses[18] = new Course("ELECTRONIC DEVICES", "EEE2103", courses[13], NP, "30000");
            courses[19] = new Course("ELECTRONIC DEVICES LAB", "EEE2104", courses[14], NP, "11000");
            courses[20] = new Course("PRINCIPLES OF ACCOUNTING", "BBA1102", courses[8], NP, "30000");
            courses[21] = new Course("DATA STRUCTURE", "CSC2106", courses[7], courses[9], "30000");
            courses[22] = new Course("DATA STRUCTURE LAB", "CSC2107", courses[7], courses[9], "10100");
            courses[23] = new Course("COMPUTER AIDED DESIGN & DRAFTING", "BAE2101", NP, NP, "10100");
            courses[24] = new Course("ALGORITHMS", "CSC2211", courses[21], courses[22], "30100");
            courses[25] = new Course("MATRICES, VECTORS, FOURIER ANALYSIS", "MAT2202", courses[16], NP, "30000");
            courses[26] = new Course("OBJECT ORIENTED ANALYSIS AND DESIGN", "CSC2209", courses[17], NP, "30000");
            courses[27] = new Course("OBJECT ORIENTED PROGRAMMING 2", "CSC2210", courses[17], courses[9], "30100");
            courses[28] = new Course("BANGLADESH STUDIES", "BAS2101", courses[6], NP, "30000");
            courses[29] = new Course("DIGITAL LOGIC AND CIRCUITS", "EEE3101", courses[18], NP, "30000");
            courses[30] = new Course("DIGITAL LOGIC AND CIRCUITS LAB", "EEE3102", courses[19], NP, "11000");
            courses[31] = new Course("COMPUTATIONAL STATISTICS AND PROBABILITY", "MAT3103", courses[16], NP, "30000");
            courses[32] = new Course("THEORY OF COMPUTATION", "CSC3113", courses[24], NP, "30000");
            courses[33] = new Course("PRINCIPLES OF ECONOMICS", "ECO3150", courses[31], NP, "20000");
            courses[34] = new Course("BUSINESS COMMUNICATION", "ENG2103", courses[28], NP, "30000");
            courses[35] = new Course("NUMERICAL METHODS FOR SCIENCE AND ENGINEERING", "MAT3101", courses[25], NP, "30000");
            courses[36] = new Course("DATA COMMUNICATION", "COE3103", courses[29], courses[30], "31000");
            courses[37] = new Course("MICROPROCESSOR AND EMBEDDED SYSTEM", "COE3104", courses[29], courses[30], "31000");
            courses[38] = new Course("SOFTWARE ENGINEERING", "CSC3112", courses[26], courses[27], "30100");
            courses[39] = new Course("ARTIFICIAL INTELLIGENCE AND EXPERT SYS.", "CSC3217", courses[24], courses[31], "30100");
            courses[40] = new Course("COMPUTER NETWORKS", "COE3206", courses[36], NP, "31000");
            courses[41] = new Course("COMPUTER ORGANIZATION AND ARCHITECTURE", "COE3205", courses[37], NP, "30100");
            courses[42] = new Course("OPERATING SYSTEM", "CSC3214", courses[24], courses[37], "30100");
            courses[43] = new Course("WEB TECHNOLOGIES", "CSC3215", courses[38], NP, "30100");
            courses[44] = new Course("ENGINEERING ETHICS", "EEE2216", courses[38], courses[37], "20000");
            courses[45] = new Course("COMPILER DESIGN", "CSC3216", courses[32], NP, "30100");
            courses[46] = new Course("COMPUTER GRAPHICS", "CSC4118", courses[24], courses[25], "30100");
            courses[47] = new Course("ENGINEERING MANAGEMENT", "MGT3202", courses[44], NP, "30000");
            courses[48] = new Course("RESEARCH METHODOLOGY", "CSC4197", courses[38], courses[36], "30000");
            courses[49] = new Course("THESIS / PROJECT", "CSC4298", courses[48], courses[44], "30000");
            courses[50] = new Course("INTERN", "CSC4299", courses[49], NP, "30000");
            courses[51] = new Course("ADVANCED PROGRAMMING WITH .NET (ELECTIVE)", "CSC4164", courses[43], NP, "30100");
            courses[52] = new Course("ADVANCED PROGRAMMING IN WEB TECHNOLOGY (ELECTIVE)", "CSC4161", courses[43], NP, "30100");
            courses[53] = new Course("MOBILE APPLICATION DEVELOPMENT (ELECTIVE)", "CSC4272", courses[43], NP, "30100");
            courses[54] = new Course("MACHINE LEARNING (ELECTIVE)", "CSC4232", courses[39], NP, "30100");
            courses[55] = new Course("WIRELESS SENSOR NETWORKS (ELECTIVE)", "COE4233", courses[40], courses[36], "30100");
            courses[56] = new Course("INTRODUCTION TO DATA SCIENCE (ELECTIVE)", "CSC4180", courses[39], NP, "30100");
        }
    }
}
