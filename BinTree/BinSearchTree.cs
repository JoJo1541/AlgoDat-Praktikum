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
            TreeElement toBeDeleted = TraverseAndFind(elem);
            if (toBeDeleted == null)
            {
                return false;
            }

            if (toBeDeleted.ChildLeft != null && toBeDeleted.ChildRight != null)
            {
                TreeElement a = toBeDeleted.ChildLeft;
                while (a.ChildRight != null)
                {
                    a = a.ChildRight;
                }
                toBeDeleted = a;
            }

            if (toBeDeleted.ParentRelation == ParentNodeRelation.Root)
            {
                root = root.ChildLeft ?? root.ChildRight;

                if (root != null)
                {
                    root.Parent = null;
                }
            }
            else
            {
                TreeElement parent = toBeDeleted.Parent;
                if (toBeDeleted.ParentRelation == ParentNodeRelation.LeftChild)
                {
                    parent.ChildLeft = toBeDeleted.ChildLeft ?? toBeDeleted.ChildRight;
                }
                else
                {
                    parent.ChildRight = toBeDeleted.ChildLeft ?? toBeDeleted.ChildRight;
                }
            }
            return true;
        }


        public virtual bool Insert(int elem)
        {
            if (this.Search(elem))
            {
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
            }
            else
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
