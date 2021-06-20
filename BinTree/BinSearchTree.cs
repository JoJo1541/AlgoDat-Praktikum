using System;
using static Praktikum.BinTree.TreeElement;

namespace Praktikum.BinTree
{
    /// <summary>
    /// Implementierung BinSearchTreee
    /// </summary>
    class BinSearchTree : ISetSorted
    {
        private TreeElement root;
        protected TreeElement current;

        public TreeElement RootElement
        {
            get { return this.root; }
            set
            {
                this.root = value;

                if (this.root != null)
                    this.root.Parent = null;
            }
        }

        public virtual bool Delete(int elem)
        {
            if (!Search(elem))
                return false;
            
            if (current.ChildLeft != null && current.ChildRight != null)
            {
                TreeElement symmetricPredecessor = current.ChildLeft;
                
                while (symmetricPredecessor.ChildRight != null)
                {
                    symmetricPredecessor = symmetricPredecessor.ChildRight;
                }

                current.Value = symmetricPredecessor.Value;
                
                current = symmetricPredecessor;
            }

            if (current.ParentRelation == ParentNodeRelation.Root)
            {
                RootElement = RootElement.ChildLeft ?? RootElement.ChildRight;
            }
            else
            {
                TreeElement parent = current.Parent;
                
                if (current.ParentRelation == ParentNodeRelation.LeftChild)
                {
                    parent.ChildLeft = current.ChildLeft ?? current.ChildRight;
                }
                else
                {
                    parent.ChildRight = current.ChildLeft ?? current.ChildRight;
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

            TreeElement add = new TreeElement(elem);
            
            if (RootElement == null)
            {
                this.RootElement = add;
            }
            else if (elem < current.Value)
            {
                current.ChildLeft = add;
            }
            else
            {
                current.ChildRight = add;
            }

            return true;
        }


        public void Print()
        {
            TraverseAndPrintInReverse(root, 0);
        }


        public bool Search(int elem)
        {
            if (RootElement == null)
                return false;

            current = RootElement;

            while (current.Value != elem)
            {
                if (elem < current.Value)
                    if (current.ChildLeft != null)
                        current = current.ChildLeft;
                    else
                        return false;
                else if (current.ChildRight != null)
                    current = current.ChildRight;
                else
                    return false;
            }

            return true;
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

            // if (node.ParentRelation == TreeElement.ParentNodeRelation.RightChild)
            // {
            //     Console.WriteLine("/" + node.ToString());
            // }
            // else
            // if (node.ParentRelation == TreeElement.ParentNodeRelation.LeftChild)
            // {
            //     Console.WriteLine("\\" + node.ToString());
            // }
            // else
            // {
                Console.WriteLine(node.ToString());
            //}

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
                this.current = e;
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


        protected void RotateLeft(TreeElement rotateUp)
        {
            /*  grandParent              grandParent
             *      /|\                     /|\
             *   rotateDown     -->       rotateUp
             *           \                /
             *        rotateUp       rotateDown
             *        /                       \
             *       a                         a
             */
            
            TreeElement rotateDown = rotateUp.Parent;
            
            TreeElement grandParent = rotateDown.Parent;
            
            ParentNodeRelation parentRelation = rotateDown.ParentRelation;
            
            //Die eigentliche Rotation. Nur diese zwei Zeilen sind verschieden zur anderen Rotationsrichtung
            rotateDown.ChildRight = rotateUp.ChildLeft;

            rotateUp.ChildLeft = rotateDown;

            //Neue Wurzel des Teilbaumes wieder passend an den Elternknoten hängen bzw. als RootElement setzen
            if (parentRelation == ParentNodeRelation.LeftChild)
            {
                grandParent.ChildLeft = rotateUp;
            }
            else if (parentRelation == ParentNodeRelation.RightChild)
            {
                grandParent.ChildRight = rotateUp;
            }
            else if (parentRelation == ParentNodeRelation.Root)
            {
                this.RootElement = rotateUp;
            }
        }

        protected void RotateRight(TreeElement rotateUp)
        {
            /*      grandParent            grandParent
             *         /|\                    /|\
             *     rotateDown     -->       rotateUp
             *     /                              \
             * rotateUp                       rotateDown
             *       \                        /
             *        a                      a
             */
            TreeElement rotateDown = rotateUp.Parent;
            
            TreeElement grandParent = rotateDown.Parent;
            
            ParentNodeRelation pr = rotateUp.Parent.ParentRelation;
            
            //Die eigentliche Rotation. Nur diese zwei Zeilen sind verschieden zur anderen Rotationsrichtung
            rotateDown.ChildLeft = rotateUp.ChildRight;

            rotateUp.ChildRight = rotateDown;

            //Neue Wurzel des Teilbaumes wieder passend an den Elternknoten hängen bzw. als RootElement setzen
            if (pr == ParentNodeRelation.LeftChild)
            {
                grandParent.ChildLeft = rotateUp;
            }
            else if (pr == ParentNodeRelation.RightChild)
            {
                grandParent.ChildRight = rotateUp;
            }
            else if (pr == ParentNodeRelation.Root)
            {
                this.RootElement = rotateUp;
            }

        }
    }
}
