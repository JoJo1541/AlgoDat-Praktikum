using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.Array
{   
    /// <summary>
    /// Implementierung von SetUnosrtedArray
    /// </summary>
    class SetUnsortedArray : ArrayBase, ISetUnsorted
    {

        /// <summary>
        /// Insert mit Prüfung, ob bereits vorhanden. Ansonsten wie ArrayBase.Insert()
        /// </summary>
        /// <param name="elem">Das einzufügende Element</param>
        /// <returns>True, wenn ein Element eingefügt wurde. Sonst False.</returns>
        public override bool Insert(int elem)
        {
            if(!Search(elem))
            {
                if (nextFreeSpot != maxSize)
                {
                    data[nextFreeSpot] = elem;
                    nextFreeSpot++;
                    return true;
                }
            }
            return false;
        }    
    }
}
