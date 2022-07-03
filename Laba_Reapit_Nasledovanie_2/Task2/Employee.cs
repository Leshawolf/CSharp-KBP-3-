using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    abstract class Employee : IComparable<Employee>
    {
        protected double monthSalary;
        static int countEmployee;
        public int id;
        public string Position { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public abstract double CountMonthSalary(ref double monthSalary);

        public Employee(string name, string position)
        {
            Name = name;
            Position = position;
            id = countEmployee + 1;
            countEmployee += 1;
        }

        static Employee()
        {
            countEmployee = 0;
        }  
        public override string ToString()
        {
            return $"Имя: {Name}, должность: {Position}, ID: {id}";
        }

            public int CompareTo(Employee other)
            {
                int res =Name.CompareTo(other.Name);
                return res;
            }
    }
}
