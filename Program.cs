using Praktikum.Array;
using Praktikum.BinTree;
using Praktikum.Hash;
using Praktikum.LinkedList;
using System;

namespace Praktikum
{
    class Program
    {
        private static IDictionary dic = null;

        static void Main(string[] args)
        {
            ProcessClassChoice();

            if (dic != null)
            {
                ProcessDictionaryFunctions();
            }

        }


        /// <summary>
        /// Verarbeitet die Klassenauswahl für das Dictionary
        /// </summary>
        private static void ProcessClassChoice()
        {
            Boolean cont = true;

            while (cont)
            {
                Console.Clear();
                Console.WriteLine("Bitte wählen Sie einen Datentyp");
                Console.WriteLine("1) ISetSorted");
                Console.WriteLine("2) ISetUnsorted");
                Console.WriteLine("3) IMultiSetSorted");
                Console.WriteLine("4) IMultiSetUnsorted");
                Console.WriteLine("");
                Console.WriteLine("5) Beenden");

                int i = GetKeyValInRange(1, 5);

                if (i == 5)
                {
                    cont = false;
                }
                else
                if (i > -1)
                {
                    ProcessClassFineChoice(i);
                }

                if (dic != null)
                {
                    break;
                }

            }
        }

        /// <summary>
        /// Helfermethode zum Aufspalten der Klassenauswahl
        /// </summary>
        /// <param name="key"></param>
        private static void ProcessClassFineChoice(int key)
        {
            bool cont = true;
            int i;

            while (cont)
            {
                Console.Clear();
                Console.WriteLine("Bitte wählen Sie einen Datentyp");
                switch (key)
                {
                    // ISetSorted
                    case 1:
                        Console.WriteLine("1) SetSortedArray");
                        Console.WriteLine("2) SetSortedLinkedList");
                        Console.WriteLine("3) BinSearchTree");
                        Console.WriteLine("4) AVLTree");
                        Console.WriteLine("5) Treap");
                        Console.WriteLine("");
                        Console.WriteLine("6) Zurück");

                        i = GetKeyValInRange(1, 6);

                        if (i >= 0)
                        {
                            cont = false;

                            if (i == 6)
                            {
                                break;
                            }
                        }
                        else
                        {
                            continue;
                        }

                        switch (i)
                        {
                            case (1):
                                dic = new SetSortedArray();
                                break;

                            case (2):
                                dic = new SetSortedLinkedList();
                                break;

                            case (3):
                                dic = new BinSearchTree();
                                break;

                            case (4):
                                dic = new AVLTree();
                                break;

                            case (5):
                                dic = new Treap();
                                break;
                        }

                        break;

                    // ISetUnsorted
                    case 2:
                        Console.WriteLine("1) SetUnsortedArray");
                        Console.WriteLine("2) SetUnsortedLinkedList");
                        Console.WriteLine("3) HashTabSepChain");
                        Console.WriteLine("4) HashTabQuadPro");
                        Console.WriteLine("");
                        Console.WriteLine("5) Zurück");

                        i = GetKeyValInRange(1, 5);

                        if (i >= 0)
                        {
                            cont = false;

                            if (i == 5)
                            {
                                break;
                            }
                        }
                        else
                        {
                            continue;
                        }

                        switch (i)
                        {
                            case (1):
                                dic = new SetUnsortedArray();
                                break;

                            case (2):
                                dic = new SetUnsortedLinkedList();
                                break;

                            case (3):
                                dic = new HashTabSepChain();
                                break;

                            case (4):
                                dic = new HashTabQuadPro();
                                break;
                        }

                        break;

                    // IMultiSetSorted
                    case 3:
                        Console.WriteLine("1) MultiSetSortedArray");
                        Console.WriteLine("2) MultiSetSortedLinkedList");
                        Console.WriteLine("");
                        Console.WriteLine("3) Zurück");

                        i = GetKeyValInRange(1, 3);

                        if (i >= 0)
                        {
                            cont = false;

                            if (i == 3)
                            {
                                break;
                            }
                        }
                        else
                        {
                            continue;
                        }

                        switch (i)
                        {
                            case (1):
                                dic = new MultiSetSortedArray();
                                break;

                            case (2):
                                dic = new MultiSetSortedLinkedList();
                                break;
                        }

                        break;

                    // IMultiSetUnsorted
                    case 4:
                        Console.WriteLine("1) MultiSetUnsortedArray");
                        Console.WriteLine("2) MultiSetUnsortedLinkedList");
                        Console.WriteLine("");
                        Console.WriteLine("3) Zurück");

                        i = GetKeyValInRange(1, 3);

                        if (i >= 0)
                        {
                            cont = false;

                            if (i == 3)
                            {
                                break;
                            }
                        }
                        else
                        {
                            continue;
                        }

                        switch (i)
                        {
                            case (1):
                                dic = new MultiSetUnsortedArray();
                                break;

                            case (2):
                                dic = new MultiSetUnsortedLinkedList();
                                break;
                        }

                        break;
                }
            }
        }

        /// <summary>
        /// Verarbeitet das Menü zum bearbeiten des Dictionaries
        /// </summary>
        private static void ProcessDictionaryFunctions()
        {
            int i;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bitte wählen Sie eine Aktion aus:");
                Console.WriteLine("1) Einen Wert hinzufügen");
                Console.WriteLine("2) Mehrere Werte hinzufügen");
                Console.WriteLine("3) Wert suchen");
                Console.WriteLine("4) Wert löschen");
                Console.WriteLine("5) Werte ausgeben");
                Console.WriteLine("");
                Console.WriteLine("6) Beenden");

                i = GetKeyValInRange(1, 6);

                if (i > 0)
                {
                    if (i == 6)
                    {
                        break;
                    }
                }
                else
                {
                    continue;
                }

                switch (i)
                {
                    case (1):
                        AddSingleValue();
                        break;

                    case (2):
                        AddMultipleValues();
                        break;

                    case (3):
                        SearchValue();
                        break;

                    case (4):
                        RemoveValue();
                        break;

                    case (5):
                        Console.Clear();
                        dic.Print();
                        Console.WriteLine();
                        WaitForEnter();
                        break;

                }

            }

        }

        /// <summary>
        /// Fügt einen einzelnen Eintrag zum Dictionary hinzu
        /// </summary>
        private static bool AddSingleValue()
        {
            Console.Clear();
            Console.WriteLine("Bitte geben Sie eine positive Ganzzahl ein oder lassen Sie das Feld leer, um keinen Wert hinzuzufügen.");
            Console.WriteLine("Bestätigen Sie anschließend mit Enter.");

            return AddDicValue();
        }


        /// <summary>
        /// Fügt mehrere Einträge zum Dictionary hinzu
        /// </summary>
        private static void AddMultipleValues()
        {
            while (true)
            {
                if (AddSingleValue())
                {
                    break;
                }
            }


        }


        /// <summary>
        /// Sucht nach einem Wert im Dictionary
        /// </summary>
        private static void SearchValue()
        {
            Console.Clear();
            Console.WriteLine("Geben Sie einen Wert ein, nach dem gesucht werden soll.");

            int i = GetConsoleValue();

            if (i >= 0)
            {
                if (dic.Search(i))
                {
                    Console.WriteLine("Der Wert {0} wurde gefunden.", i);
                } else
                {
                    Console.WriteLine("Der Wert {0} konnte nicht gefunden werden.", i);
                }

            }

            Console.WriteLine();
            WaitForEnter();
        }

        /// <summary>
        /// Löscht einen Wert aus dem Dictionary.
        /// </summary>
        private static void  RemoveValue()
        {
            Console.Clear();
            Console.WriteLine("Geben Sie einen Wert ein, der entfernt werden soll.");

            int i = GetConsoleValue();

            if (i >= 0)
            {
                if (dic.Delete(i))
                {
                    Console.WriteLine("Der Wert {0} wurde gelöscht.", i);
                }
                else
                {
                    Console.WriteLine("Der Wert {0} konnte nicht gelöscht werden.", i);
                }

            }

            Console.WriteLine();
            WaitForEnter();
        }


        /// <summary>
        /// Hilfsmethode zum Einfügen von Werten
        /// </summary>
        /// <returns>True, wenn abgebrochen werden soll, sonst false.</returns>
        private static bool AddDicValue()
        {
            int i = GetConsoleValue();

            if (i >= -1)
            {
                if (i >= 0)
                {
                    dic.Insert(i);
                }
                
                return false;
            }

            return true;
        }


        /// <summary>
        /// Gibt einen in die Konsole eingegebenen Wert als int zurück.
        /// </summary>
        /// <returns>Einen positiven int-Wert oder -1, wenn etwas schief gegangen ist.</returns>
        private static int GetConsoleValue()
        {
            String s = Console.ReadLine();

            if (String.IsNullOrEmpty(s))
            {
                return -2;
            }

            try
            {
                int i = Convert.ToInt32(s);


                if (i >= 0)
                {
                    return i;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Nur positive Werte erlaubt");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Bitte geben Sie einen gültigen Wert ein. Es wurde kein Wert hinzugefügt.");
                WaitForEnter();
                return -1;
            }

        }


        /// <summary>
        /// Hilfsmethode zum auslesen einer Zahl aus der Konsole direkt bei Tastendruck.
        /// </summary>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        /// <returns>Die ausgelesene zahl oder -1, wenn das Zeichen keine Zahl zwischen Minimum und Maximum ist.</returns>
        private static int GetKeyValInRange(int min, int max)
        {
            int i = Console.ReadKey().KeyChar - 0x30;

            if (i >= min && i <= max)
            {
                return i;
            }
            return -1;
        }


        /// <summary>
        /// HIlfsmethode für das Warten auf Enter
        /// </summary>
        private static void WaitForEnter()
        {
            Console.WriteLine("Drücken Sie Enter, um fortzufahren.");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }

    }
}
