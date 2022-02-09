using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using d01_ex00.Extensions;

namespace d01_ex00.Models
{
    internal class Store
    {
        public List<CashRegister> CashRegisters { get; private set; }
        public Storage Storage { get; private set; }

        public Store(int countCashRegister, int maxCountStorage)
        {
            CashRegisters = new List<CashRegister>();
            for (int i = 0; i < countCashRegister; i++)
                CashRegisters.Add(new CashRegister(i));
            Storage = new Storage(maxCountStorage);
        }

        public bool IsOpen => (!Storage.IsEmpty);

        public void Working(List<Customer> customers)
        {
            int i = 0;
            while (IsOpen)
            {
                customers[i].FillCart(Storage.CountProduct > 7 ? 7 : Storage.CountProduct);
                Storage.CountProduct -= customers[i].Cart;
                CashRegister cashRegister;
                Random random = new Random();
                bool choose = Convert.ToBoolean(random.Next(0, 2));
                if (choose == true)
                    cashRegister = customers[i].GetLeastNumberOfProduct(CashRegisters);
                else
                    cashRegister = customers[i].GetLeastPeopleCashRegister(CashRegisters);
                Console.WriteLine($"Клиент {customers[i].Name} выбрал {cashRegister.Tittle}");
                cashRegister.CustomersQueue.Enqueue(customers[i]);
                i++;
                if (i == customers.Count)
                    i = 0;
            }

        }
    }
}
