using System;

namespace OperatorsApp
{
    public class CreditCard
    {
        private string cardNumber;
        private int cvc;
        private double balance;

        public string CardNumber
        {
            get => cardNumber;
            set => cardNumber = value;
        }

        public int CVC
        {
            get => cvc;
            set
            {
                if (value < 100 || value > 999)
                    throw new ArgumentException("CVC повинен складатись з трьох цифр!");
                cvc = value;
            }
        }

        public double Balance
        {
            get => balance;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Баланс не може бути від’ємним!");
                balance = value;
            }
        }

        public CreditCard(string cardNumber, int cvc, double balance)
        {
            CardNumber = cardNumber;
            CVC = cvc;
            Balance = balance;
        }

        public static CreditCard operator +(CreditCard card, double amount)
        {
            card.Balance += amount;
            return card;
        }

        public static CreditCard operator -(CreditCard card, double amount)
        {
            card.Balance -= amount;
            return card;
        }

        public static bool operator ==(CreditCard c1, CreditCard c2) => c1.CVC == c2.CVC;
        public static bool operator !=(CreditCard c1, CreditCard c2) => c1.CVC != c2.CVC;
        public static bool operator <(CreditCard c1, CreditCard c2) => c1.Balance < c2.Balance;
        public static bool operator >(CreditCard c1, CreditCard c2) => c1.Balance > c2.Balance;

        public override bool Equals(object obj) => obj is CreditCard c && CVC == c.CVC;
        public override int GetHashCode() => CVC.GetHashCode();

        public void ShowInfo() =>
            Console.WriteLine($"Картка: {CardNumber}, Баланс: {Balance} грн, CVC: {CVC}");
    }
}
