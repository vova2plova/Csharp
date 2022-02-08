using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d01_ex00
{
    internal class CashRegister
    {
        private string _tittle;
        public Queue<Customer> CustomersQueue { get; private set; };

        public CashRegister(string tittle)
        {
            CustomersQueue = new Queue<Customer>();
            _tittle = tittle;
        }

        public static bool operator ==(CashRegister c1, CashRegister c2)
        {
            return (c1._tittle == c2._tittle);
        }

        public static bool operator !=(CashRegister c1, CashRegister c2)
        {
            return !(c1 == c2);
        }
    }
}
