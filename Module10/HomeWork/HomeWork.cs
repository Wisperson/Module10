using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.HomeWork
{
    public static class HomeWorkRun
    {
        public static void Run()
        {
            Person[] people = new Person[5];

            // Заполняем массив случайными персонами (студентами и преподавателями)
            for (int i = 0; i < 2; i++)
            {
                people[i] = Student.RandomStudent();
            }

            for (int i = 2; i < 5; i++)
            {
                people[i] = Teacher.RandomTeacher();
            }

            // Определение количества персон, студентов и преподавателей
            int personCount = 0, studentCount = 0, teacherCount = 0;

            foreach (var person in people)
            {
                if (person is Student)
                {
                    studentCount++;
                    // Переводим студентов на следующий курс (пример)
                    ((Student)person).Course++;
                }
                else if (person is Teacher)
                {
                    teacherCount++;
                }

                personCount++;
            }

            Console.WriteLine($"Total Persons: {personCount}");
            Console.WriteLine($"Students: {studentCount}");
            Console.WriteLine($"Teachers: {teacherCount}");

            // Выводим информацию о каждой персоне
            foreach (var person in people)
            {
                person.Print();
                Console.WriteLine();
            }

            Console.ReadKey();
        }

    }
}
