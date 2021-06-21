using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.Array
{   
    /// <summary>
    /// Implementierung von SetSortedArray
    /// </summary>
    class SetSortedArray : ArrayBaseSorted, ISetSorted
    {

        /// <summary>
        /// Insert mit Prüfung, ob bereits vorhanden. Ansonsten wie ArrayBaseSorted.Insert()
        /// </summary>
        /// <param name="elem">Das einzufügende Element</param>
        /// <returns>True, wenn ein Element eingefügt wurde. Sonst False.</returns>
        public override bool Insert(int elem)
        {
            if (Search(elem))
            {
                return false;
            }
            else
            {
                return InsertItem(elem);
            }
            
        }
    }
}
