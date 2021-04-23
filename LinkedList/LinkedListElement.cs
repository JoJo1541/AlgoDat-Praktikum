using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.LinkedList
{
    /// <summary>
    /// Ein Element der einer LinkedList
    /// </summary>
    class LinkedListElement
    {
        private LinkedListElement left;
        private LinkedListElement right;

        private int value;

        public LinkedListElement LeftElement
        {
            get { return left; }
            set { left = value; }
        }

        public LinkedListElement RightElement
        {
            get { return right; }
            set { right = value; }
        }

        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }





    }
}
