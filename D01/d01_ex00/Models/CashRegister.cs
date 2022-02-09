using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d01_ex00.Models
{
    public class CashRegister
    {
        public string Tittle { get; private set ;}
        public Queue<Customer> CustomersQueue { get; private set; }

        public CashRegister(int tittle)
        {
            CustomersQueue = new Queue<Customer>();
            Tittle = $"Касса номер = {tittle}";
        }

        public static bool operator ==(CashRegister c1, CashRegister c2)
        {
            return (c1.Tittle == c2.Tittle);
        }

        public static bool operator !=(CashRegister c1, CashRegister c2)
        {
            return !(c1 == c2);
        }

    }
}
