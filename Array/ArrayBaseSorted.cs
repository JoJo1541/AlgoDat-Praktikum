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


        /// <summary>
        /// Insert Methode für das sortierte Array
        /// </summary>
        /// <param name="elem">das einzufügende Element.</param>
        /// <returns>Gibt True zurück, wenn Einfügen erfolgreich. Sonst False</returns>
        public override bool Insert(int elem)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Sucht nach einem Element im Array und legt das Ergebnis im Feld lastSearchResult ab. (Wird kein Element gefunden, wird lastSearchResult auf null gesetzt)
        /// </summary>
        /// <param name="elem">Das zu suchende Element.</param>
        /// <returns>True, wenn ein Element elem gefunden wurde. Sonst False.</returns>
        public override bool Search(int elem)
        {
            // Binäre Suche
            throw new NotImplementedException();
        }


        /// <summary>
        /// Entfernt ein Element aus dem sortierten Array.
        /// </summary>
        /// <param name="elem">Das zu entfernende Element.</param>
        /// <returns>True, wenn ein Element entfernt wurde. Sonst False.</returns>
        public override bool Delete(int elem)
        {
            throw new NotImplementedException();
        }

    }
}
