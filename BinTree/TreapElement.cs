using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum.BinTree
{
    class TreapElement : TreeElement
    {
        int prio;
        
        
        public TreapElement(int value, int prio) : base(value)
        {
            this.prio = prio;
        }

        public int Priority
        {
            get { return this.prio; }
            set { this.prio = value; }
        }

        public override string ToString()
        {
            return base.ToString() + "(" + this.Priority + ")";
        }

    }
}
