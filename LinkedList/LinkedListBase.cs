using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.LinkedList
{
    /// <summary>
    /// Basisklasse für alle LinkedList Sets
    /// </summary>
    abstract class LinkedListBase : IDictionary
    {
        LinkedListElement first;
        LinkedListElement last;
        LinkedListElement lastSearchResult;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public LinkedListBase()
        {
            first = null;
            last = null;
        }


        /// <summary>
        /// Insert Methode für die unsortierte LinkedList
        /// </summary>
        /// <param name="elem">das einzufügende Element.</param>
        /// <returns>Gibt True zurück, wenn Einfügen erfolgreich. Sonst False</returns>
        public virtual bool Insert(int elem)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Sucht nach einem Element in der LinkedList und legt das Ergebnis im Feld lastSearchResult ab. (Wird kein Element gefunden, wird lastSearchResult auf null gesetzt)
        /// </summary>
        /// <param name="elem">Das zu suchende Element.</param>
        /// <returns>True, wenn ein Element elem gefunden wurde. Sonst False.</returns>
        public virtual bool Search(int elem)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Entfernt ein Element aus der unsortierten LinkedList.
        /// </summary>
        /// <param name="elem">Das zu entfernende Element.</param>
        /// <returns>True, wenn ein Element entfernt wurde. Sonst False.</returns>
        public virtual bool Delete(int elem)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Gibt die Datenstruktur in der Konsole aus.
        /// </summary>
        public void Print()
        {
            throw new NotImplementedException();
        }

    }
}
