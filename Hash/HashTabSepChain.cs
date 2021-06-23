using Praktikum.LinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.Hash
{
    class HashTabSepChain : HashBase
    {
        private readonly SetUnsortedLinkedList[] tab = new SetUnsortedLinkedList[Length];

        public override bool Delete(int elem)
        {
            int index = HashFunc(elem);

            return tab[index] != null ? tab[index].Delete(elem) : false;
        }

        public override bool Insert(int elem)
        {
            int index = HashFunc(elem);

            if (tab[index] == null)
                tab[index] = new SetUnsortedLinkedList();

            return tab[index].Insert(elem);
        }

        public override bool Search(int elem)
        {
            int index = HashFunc(elem);

            return tab[index] != null ? tab[index].Search(elem) : false;
        }

        public override void Print()
        {
            int count = 0;
            foreach (SetUnsortedLinkedList item in tab)
            {
                if (item != null)
                {
                    Console.WriteLine($"---{count}---");
                    tab[count].Print();
                    Console.WriteLine();
                }

                count++;
            }
        }
    }
}