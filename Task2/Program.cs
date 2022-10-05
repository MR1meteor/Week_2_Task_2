using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        
        static string[] MaleNames = { "Иван",  "Андрей", "Юрий", "Константин", "Алексанр", "Михаил", "Олег", "Павел" };
        static string[] FemaleNames = { "Татьяна", "Елизавета", "Алина", "Ксения", "Дарья" };      
        static string[] Surnames = { "Воробьёв", "Виноградов", "Белов", "Баранов", "Лазарев", "Цветков", "Ильин", "Гусев", "Фёдоров", "Михайлов", "Новиков", "Козлов", "Степанов", "Жуков" };
        static string[,] MiddleNames = { { "Евгеньевич", "Евгеньевна" }, { "Олегович", "Олеговна" }, { "Сергеевич", "Сергеевна" }, { "Кириллович", "Кирилловна" }, { "Борисович", "Борисовна" }, { "Егорович", "Егоровна" }, { "Андреевич", "Андреевна" }, { "Витальевич", "Витальевна" }, { "Константинович", "Константиновна" }, { "Иванович", "Ивановна" } };
        static List<Department> Departments = new()
        { 
            new Department { Number = 1, Title = "Отдел кадров", Leader = "Александр Виноградов" },
            new Department { Number = 2, Title = "Отдел продаж", Leader = "Михаил Белов" },
            new Department { Number = 3, Title = "Отдел маркетинга", Leader = "Константин Баранов" },
            new Department { Number = 4, Title = "Отдел финансов", Leader = "Павел Лазарев" },
            new Department { Number = 5, Title = "Отдел контроля качества", Leader = "Олег Цветков" }
        };

        static void Main(string[] args)
        {
            List<Employee> employees = CreateEmployeeList(50);

            Dictionary<string, List<Employee>> dict = new Dictionary<string, List<Employee>>();
            for (int i = 0; i < Departments.Count(); i++)
            {
                List<Employee> selectedEmployees = (from e in employees
                                                   where e.Department.Number.Equals(Departments[i].Number)
                                                   select e).ToList();

                dict.Add(Departments[i].Title, selectedEmployees);
            }

            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " : ");
                foreach (var emp in item.Value)
                {
                    Console.WriteLine(emp.Surname + " " + emp.Name + " " + emp.MiddleName + " " + emp.Age + " " + emp.Department.Title);
                }
                Console.WriteLine();
            }
        }

        static List<Employee> CreateEmployeeList(int numberOfElements)
        {
            List<Employee> employees = new();

            for (int i = 0; i < numberOfElements; i++)
            {
                employees.Add(CreateEmployee());
            }

            return employees;
        }

        static Employee CreateEmployee()
        {
            Random random = new();
            int gender = random.Next(2);

            Employee employee = new()
            {
                Name = gender == 0 ? MaleNames[random.Next(MaleNames.Length)] : FemaleNames[random.Next(FemaleNames.Length)],
                Surname = gender == 0 ? Surnames[random.Next(Surnames.Length)] : Surnames[random.Next(Surnames.Length)] + "а",
                MiddleName = gender == 0 ? MiddleNames[random.Next(MiddleNames.Length / 2), 0] : MiddleNames[random.Next(MiddleNames.Length / 2), 1],
                Age = random.Next(100),
                Department = Departments[random.Next(Departments.Count())]
            };

            return employee;
        }
    }
}