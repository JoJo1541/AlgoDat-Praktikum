using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.LinkedList
{
    /// <summary>
    /// Implementierung von SetSortedLinkedList
    /// </summary>
    class SetSortedLinkedList : LinkedListBaseSorted, ISetSorted
    {

        /// <summary>
        /// Check, ob schon Element vorhanden ist. Sonst wie LinkedListBase.Insert
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public override bool Insert(int elem)
        {
            throw new NotImplementedException();
        }

    }
}
