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

        private TreeElement parentElement;
        private TreeElement childElementLeft;
        private TreeElement childElementRight;
        private int value;

        ParentNodeRelation rel;

        public TreeElement(TreeElement root, int value)
        {
            this.parentElement = root;
            this.value = value;

            if (root == null)
            {
                this.ParentRelation = ParentNodeRelation.Root;
            }

        }

        public TreeElement ChildElementLeft
        {
            get { return childElementLeft; }
            set 
            { 
                this.childElementLeft = value;

                if (value == null)
                {
                    return;
                }
                this.childElementLeft.ParentRelation = ParentNodeRelation.LeftChild;
                this.childElementLeft.ParentElement = this;
            }
        }

        public TreeElement ChildElementRight
        {
            get { return childElementRight; }
            set 
            {
                this.childElementRight = value;

                if (value == null)
                {
                    return;
                }
                this.childElementRight.ParentRelation = ParentNodeRelation.RightChild;
                this.childElementRight.ParentElement = this;
            }
        }

        public TreeElement ParentElement
        {
            get { return parentElement; }
            set { 
                this.parentElement = value; 

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
    }
}
