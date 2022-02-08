using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d01_ex00
{
    internal class Storage
    {
        private int _countProduct;

        public Storage(int countProduct)
        {
            _countProduct = countProduct;
        }

        public bool IsEmpty() => _countProduct == 0;
    }
}
