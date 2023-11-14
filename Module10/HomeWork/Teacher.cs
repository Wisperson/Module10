using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module10.HomeWork
{
    public class Teacher : Person
    {
        public List<Student> Students { get; set; }

        public Teacher()
        {
            Students = new List<Student>();
        }

        public override void Print()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
            Console.WriteLine("Students:");

            foreach (var student in Students)
            {
                Console.WriteLine($" - {student.Name}");
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Students: {Students.Count}";
        }

        public static Teacher RandomTeacher()
        {
            Teacher teacher = new Teacher();
            teacher.Name = "Prepod";
            teacher.Age = new Random().Next(30, 500);
            return teacher;
        }
    }
}
