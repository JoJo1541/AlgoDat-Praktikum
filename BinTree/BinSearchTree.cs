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
            if (e.ChildLeft == null && e.ChildRight == null)
            {
                // Sind wir die Wurzel, setzen wir uns auf null
                TreeElement parent = e.Parent;
                if (parent == null)
                {
                    this.RootElement = null;
                    return true;
                }

                // Sind wir es nicht, lösche uns aus dem parent
                if (elem < parent.Value)
                {
                    parent.ChildLeft = null;
                } 
                else
                {
                    parent.ChildRight = null;
                }
                return true;
            }

            // Wir haben zwei Nachfolger (4)
            if (e.ChildLeft != null && e.ChildRight != null)
            {
                TreeElement a = e, b;

                // Gibt es im Linken Nachfolgerteilbaum ein größeres Element als das ChildLeft?
                if (a.ChildLeft.ChildRight != null)
                {
                    // Wenn Ja, gehen wir den Teilbaum durch, bis wir den größten Wert aus ihm haben und setzen a darauf
                    a = a.ChildLeft;
                    while (a.ChildRight.ChildRight != null)
                    {
                        a = a.ChildRight;
                    }
                }

                // Ist a gleich e, also e schon das größte Element im Teilbaum, speichern wir den Linken Nachfolger zwischen und ersetzen ihn mit seinem symmetrischen Vorgägner
                if (a == e)
                {
                    b = a.ChildLeft;
                    a.ChildLeft = b.ChildLeft;
                } 
                // Wenn nicht, speichern wir den größten Wert aus dem Teilbaum (in diesem Fall der rechte Nachfolger von a) zwischen und setzen seinen linken Nachfolger als neuen rechten Nachfolger von a
                else
                {
                    b = a.ChildRight;
                    a.ChildRight = b.ChildLeft;
                }

                // Am Ende wird noch der in b zwischengespeicherte Wert an Stelle von e geschrieben.
                e.Value = b.Value;
                return true;
            }


            // Wenn es nur einen linken Nachfolger gibt (3)
            if (e.ChildLeft != null)
            {   
                // e ist die Wurzel
                if (e.ParentRelation == ParentNodeRelation.Root)
                {
                    // Setze linkes child als neue Wurzel
                    e.ChildLeft.Parent = null;
                    this.RootElement = e.ChildLeft;
                    
                } 
                else
                {   
                    // Sonst hole das parent und verlinke entsprechend.
                    p = e.Parent;
                    if (e.ParentRelation == ParentNodeRelation.LeftChild)
                    {
                        p.ChildLeft = e.ChildLeft;
                    }
                    else
                    {
                        p.ChildRight = e.ChildLeft;
                    }
                    
                }
               
            }
            // Oder nur einen rechten
            else
            {
                // e ist die Wurzel
                if (e.ParentRelation == ParentNodeRelation.Root)
                {
                    // Setze rechtes child als neue Wurzel
                    e.ChildRight.Parent = null;
                    this.RootElement = e.ChildRight;

                }
                else
                {
                    // Sonst hole das parent und verlinke entsprechend.
                    p = e.Parent;
                    if (e.ParentRelation == ParentNodeRelation.LeftChild)
                    {
                        p.ChildLeft = e.ChildRight;
                    }
                    else
                    {
                        p.ChildRight = e.ChildRight;
                    }

                }
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
                lastFoundElement.ChildLeft = new TreeElement(lastFoundElement, elem);
            } 
            else
            {
                lastFoundElement.ChildRight = new TreeElement(lastFoundElement, elem);
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

            if (root.ChildLeft != null)
            {
                TraverseAndPrintInOrder(root.ChildLeft);
            }

            Console.Write(root.ToString());

            if (root.ChildRight != null)
            {
                TraverseAndPrintInOrder(root.ChildRight);
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

            TraverseAndPrintInReverse(node.ChildRight, lvl + 1);

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

            TraverseAndPrintInReverse(node.ChildLeft, lvl + 1);
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
                    e = e.ChildRight;
                }
                else
                {
                    e = e.ChildLeft;
                }
            }
            
            return e;
        }


        protected void RotateLeft(TreeElement elem)
        {
            // Linken Teilbaum an Parent hängen
            elem.Parent.ChildRight = elem.ChildLeft;


            // Parent zum neuen linken Teilbaum machen und parent für elem setzen
            TreeElement e = elem.Parent.Parent;
            ParentNodeRelation pr = elem.Parent.ParentRelation;

            elem.ChildLeft = elem.Parent;

            if (pr == ParentNodeRelation.LeftChild)
            {
                e.ChildLeft = elem;
            }
            else if (pr == ParentNodeRelation.RightChild)
            {
                e.ChildRight = elem;
            }
            else if (pr == ParentNodeRelation.Root)
            {
                elem.Parent = null;
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
            elem.Parent.ChildLeft = elem.ChildRight;


            // Parent zum neuen rechten Teilbaum machen und parent für elem setzen
            TreeElement e = elem.Parent.Parent;
            ParentNodeRelation pr = elem.Parent.ParentRelation;

            elem.ChildRight = elem.Parent;

            if (pr == ParentNodeRelation.LeftChild)
            {
                e.ChildLeft = elem;
            } 
            else if (pr == ParentNodeRelation.RightChild)
            {
                e.ChildRight = elem;
            }
            else if (pr == ParentNodeRelation.Root)
            {
                elem.Parent = null;
                this.root = elem;
            }
            
        }
    }
}
