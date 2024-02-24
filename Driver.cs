using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Pack
{
    internal class Driver : All_Courses
    {

        static void Main(string[] args)
        {
            Driver init = new Driver(); // Driver Object
            Course NP=new Course();     // NoPreRequisite Course Object

            courses[0] = new Course("DIFFERENTIAL CALCULUS & CO-ORDINATE GEOMETRY","MAT1102", NP, NP, "30000"); // Course Object
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
            int Do = -1;
            while (Do != 0)
            {
                Console.WriteLine("What do you want to Do?\n(1) Show All Courses\n(2) Search a course\n(3) Calculate CGPA\n(4) Show available courses\n(0) Close");
                Do=int.Parse(Console.ReadLine());
                if(Do == 1)
                {
                    init.showCourses();
                }
                else if(Do == 2)
                {
                    Console.WriteLine("Please Enter The Course Code.(e.g: CSC1102)");
                    string code=Console.ReadLine();
                    init.searchCourse(code);
                }
                else if (Do == 3)
                {
                    init.cgpaCalculator();
                }
                else if (Do == 4)
                {
                    init.showAvaCourse();
                }
                else if( Do == 0)
                {
                    Console.WriteLine("Thanks...");
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid Option!!!");
                }
            }
        }
    }
}
