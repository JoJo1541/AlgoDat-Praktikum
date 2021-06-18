using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.BinTree
{
    /// <summary>
    /// Ein Binärbaum Element
    /// </summary>
    class TreeElement
    {
        public enum ParentNodeRelation
        {
            LeftChild,
            RightChild,
            Root
        }

        private TreeElement parent;
        private TreeElement childLeft;
        private TreeElement childRight;
        private int value;

        ParentNodeRelation rel;

        public TreeElement(TreeElement root, int value)
        {
            this.parent = root;
            this.value = value;

            if (root == null)
            {
                this.ParentRelation = ParentNodeRelation.Root;
            }

        }

        public TreeElement ChildLeft
        {
            get { return childLeft; }
            set 
            { 
                this.childLeft = value;

                if (value == null)
                {
                    return;
                }
                this.childLeft.ParentRelation = ParentNodeRelation.LeftChild;
                this.childLeft.Parent = this;
            }
        }

        public TreeElement ChildRight
        {
            get { return childRight; }
            set 
            {
                this.childRight = value;

                if (value == null)
                {
                    return;
                }
                this.childRight.ParentRelation = ParentNodeRelation.RightChild;
                this.childRight.Parent = this;
            }
        }

        public TreeElement Parent
        {
            get { return parent; }
            set { 
                this.parent = value; 

                if (value == null)
                {
                    this.ParentRelation = ParentNodeRelation.Root;
                }
            }
        }

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }


        public ParentNodeRelation ParentRelation
        {
            get { return this.rel; }
            set { this.rel = value; }
        }

        
        public override string ToString()
        {
            return this.Value.ToString();
        }

        public AVLTree.Direction GetParentDirection()
        {
            if (Parent == null)
                return AVLTree.Direction.None;

            return Parent.ChildRight == this ? AVLTree.Direction.Right : AVLTree.Direction.Left;
        }
    }
}
