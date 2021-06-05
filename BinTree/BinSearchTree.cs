using System;
using System.Collections.Generic;
using System.Text;
using static Praktikum.BinTree.TreeElement;

namespace Praktikum.BinTree
{
    /// <summary>
    /// Implementierung BinSearchTreee
    /// </summary>
    class BinSearchTree : ISetSorted
    {
        private TreeElement root;
        protected TreeElement lastFoundElement;

        public TreeElement RootElement
        {
            get { return this.root; }
            set { this.root = value; }
        }


        public virtual bool Delete(int elem)
        {
            TreeElement e = TraverseAndFind(elem);
            TreeElement p;

            // Nicht gefunden (1)
            if (e == null)
            {
                return false;
            }

            // Wir sind ein Blatt (2)
            if (e.ChildElementLeft == null && e.ChildElementRight == null)
            {
                // Sind wir die Wurzel, setzen wir uns auf null
                TreeElement parent = e.ParentElement;
                if (parent == null)
                {
                    this.RootElement = null;
                    return true;
                }

                // Sind wir es nicht, lösche uns aus dem parent
                if (elem < parent.Value)
                {
                    parent.ChildElementLeft = null;
                } 
                else
                {
                    parent.ChildElementRight = null;
                }
                return true;
            }

            // Wir haben zwei Nachfolger (4)
            if (e.ChildElementLeft != null && e.ChildElementRight != null)
            {
                TreeElement a = e, b;

                // Gibt es im Linken Nachfolgerteilbaum ein größeres Element als das ChildLeft?
                if (a.ChildElementLeft.ChildElementRight != null)
                {
                    // Wenn Ja, gehen wir den Teilbaum durch, bis wir den größten Wert aus ihm haben und setzen a darauf
                    a = a.ChildElementLeft;
                    while (a.ChildElementRight.ChildElementRight != null)
                    {
                        a = a.ChildElementRight;
                    }
                }

                // Ist a gleich e, also e schon das größte Element im Teilbaum, speichern wir den Linken Nachfolger zwischen und ersetzen ihn mit seinem symmetrischen Vorgägner
                if (a == e)
                {
                    b = a.ChildElementLeft;
                    a.ChildElementLeft = b.ChildElementLeft;
                } 
                // Wenn nicht, speichern wir den größten Wert aus dem Teilbaum (in diesem Fall der rechte Nachfolger von a) zwischen und setzen seinen linken Nachfolger als neuen rechten Nachfolger von a
                else
                {
                    b = a.ChildElementRight;
                    a.ChildElementRight = b.ChildElementLeft;
                }

                // Am Ende wird noch der in b zwischengespeicherte Wert an Stelle von e geschrieben.
                e.Value = b.Value;
                return true;
            }


            // Wenn es nur einen linken Nachfolger gibt (3)
            if (e.ChildElementLeft != null)
            {
                p = e.ParentElement;
                p.ChildElementLeft = e.ChildElementLeft;
            }
            // Oder nur einen rechten
            else
            {
                p = e.ParentElement;
                p.ChildElementRight = e.ChildElementRight;
            }

            return true;
        }


        public virtual bool Insert(int elem)
        {
            if (this.Search(elem)) {
                return false;
            }


            if (lastFoundElement == null)
            {
                this.root = new TreeElement(null, elem);
                return true;
            }

            if (elem < lastFoundElement.Value)
            {
                lastFoundElement.ChildElementLeft = new TreeElement(lastFoundElement, elem);
            } 
            else
            {
                lastFoundElement.ChildElementRight = new TreeElement(lastFoundElement, elem);
            }

            return true;
        }


        public void Print()
        {
            TraverseAndPrintInReverse(root, 0);
        }


        public bool Search(int elem)
        {
            return TraverseAndFind(elem) != null;
        }


        /// <summary>
        /// Sortierte Ausgabe für bäume vom kleinsten Element hin zum größten
        /// </summary>
        /// <param name="root"></param>
        private void TraverseAndPrintInOrder(TreeElement root)
        {
            if (root == null)
            {
                return;
            }

            if (root.ChildElementLeft != null)
            {
                TraverseAndPrintInOrder(root.ChildElementLeft);
            }

            Console.Write(root.ToString());

            if (root.ChildElementRight != null)
            {
                TraverseAndPrintInOrder(root.ChildElementRight);
            }
        }

        /// <summary>
        /// Gibt den Binärbaum von der untersten Ebene und größtem Wert bis zum kleinsten Wert aus.
        /// </summary>
        /// <param name="node">Der Startknoten für den Baum</param>
        /// <param name="lvl">Level des Knotens für Rekursion</param>
        private void TraverseAndPrintInReverse(TreeElement node, int lvl)
        {
            if (node == null)
            {
                return;
            }

            TraverseAndPrintInReverse(node.ChildElementRight, lvl + 1);

            for (int x = 0; x < lvl; x++)
            {
                Console.Write("    ");
            }

            if (node.ParentRelation == TreeElement.ParentNodeRelation.RightChild)
            {
                Console.WriteLine("/" + node.ToString());
            } else
            if (node.ParentRelation == TreeElement.ParentNodeRelation.LeftChild)
            {
                Console.WriteLine("\\" + node.ToString());
            }
            else
            {
                Console.WriteLine(node.ToString());
            }

            TraverseAndPrintInReverse(node.ChildElementLeft, lvl + 1);
        }


        /// <summary>
        /// Durchsucht den Binärbaum nach einem Wert.
        /// </summary>
        /// <param name="targetValue">Der zu suchende Wert</param>
        /// <returns>Das TreeElement mit dem gesuchten Wert oder null, wenn ncihts gefunden wurde.</returns>
        protected TreeElement TraverseAndFind(int targetValue)
        {
            TreeElement e = root;

            while (e != null && e.Value != targetValue)
            {
                this.lastFoundElement = e;
                if (e.Value < targetValue)
                {
                    e = e.ChildElementRight;
                }
                else
                {
                    e = e.ChildElementLeft;
                }
            }
            
            return e;
        }


        protected void RotateLeft(TreeElement elem)
        {
            // Linken Teilbaum an Parent hängen
            elem.ParentElement.ChildElementRight = elem.ChildElementLeft;


            // Parent zum neuen linken Teilbaum machen und parent für elem setzen
            TreeElement e = elem.ParentElement.ParentElement;
            ParentNodeRelation pr = elem.ParentElement.ParentRelation;

            elem.ChildElementLeft = elem.ParentElement;

            if (pr == ParentNodeRelation.LeftChild)
            {
                e.ChildElementLeft = elem;
            }
            else if (pr == ParentNodeRelation.RightChild)
            {
                e.ChildElementRight = elem;
            }
            else if (pr == ParentNodeRelation.Root)
            {
                elem.ParentElement = null;
                this.root = elem;
            }
        }

        protected void RotateRight(TreeElement elem)
        {
            /*      b           a = elem;
             *    /   \
             *   a     C
             *  / \
             * A   B
             */

            // Rechten Teilbaum an Parent hängen
            elem.ParentElement.ChildElementLeft = elem.ChildElementRight;


            // Parent zum neuen rechten Teilbaum machen und parent für elem setzen
            TreeElement e = elem.ParentElement.ParentElement;
            ParentNodeRelation pr = elem.ParentElement.ParentRelation;

            elem.ChildElementRight = elem.ParentElement;

            if (pr == ParentNodeRelation.LeftChild)
            {
                e.ChildElementLeft = elem;
            } 
            else if (pr == ParentNodeRelation.RightChild)
            {
                e.ChildElementRight = elem;
            }
            else if (pr == ParentNodeRelation.Root)
            {
                elem.ParentElement = null;
                this.root = elem;
            }
            
        }
    }
}
