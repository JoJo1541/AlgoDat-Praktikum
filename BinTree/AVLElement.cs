using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.BinTree
{
    class AVLElement : TreeElement
    {
        public int BalanceFactor = 0;

        public AVLElement(int value) : base(value) { }

        public override string ToString()
        {
            string result;
            switch (BalanceFactor)
            {
                case -2:
                    result = "--";
                    break;
                case -1:
                    result = "-";
                    break;
                case 0:
                    result = "o";
                    break;
                case 1:
                    result = "+";
                    break;
                case 2:
                    result = "++";
                    break;
                default:
                    result = "ERROR";
                    break;
            }

            return result + base.ToString();
        }
    }
}
