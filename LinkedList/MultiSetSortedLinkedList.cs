using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.LinkedList
{
    /// <summary>
    /// Implementierung von MultiSetSortedLinkedList
    /// </summary>
    class MultiSetSortedLinkedList : LinkedListBaseSorted, ISetSorted
    {
        /// <summary>
        /// Insert Methode für die sortierte MultiSetLinkedList
        /// </summary>
        /// <param name="elem">Das einzufügende Element.</param>
        /// <returns>Gibt True zurück, wenn Einfügen erfolgreich. Sonst False</returns>
        public override bool Insert(int elem)
        {
            LinkedListElement neu = new LinkedListElement(elem);
            if (start == null)
            {
                AddFirst(elem);
                return true;
            }
            else
            {
                if (elem <= start.key)
                {
                    Prepend(elem);
                    return true;
                }
                else
                {
                    for (LinkedListElement i = start; i.next != null; i = i.next)
                    {
                        if (i.key <= elem && i.next.key >= elem)
                        {
                            neu.next = i.next;
                            i.next = neu;
                            return true;
                        }
                    }
                    if (end.key <= elem)
                    {
                        AddLast(elem);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Sucht nach einem Element in der LinkedList (Wird kein Element gefunden, wird lastSearchResult auf null gesetzt).
        /// </summary>
        /// <param name="elem">Das zu suchende Element.</param>
        /// <returns>True, wenn ein Element elem gefunden wurde. Sonst False.</returns>
        public override bool Search(int elem)
        {
            if (start == null)
            {
                return false;
            }
            else
            {
                if (elem <= end.key)
                {
                    for (LinkedListElement i = start; i.key <= elem; previous = i, i = i.next)
                    {
                        if (i.key == elem)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}
