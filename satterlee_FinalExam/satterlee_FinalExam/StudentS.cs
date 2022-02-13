using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace satterlee_FinalExam
{
    class StudentS
    {


        List<Student> theStudentList;       //new student list object


        //Populate Student method will take in a path to a new file and read in file info.
        //That info will then be used to populate each individual student object and data
        //will be manipulated to be displayed
        public string PopulateStudents(string path)
        {
            theStudentList = new List<Student>(); 

            if(File.Exists(path))
            {
                try
                {
                    using (StreamReader reader = File.OpenText(path))
                    {
                        string inValue;

                        while((inValue = reader.ReadLine()) != null)
                        {                     
                            string[] sn = inValue.Split(',');
                            Student aStudent = new Student(sn[0], sn[1], sn[2]);

                            for (int i = 3, j = 4; j < sn.Length; i += 2, j += 2)
                            {
                                int avg = int.Parse(sn[i]);
                                int total = int.Parse(sn[j]);

                                aStudent.EnterGrade(avg, total);
                            }

                            aStudent.CalGrade();
                            theStudentList.Add(aStudent);
                        }
                        
                    }
                }
                catch (IOException e)
                {
                    Error.WriteLine(e.Message);
                }
                string hooray = "File exists.";
                return hooray;

            }
            else
            {
                string error =  "Error.  File does not exist.";
                return error;
            }
        }

        public int ListLength
        {
            get { return theStudentList.Count; }
        }

        public string StudentID(int index)
        {
            return theStudentList.ElementAt(index).ID;
        }

        public string StudentLastName(int index)
        {
            return theStudentList.ElementAt(index).NameLast;
        }

        public string StudentGrade(int index)
        {

            return theStudentList.ElementAt(index).LetterGrade;
        }

        public float StudentAverage(int index)
        {

            return theStudentList.ElementAt(index).Average;
        }

    }

}    