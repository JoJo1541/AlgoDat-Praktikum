﻿using System;
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
                e.ParentElement.ChildElementLeft = null;
            } 
            else
            {
                e.ParentElement.ChildElementRight = null;
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
                lastFoundElement.ChildElementLeft = e;
            }
            else
            {
                e = new TreapElement(lastFoundElement, elem, r);
                lastFoundElement.ChildElementRight = e;
            }

            EnsureUpwardsHeapCondition(e);

            return true;
        }


        private void EnsureUpwardsHeapCondition(TreapElement elem)
        {
            while (elem.ParentElement != null && elem.Priority <= ((TreapElement)elem.ParentElement).Priority)
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

            if (elem.ParentElement == null)
            {
                this.RootElement = elem;
            }
        }


        private void RotateElemetToLeaf(TreapElement elem)
        {
            while (elem.ChildElementRight != null && elem.ChildElementLeft != null)
            {

                if (((TreapElement) elem.ChildElementLeft).Priority < ((TreapElement) elem.ChildElementRight).Priority)
                {
                    this.RotateRight((TreapElement) elem.ChildElementLeft);
                }
                else
                {
                    this.RotateLeft((TreapElement) elem.ChildElementRight);
                }
            }
        }

    }
}
