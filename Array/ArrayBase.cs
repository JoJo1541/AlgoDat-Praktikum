using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.Array
{   
    /// <summary>
    /// Basisklasse für alle Array Sets
    /// </summary>
    abstract class ArrayBase : IDictionary
    {
        private static readonly int maxSize = 30;
        protected int[] data;
        protected int lastSearchResult;
        protected int nextPos=0;

        /// <summary>
        /// Konstructor
        /// </summary>
        public ArrayBase()
        {
            this.data = new int[maxSize];
        }


        /// <summary>
        /// Insert Methode für das unsortierte Array
        /// </summary>
        /// <param name="elem">das einzufügende Element.</param>
        /// <returns>Gibt True zurück, wenn Einfügen erfolgreich. Sonst False</returns>
        public virtual bool Insert(int elem)
        {
            if(nextPos < maxSize)
            {
                data[i] = elem;
                nextPos++;
                return true;
            }

            return false;
        }


        /// <summary>
        /// Sucht nach einem Element im unsortierten Array und legt das Ergebnis im Feld lastSearchResult ab. (Wird kein Element gefunden, wird lastSearchResult auf null gesetzt)
        /// </summary>
        /// <param name="elem">Das zu suchende Element.</param>
        /// <returns>True, wenn ein Element elem gefunden wurde. Sonst False.</returns>
        public virtual bool Search(int elem)
        {
            // Sequentielle Suche
            for(int i = 0; i < maxSize; i++)
            {
                if(elem == data[i])
                {
                    lastSearchResult = i;
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Entfernt ein Element aus dem unsortierten Array.
        /// </summary>
        /// <param name="elem">Das zu entfernende Element.</param>
        /// <returns>True, wenn ein Element entfernt wurde. Sonst False.</returns>
        public virtual bool Delete(int elem)
        {
            if (Search(elem))
            {
                data[lastSearchResult] = 0;
                return true;
            }

            return false;
        }
    

        /// <summary>
        /// Gibt die Datenstruktur in der Konsole aus.
        /// </summary>
        public void Print()
        {
            for(int i = 0; i < nextPos; i++)
            {
                Console.WriteLine($"{i}:\t{data[i]}");
            }
        }

    }
}
