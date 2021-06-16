using Praktikum.LinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.Hash
{
    class HashTabSepChain : HashBase
    {
        private SetUnsortedLinkedList[] tab = new SetUnsortedLinkedList[Length];

        public override bool Delete(int elem)
        {
            int index = elem % Length;

            return tab[index] != null ? tab[index].Delete(elem) : false;
        }

        public override bool Insert(int elem)
        {
            int index = elem % Length;

            if (tab[index] == null)
                tab[index] = new SetUnsortedLinkedList();

            return tab[index].Insert(elem);
        }

        public override bool Search(int elem)
        {
            int index = elem % Length;

            return tab[index]!=null ? tab[index].Search(elem) : false;
        }

        public override void Print()
        {
            int count = 0;
            foreach(SetUnsortedLinkedList item in tab)
            {
                Console.WriteLine($"---{count++}---");

                if (item != null)
                {
                    item.Print();
                } else
                {
                    Console.WriteLine("NULL");
                }

            }
        }
    }
}
