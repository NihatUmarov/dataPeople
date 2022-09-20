namespace dataPeople
{
    public class School
    {
        public string Name;
        public List<Student> Students;

        public School(string name)
        {
            Name = name;
            Students = new List<Student>();
        }

        public void PrintStudents()
        {
            if (Students.Count == 0)
            {
                Console.Clear();
                Console.WriteLine($"В школе {Name} нет учеников.");
                Console.WriteLine("Для возврата в меню нажмите Enter");
            }
            else
            {
                Console.WriteLine("{0, -5} {1, -15} {2, -15} {3, -10}", "№", "ИМЯ", "ФАМИЛИЯ", "ВОЗРАСТ, ЛЕТ");
                for (int i = 0; i < Students.Count; i++)
                {

                    Console.WriteLine("{0, -5} {1, -15} {2, -15} {3, -10}", i + 1, Students[i].FirstName, Students[i].LastName, Students[i].Age);
                }
                Console.WriteLine("Для возврата в меню нажмите Enter");
            }
        }

        public void AddNewStudent(Student student)
        {
            Students.Add(student);
            Console.Clear();
            Console.WriteLine($"Ученик {student.FirstName} успешно добавлен в школу.");
            PrintStudents();
        }

        public void RemoveStudent(int numberOfStudent)
        {
            string nameOfRemovedStudent = Students[numberOfStudent - 1].FirstName;
            Students.RemoveAt(numberOfStudent - 1);
            Console.WriteLine($"Ученик {nameOfRemovedStudent} исключен из школы.");
        }

        public int GetNumberOfStudents()
        {
            return Students.Count;
        }
    }
}