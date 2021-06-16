using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.LinkedList
{
    /// <summary>
    /// Basisklasse für sorted LinkedList Sets
    /// </summary>
    abstract class LinkedListBaseSorted : LinkedListBase
    {
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

        /// <summary>
        /// Fügt ein Element am Anfgand ein
        /// </summary>
        /// <param name="elem">Das einzufügende Element.</param>
        protected virtual void Prepend(int elem)
        {
            LinkedListElement neu = new LinkedListElement(elem);
            neu.next = start;
            start = neu;
        }

    }
}
