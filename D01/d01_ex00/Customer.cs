using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace d01_ex00
{
    class Customer
    {
        public string Name { get;private set; }
        public int Id { get;private set; }
        public int Cart { get;private set; }

        public Customer(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public void FillCart(int maxCount)
        {
            if (maxCount < 1)
                return;
            Random random = new Random();
            Cart = random.Next(1, maxCount + 1);
        }

        public override string ToString()
        {
            return ($"Name - {Name}, Id - {Id}");
        }

        public override bool Equals(object? obj) => (obj is Customer other) && (this == other);

        public override int GetHashCode() => Name.GetHashCode() + Id.GetHashCode();

        public static bool operator ==(Customer c1, Customer c2)
        {
            return (c1.Name == c2.Name) && (c1.Id == c2.Id);
        }

        public static bool operator !=(Customer c1, Customer c2)
        {
            return !(c1 == c2);
        }
    }
}
