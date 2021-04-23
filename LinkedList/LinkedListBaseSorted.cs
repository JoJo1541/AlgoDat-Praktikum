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
        /// Insert Methode für die sortierte LinkedList
        /// </summary>
        /// <param name="elem">das einzufügende Element.</param>
        /// <returns>Gibt True zurück, wenn Einfügen erfolgreich. Sonst False</returns>
        public override bool Insert(int elem)
        {
            throw new NotImplementedException();
        }

    }
}
