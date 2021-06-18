using System;
using System.Collections.Generic;
using System.Text;
using static Praktikum.BinTree.AVLTree;

namespace Praktikum.BinTree
{
    class AVLTreeElement : TreeElement
    {
       
        public int BalanceFactor = 0;
        public AVLTreeElement(TreeElement root, int value) : base(root, value) {
          
        }
        public override string ToString()
        {
            string result;

            switch (BalanceFactor)
            {
                case 0:
                    result = "o";
                    break;
                case 1:
                    result = "+";
                    break;
                case -1:
                    result = "-";
                    break;
                case 2:
                    result = "++";
                    break;
                case -2:
                    result = "--";
                    break;
                default:
                    result = "Error";
                    break;
            }

            return$"({result})"+ " " + base.ToString();
        }

     
    }
}
