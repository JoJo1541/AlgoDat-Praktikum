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
        internal LinkedListElement start;
        internal LinkedListElement end;
        internal LinkedListElement previous;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public LinkedListBase()
        {
            first = null;
            last = null;
        }

        /// <summary>
        /// Fügt das erste Element ein
        /// </summary>
        /// <param name="elem">Das einzufügende Element</param>
        protected void AddFirst(int elem)
        {
            start = new LinkedListElement(elem);
            end = start;
        }

        /// <summary>
        /// Fügt am Ende der Liste ein Element ein
        /// </summary>
        /// <param name="elem">Das einzufügende Element</param>
        protected virtual void AddLast(int elem)
        {
            end.next = new LinkedListElement(elem);
            end = end.next;
        }

        /// <summary>
        /// Insert Methode für die unsortierte LinkedList
        /// </summary>
        /// <param name="elem">das einzufügende Element.</param>
        /// <returns>Gibt True zurück, wenn Einfügen erfolgreich. Sonst False</returns>
        public virtual bool Insert(int elem)
        {
            if (start == null)
            {
                AddFirst(elem);
                return true;
            }
            else
            {
                AddLast(elem);
                return false;
            }
        }

         /// <summary>
        /// Sucht nach einem Element in der LinkedList (Wird kein Element gefunden, wird lastSearchResult auf null gesetzt).
        /// </summary>
        /// <param name="elem">Das zu suchende Element.</param>
        /// <returns>True, wenn ein Element elem gefunden wurde. Sonst False.</returns>
        public virtual bool Search(int elem)
        {
            if (start == null)
            {
                return false;
            }
            for (LinkedListElement i = start; i != null; previous = i, i = i.next)
            {
                if (i.key == elem)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Entfernt ein Element aus der unsortierten LinkedList.
        /// </summary>
        /// <param name="elem">Das zu entfernende Element.</param>
        /// <returns>True, wenn ein Element entfernt wurde. Sonst False.</returns>
        public virtual bool Delete(int elem)
        {
            if (Search(elem))
            {
                if (start.key == elem)
                {
                    start = start.next;
                }
                else
                {
                    previous.next = previous.next.next;
                    if (previous.next == null)
                    {
                        end = previous;
                    }
                }
                return true;
            }
            return false;

        }

        /// <summary>
        /// Gibt die Datenstruktur in der Konsole aus.
        /// </summary>
        public virtual void Print()
        {
            for (LinkedListElement elem = start; elem != null; elem = elem.next)
            {
                Console.WriteLine(elem);
            }
        }
    }
}
