using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.Array
{
    /// <summary>
    /// Basisklasse für sortierte Array Sets
    /// </summary>
    abstract class ArrayBaseSorted : ArrayBase
    {

        protected bool InsertItem(int elem)
        {
            if (nextFreeSpot == (maxSize - 1))
            {
                //Exceeded the allowed space 
                return false;
            }
            else if (nextFreeSpot == 0)
            {
                data[0] = elem;
                nextFreeSpot++;
                return true;
            }
            else if (nextFreeSpot == 1)
            {
                if (elem > data[0])
                {
                    data[1] = elem;
                    nextFreeSpot++;
                }
                else
                {
                    data[1] = data[0];
                    data[0] = elem;
                    nextFreeSpot++;
                }
                return true;
            }
            else
            {
                // Binäre Suche
                int i;
                int l = 0;
                int r = nextFreeSpot - 1;
                do
                {
                    i = (l + r) / 2;
                    if (data[i] < elem)
                    {
                        l = i + 1;
                    }
                    else
                    {
                        r = i - 1;
                    }
                }
                while ((data[i] != elem) && (l <= r));
                if (data[i] == elem)
                {
                    l = i;
                }
                for (int j = nextFreeSpot - 1; j >= l; j--)
                {
                    data[j + 1] = data[j];
                }
                data[l] = elem;
                nextFreeSpot++;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Insert Methode für das sortierte Array
        /// </summary>
        /// <param name="elem">das einzufügende Element.</param>
        /// <returns>Gibt True zurück, wenn Einfügen erfolgreich. Sonst False</returns>
        public override bool Insert(int elem)
        {
            return InsertItem(elem);
        }


        /// <summary>
        /// Sucht nach einem Element im Array und legt das Ergebnis im Feld lastSearchResult ab. (Wird kein Element gefunden, wird lastSearchResult auf null gesetzt)
        /// </summary>
        /// <param name="elem">Das zu suchende Element.</param>
        /// <returns>True, wenn ein Element elem gefunden wurde. Sonst False.</returns>
        public int SearchIndex(int elem)
        {
            int i;
            int l = 0;
            int r = nextFreeSpot - 1;
            do
            {
                i = (l + r) / 2;
                if (data[i] < elem)
                {
                    l = i + 1;
                }
                else
                {
                    r = i - 1;
                }
            }
            while ((data[i] != elem) && (l <= r));
            if (data[i] == elem)
            {
                return i;
            }
            else
            {
                return -1;
            }
        }

        public override bool Search(int elem)
        {
            // Binäre Suche
            int i;
            int l = 0;
            int r = nextFreeSpot - 1;
            do
            {
                i = (l + r) / 2;
                if (data[i] < elem)
                {
                    l = i + 1;
                }
                else
                {
                    r = i - 1;
                }
            }
            while ((data[i] != elem) && (l <= r));
            if (data[i] == elem)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Entfernt ein Element aus dem sortierten Array.
        /// </summary>
        /// <param name="elem">Das zu entfernende Element.</param>
        /// <returns>True, wenn ein Element entfernt wurde. Sonst False.</returns>
        public override bool Delete(int elem)
        {
            int index = SearchIndex(elem);
            if (index != -1)
            {
                for (int i = index; i < nextFreeSpot-1 ; i++)
                {
                    data[i] = data[i +1];
                }
                nextFreeSpot--;
                return true;
            }
            return false;
        }
    }
}
