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
        private TreeElement rootElement;
        private TreeElement childElementLeft;
        private TreeElement childElementRight;
        private int value;

        public TreeElement(TreeElement root, int value)
        {
            this.rootElement = root;
            this.value = value;
        }

        public TreeElement ChildElementLeft
        {
            get { return childElementLeft; }
            set { this.childElementLeft = value; }
        }

        public TreeElement ChildElementRight
        {
            get { return childElementRight; }
            set { this.childElementRight = value; }
        }

        public TreeElement RootElement
        {
            get { return rootElement; }
            set { this.rootElement = value; }
        }

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
