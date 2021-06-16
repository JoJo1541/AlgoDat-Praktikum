using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.Hash
{
    abstract class HashBase : ISetSorted
    {
        protected const int Length = 103;

        public abstract bool Insert(int elem);

        public abstract bool Search(int elem);

        public abstract bool Delete(int elem);


        public abstract void Print();
    }
}
