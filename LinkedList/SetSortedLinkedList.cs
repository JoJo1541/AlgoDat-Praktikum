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
        /// Check, ob schon Element vorhanden ist und fügt ihn hinzu, falls er nicht vorhanden ist.
        /// </summary>
        /// <param name="elem">das einzufügende Element</param>
        /// <returns>Gibt True zurück, wenn Einfügen erfolgreich. Sonst False</returns>
        public override bool Insert(int elem)
        {
            LinkedListElement neu = new LinkedListElement(elem);
            if (Search(elem) == false)
            {
                if (start == null)
                {
                    AddFirst(elem);
                    return true;
                }
                else
                {
                    if (elem < start.key)
                    {
                        Prepend(elem);
                        return true;
                    }
                    else
                    {
                        for (LinkedListElement i = start; i.next != null; i = i.next)
                        {
                            if (i.key < elem && i.next.key > elem)
                            {
                                neu.next = i.next;
                                i.next = neu;
                                return true;
                            }
                        }
                        if (end.key < elem)
                        {
                            AddLast(elem);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
