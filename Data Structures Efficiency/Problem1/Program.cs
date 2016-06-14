using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;


namespace Problem1
{
    class Student : IComparable<Student>
    {
        public string Firstname { get; set; }
        private string LastName { get; set; }


        public Student(string fname, string lname)
        {
            this.Firstname = fname;
            this.LastName = lname;

        }

        public int CompareTo(Student other)
        {
            return string.Compare(this.Firstname, other.LastName) * 2 + string.Compare(this.LastName, other.LastName);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Firstname, this.LastName);
        }
    }




    class Courses
    {

        public static OrderedMultiDictionary<string, Student> courses = new OrderedMultiDictionary<string, Student>(true);

        public void AddElement(string firstName, string lastName, string course)
        {
            var student = new Student(firstName, lastName);
            courses[course].Add(student);

        }

        public string findElement(string course)
        {
            var result = courses[course];

            return string.Join(", ", result);
        }

        public void printInfo()
        {
            Console.WriteLine(string.Join(Environment.NewLine,
            courses.Keys.Select(course =>
                string.Format("{0}: {1}", course, findElement(course))
            )
            ));





        }

        static void Main(string[] args)
        {
            Courses course = new Courses();

            course.AddElement("Kiril", "Ivanov", "C#");
            course.AddElement("Stefka", "Nikolova", "SQL");
            course.AddElement("Stela", "Mineva", "Java");
            course.AddElement("Milena ", "Petrova", "C#");
            course.AddElement("Ivan", "Grigorov", "C#");
            course.AddElement("Ivan", "Kolev", "SQL");

            course.printInfo();


            //#if DEBUG
            //            Console.SetIn(new System.IO.StreamReader("input.txt"));
            //#endif

            //            for (string line = null; (line = Console.ReadLine()) != null;)
            //            {
            //                var match = line.Split('|').Select(m => m.Trim()).ToArray();

            //                AddElement(firstName: match[0], lastName: match[1], course: match[2]);
            //            }

            //            Console.WriteLine(string.Join(Environment.NewLine,
            //                courses.Keys.Select(course =>
            //                    string.Format("{0}: {1}", course, findElement(course))
            //                )
            //            ));
            //        }


        }
    }
}


