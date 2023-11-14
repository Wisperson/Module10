using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.HomeWork
{
    public class Student : Person
    {
        public int Course { get; set; }

        public override void Print()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Course: {Course}");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Course: {Course}";
        }

        public static Student RandomStudent()
        {
            Student student = new Student();
            student.Name = "Ivan";
            student.Age = new Random().Next(20, 60);
            return student;
        }
    }
}
