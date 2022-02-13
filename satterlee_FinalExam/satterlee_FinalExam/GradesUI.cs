using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace satterlee_FinalExam
{
    class GradesUI
    {
        StudentS myStudentS;
        Info myInfo;

        //Instantiates a new StudentS object and calls Populate Student method to read
        //in info from the file.
        public void MainMethod()
        {
            myStudentS = new StudentS();
            myStudentS.PopulateStudents("grades.txt");

            if(myStudentS.PopulateStudents("grades.txt") == "File exists.")
            {
                DisplayInfo();
            }
            else
            {
                WriteLine("File does not exist.");
            }

        }

        //method to display info after data has been read in
        void DisplayInfo()
        {
            myInfo = new Info();

            myInfo.DisplayInfo();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Student id\tLast Name\tAverage  \tGrade");

            for (int index = 0; index < myStudentS.ListLength; index++)
            {

                Console.WriteLine(" {0} \t {1}    \t {2}    \t {3}", myStudentS.StudentID(index), myStudentS.StudentLastName(index), myStudentS.StudentAverage(index), myStudentS.StudentGrade(index));
            }
        }
    }
}