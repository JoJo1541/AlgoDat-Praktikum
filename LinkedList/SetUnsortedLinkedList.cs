using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.LinkedList
{
    class SetUnsortedLinkedList : LinkedListBase, ISetUnsorted
    {

        /// <summary>
        /// Check, ob schon Element vorhanden ist, sonst wie LinkedListBase.Insert
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public override bool Insert(int elem)
        {
            throw new NotImplementedException();
        }

    }
}
