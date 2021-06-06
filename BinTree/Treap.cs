using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.BinTree
{
    class Treap : BinSearchTree
    {

        public override bool Delete(int elem)
        {
            TreapElement e = (TreapElement) this.TraverseAndFind(elem);

            if (e == null)
            {
                return false;
            }

            this.RotateElemetToLeaf(e);

            if (e.ParentRelation == TreeElement.ParentNodeRelation.LeftChild)
            {
                e.Parent.ChildLeft = null;
            } 
            else
            {
                e.Parent.ChildRight = null;
            }

            return true;
        }


        public override bool Insert(int elem)
        {
            int r;
            TreapElement e;

            if (this.Search(elem))
            {
                return false;
            }

            r = new Random().Next(1, 1000);

            if (lastFoundElement == null)
            {
                e = new TreapElement(null, elem, r);
                this.RootElement = e;
            }
            else
            if (elem < lastFoundElement.Value)
            {
                e = new TreapElement(lastFoundElement, elem, r); ;
                lastFoundElement.ChildLeft = e;
            }
            else
            {
                e = new TreapElement(lastFoundElement, elem, r);
                lastFoundElement.ChildRight = e;
            }

            EnsureUpwardsHeapCondition(e);

            return true;
        }


        private void EnsureUpwardsHeapCondition(TreapElement elem)
        {
            while (elem.Parent != null && elem.Priority <= ((TreapElement)elem.Parent).Priority)
            {
                if (elem.ParentRelation == TreeElement.ParentNodeRelation.LeftChild)
                {
                    this.RotateRight(elem);
                }
                else
                {
                    this.RotateLeft(elem);
                }
            }

            if (elem.Parent == null)
            {
                this.RootElement = elem;
            }
        }


        private void RotateElemetToLeaf(TreapElement elem)
        {
            if (elem.ChildLeft == null && elem.ChildRight == null)
            {
                // Console.WriteLine("No Rot");
                return;
            }

            if (elem.ChildLeft == null && elem.ChildRight != null)
            {
                // Console.WriteLine("Rot Left on Child Right");
                this.RotateLeft(elem.ChildRight);
            }
            else if (elem.ChildLeft != null && elem.ChildRight == null)
            {
                // Console.WriteLine("Rot Right on Child Left");
                this.RotateRight(elem.ChildLeft);
            }
            else
            {
                if (((TreapElement)elem.ChildLeft).Priority < ((TreapElement)elem.ChildRight).Priority)
                {
                    // Console.WriteLine("Rot Right on Child Left");
                    this.RotateRight(elem.ChildLeft);
                }
                else
                {
                    // Console.WriteLine("Rot Left on Child Right");
                    this.RotateLeft(elem.ChildRight);
                }
            }


            RotateElemetToLeaf(elem);
        }

    }
}
