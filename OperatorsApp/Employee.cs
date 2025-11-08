using System;

namespace OperatorsApp
{
    public class Employee
    {
        private string name;
        private double salary;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public double Salary
        {
            get => salary;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Зарплата не може бути від’ємною!");
                salary = value;
            }
        }

        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        public static Employee operator +(Employee emp, double amount)
        {
            emp.Salary += amount;
            return emp;
        }

        public static Employee operator -(Employee emp, double amount)
        {
            emp.Salary -= amount;
            return emp;
        }

        public static bool operator ==(Employee e1, Employee e2) => e1.Salary == e2.Salary;
        public static bool operator !=(Employee e1, Employee e2) => e1.Salary != e2.Salary;
        public static bool operator <(Employee e1, Employee e2) => e1.Salary < e2.Salary;
        public static bool operator >(Employee e1, Employee e2) => e1.Salary > e2.Salary;

        public override bool Equals(object obj) => obj is Employee e && Salary == e.Salary;
        public override int GetHashCode() => Salary.GetHashCode();

        public void ShowInfo() =>
            Console.WriteLine($"Співробітник: {Name}, Зарплата: {Salary} грн");
    }
}
