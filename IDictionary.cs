using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum
{
    interface IDictionary
    {
        public bool Search(int elem);

        public bool Insert(int elem);

        public bool Delete(int elem);

        public void Print();
    }
}
