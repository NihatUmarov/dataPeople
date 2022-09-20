using System;
using System.Collections.Generic;
using System.Text;

namespace dataPeople
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, введите название вашей школы");
            string nameSchool = Console.ReadLine();
            School school = new School(nameSchool);
            Console.WriteLine($"Школа {school.Name} успешно создана.\nДля перехода в меню нажмите Enter");
            Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Menu(school);
                ChooseAction(school);
            }
        }

        static void Menu(School school)
        {
            Console.WriteLine($"Нажмите соответствующую клавишу для выбора действия:\n" +
                $"А - добавить нового ученика в школу {school.Name}\n" +
                $"Р - посмотреть список учеников школы {school.Name}\n" +
                $"E - исключить ученика из школы {school.Name}\n" +
                $"Q - выйти из программы");
        }

        static void ChooseAction(School school)
        {
            string inputString = Console.ReadLine();
            inputString = inputString.ToUpper();

            if (inputString == "A" || inputString == "А" || inputString == "Ф" || inputString == "F")
            {
                AppendNewStudent(school);
                return;
            }
            if (inputString == "P" || inputString == "Р" || inputString == "З" || inputString == "H")
            {
                PrintStudents(school);
                return;
            }
            if (inputString == "E" || inputString == "Е" || inputString == "У" || inputString == "T")
            {
                RemoveAStudent(school);
                return;
            }
            if (inputString == "Q" || inputString == "Й")
            {
                Exit();
            }
            Console.Clear();
            Console.WriteLine("При вводе произошла ошибка. Нажмите любую клавишу, чтобы возвратиться в меню");
            Console.ReadLine();
        }

        static void AppendNewStudent(School school)
        {
            Console.Clear();
            Console.WriteLine($"Введите имя ученика");
            string firstName = Console.ReadLine();
            Console.WriteLine($"Введите фамилию ученика");
            string lastName = Console.ReadLine();
            string age;
            do
            {
                Console.WriteLine($"Укажите возраст ученика, полных лет");
                age = Console.ReadLine();
                if (!IsStringANumber(age))
                {
                    Console.WriteLine("Вы ошиблись при указании возраста ученика");
                }
            }
            while (!IsStringANumber(age));
            Student student = new Student(firstName, lastName, Convert.ToInt32(age)); ;
            school.AddNewStudent(student);
            Console.ReadLine();
        }

        static void PrintStudents(School school)
        {
            Console.Clear();
            school.PrintStudents();
            Console.ReadLine();
        }

        static void RemoveAStudent(School school)
        {
            Console.Clear();
            if (school.GetNumberOfStudents() == 0)
            {
                school.PrintStudents();
                Console.ReadLine();
                return;
            }
            Console.WriteLine($"Введите порядковый номер ученика, который будет исключен из школы");
            string numberTemp = Console.ReadLine();

            if (IsRightNumber(school, numberTemp))
            {
                int numberOfStudent = Convert.ToInt32(numberTemp);
                Console.Clear();
                school.RemoveStudent(numberOfStudent);
                Console.WriteLine("Обновленный список учеников");
                school.PrintStudents();
            }
            Console.ReadLine();
        }

        static bool IsRightNumber(School school, string numberTemp)
        {
            if (!IsStringANumber(numberTemp) || Convert.ToInt32(numberTemp) > school.GetNumberOfStudents() || Convert.ToInt32(numberTemp) == 0)
            {
                Console.WriteLine("Вы ошиблись при вводе номера ученика. Для возврата в меню нажмите Enter");
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool IsStringANumber(string inputString)
        {
            for (int i = 0; i < inputString.Length; i++)
            {
                if (!char.IsDigit(inputString[i]))
                {
                    return false;
                }
            }
            return true;
        }

        static void Exit()
        {
            Environment.Exit(0);
        }
    }
}