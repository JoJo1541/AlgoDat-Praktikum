using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.LinkedList
{
    class SetUnsortedLinkedList : LinkedListBase, ISetUnsorted
    {
        /// <summary>
        /// Fügt am Ende der Liste ein Element ein
        /// </summary>
        /// <param name="elem">Das einzufügende Element</param>
        protected override void AddLast(int elem)
        {
            if (Search(elem) == false)
            {
                end.next = new LinkedListElement(elem);
                end = end.next;
            }
        }
    }
}
