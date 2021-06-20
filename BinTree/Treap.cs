using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.BinTree
{
    class Treap : BinSearchTree
    {

        public override bool Delete(int elem)
        {
            TreapElement e = (TreapElement)this.TraverseAndFind(elem);

            if (e == null)
            {
                return false;
            }

            this.RotateElementToLeaf(e);

            if (e.ParentRelation == TreeElement.ParentNodeRelation.Root)
            {
                this.RootElement = null;
            }
            else if (e.ParentRelation == TreeElement.ParentNodeRelation.LeftChild)
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

            e = new TreapElement(elem, r);
            
            if (current == null)
            {
                this.RootElement = e;

                return true;
            }
            
            if (elem < current.Value)
            {
                current.ChildLeft = e;
            }
            else
            {
                current.ChildRight = e;
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
        }


        private void RotateElementToLeaf(TreapElement elem)
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
            
            RotateElementToLeaf(elem);
        }

    }
}
