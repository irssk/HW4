using System;

namespace OperatorsApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Завдання 1: Співробітник ===");
            Employee e1 = new Employee("Іван", 12000);
            Employee e2 = new Employee("Олена", 15000);
            e1 += 2000;
            e2 -= 3000;
            e1.ShowInfo();
            e2.ShowInfo();
            Console.WriteLine(e1 > e2 ? "Іван має більшу зарплату" : "Олена має більшу або рівну зарплату");

            Console.WriteLine("\n=== Завдання 2: Місто ===");
            City c1 = new City("Київ", 2800000);
            City c2 = new City("Львів", 700000);
            c1 += 20000;
            c2 -= 10000;
            c1.ShowInfo();
            c2.ShowInfo();
            Console.WriteLine(c1 > c2 ? $"{c1.Name} має більше населення" : $"{c2.Name} має більше населення");

            Console.WriteLine("\n=== Завдання 3: Кредитна картка ===");
            CreditCard card1 = new CreditCard("1234 5678 9999 0000", 123, 5000);
            CreditCard card2 = new CreditCard("2222 3333 4444 5555", 123, 8000);
            card1 += 1500;
            card2 -= 2000;
            card1.ShowInfo();
            card2.ShowInfo();
            Console.WriteLine(card1 == card2 ? "Однаковий CVC" : "Різний CVC");

            Console.WriteLine("\n=== Завдання 4: Матриця ===");
            Matrix m1 = new Matrix(2, 2);
            Matrix m2 = new Matrix(2, 2);

            m1[0, 0] = 1; m1[0, 1] = 2;
            m1[1, 0] = 3; m1[1, 1] = 4;

            m2[0, 0] = 5; m2[0, 1] = 6;
            m2[1, 0] = 7; m2[1, 1] = 8;

            Console.WriteLine("Матриця 1:");
            m1.Print();
            Console.WriteLine("Матриця 2:");
            m2.Print();

            Console.WriteLine("Сума:");
            (m1 + m2).Print();

            Console.WriteLine("Різниця:");
            (m1 - m2).Print();

            Console.WriteLine("Добуток:");
            (m1 * m2).Print();

            Console.WriteLine("Множення на число (×2):");
            (m1 * 2).Print();
        }
    }
}
