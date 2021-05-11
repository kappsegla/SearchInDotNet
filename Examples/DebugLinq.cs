using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Examples
{
    class DebugLinq
    {
        public static readonly List<Employee> employees = new List<Employee>
        {
            new("Peter Claus", 40, "Male", 61000),
            new("Jose Mond", 35, "male", 62000),
            new("Helen Gant", 38, "Female", 38000),
            new("Jo Parker", 42, "Male", 52000),
            new("Alex Mueller", 22, "Male", 39000),
            new("Abbi Black", 53, "female", 56000),
            new("Mike Mockson", 51, "Male", 82000)
        };

        //Average salary is about 56400
        //Use QuickWatch to evaluate parts of the query
        //.Where(e => e.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase))
        //ToString is used for printing Employee objekt information.
        //Put breakpoint on e.Gender=="Male"
        //https://marketplace.visualstudio.com/items?itemName=CodeValueLtd.OzCode

        public IEnumerable<Employee> MyQuery(List<Employee> employees)
        {
            var avgSalary = employees.Select(e => e.Salary).Average();
            return employees
                .Where(e => e.Gender == "Male")
                .Take(3)
                .Where(e => e.Salary > avgSalary)
                .OrderBy(e => e.Age);
        }

    }

    public class Employee
    {
        public Employee(string name, int age, string gender, int salary)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Salary = salary;
        }

        public string Name { get; }
        public int Age { get; }
        public string Gender { get; }
        public int Salary { get; }

        public override string ToString()
        {
            return string.Format("Name: {0}", Name);
        }
    }
}
