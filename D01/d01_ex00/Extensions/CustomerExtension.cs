using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using d01_ex00.Models;

namespace d01_ex00.Extensions
{
    public static class CustomerExtension
    {
        public static CashRegister? GetLeastPeopleCashRegister(this Customer _, List<CashRegister> cashRegisters)
        {
            return cashRegisters
                .OrderBy(c => c.CustomersQueue.Count)
                .FirstOrDefault();
        }
           

        public static CashRegister? GetLeastNumberOfProduct(this Customer _, List<CashRegister> cashRegisters)
        {
            return cashRegisters
                .OrderBy(c => c.CustomersQueue
                .Sum(c => c.Cart))
                .FirstOrDefault();
        }

    }
}
