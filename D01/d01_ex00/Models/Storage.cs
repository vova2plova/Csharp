using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d01_ex00.Models
{
    public class Storage
    {
        public int CountProduct { get; set; }

        public Storage(int countProduct)
        {
            CountProduct = countProduct;
        }

        public bool IsEmpty => CountProduct == 0;
    }
}
