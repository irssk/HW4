using System;

namespace OperatorsApp
{
    public class City
    {
        private string name;
        private int population;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Population
        {
            get => population;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Кількість жителів не може бути від’ємною!");
                population = value;
            }
        }

        public City(string name, int population)
        {
            Name = name;
            Population = population;
        }

        public static City operator +(City city, int count)
        {
            city.Population += count;
            return city;
        }

        public static City operator -(City city, int count)
        {
            city.Population -= count;
            return city;
        }

        public static bool operator ==(City c1, City c2) => c1.Population == c2.Population;
        public static bool operator !=(City c1, City c2) => c1.Population != c2.Population;
        public static bool operator <(City c1, City c2) => c1.Population < c2.Population;
        public static bool operator >(City c1, City c2) => c1.Population > c2.Population;

        public override bool Equals(object obj) => obj is City c && Population == c.Population;
        public override int GetHashCode() => Population.GetHashCode();

        public void ShowInfo() =>
            Console.WriteLine($"Місто: {Name}, Населення: {Population}");
    }
}
