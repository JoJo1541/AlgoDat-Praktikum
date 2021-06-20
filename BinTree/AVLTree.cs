using static Praktikum.BinTree.TreeElement;

namespace Praktikum.BinTree
{
    class AVLTree : BinSearchTree
    {

        public override bool Delete(int elem)
        {
            if (!Search(elem))
                return false;
            
            if (current.ChildLeft != null && current.ChildRight != null)
            {
                var symmetricPredecessor = current.ChildLeft;
                
                while (symmetricPredecessor.ChildRight != null)
                {
                    symmetricPredecessor = symmetricPredecessor.ChildRight;
                }

                current.Value = symmetricPredecessor.Value;
                
                current = symmetricPredecessor;
            }

            if (current.ParentRelation == ParentNodeRelation.Root)
            {
                RootElement = RootElement.ChildLeft ?? RootElement.ChildRight;
            }
            else
            {
                var parent = current.Parent;
                
                if (current.ParentRelation == ParentNodeRelation.LeftChild)
                {
                    parent.ChildLeft = current.ChildLeft ?? current.ChildRight;
                    
                    RemovedLeft(parent as AVLElement);
                }
                else
                {
                    parent.ChildRight = current.ChildLeft ?? current.ChildRight;
                    
                    RemovedRight(parent as AVLElement);
                }
            }
            return true;
        }

        public override bool Insert(int elem)
        {
            if (this.Search(elem))
            {
                return false;
            }

            AVLElement add = new AVLElement(elem);
            
            if (RootElement == null)
            {
                this.RootElement = add;
            }
            else if (elem < current.Value)
            {
                current.ChildLeft = add;
                AddedLeft(current as AVLElement);
            }
            else
            {
                current.ChildRight = add;
                AddedRight(current as AVLElement);
            }

            return true;
        }

        private void AddedLeft(AVLElement element)
        {
            element.BalanceFactor--;
            
            switch (element.BalanceFactor)
            {
                case 0:
                    return;
                case -1:
                    if (element == RootElement)
                        return;
                    if (element.Parent.ChildRight == element)
                        AddedRight(element.Parent as AVLElement);
                    else
                        AddedLeft(element.Parent as AVLElement);
                    break;
                case -2:
                    if ((element.ChildLeft as AVLElement).BalanceFactor==1)
                    {
                        RotateLeft(element.ChildLeft.ChildRight);
                        
                        RotateRight(element.ChildLeft);
                        
                        SetBalanceAfterDoubleRotation(element.Parent as AVLElement);
                    }
                    else
                    {
                        RotateRight(element.ChildLeft);
                        
                        element.BalanceFactor = 0;
                        
                        (element.Parent as AVLElement).BalanceFactor = 0;
                    }
                    break;
            }
        }
        
        private void AddedRight(AVLElement element)
        {
            element.BalanceFactor++;

            switch (element.BalanceFactor)
            {
                case 0:
                    return;
                case 1:
                    if (element == RootElement)
                        return;
                    if (element.Parent.ChildRight == element)
                        AddedRight(element.Parent as AVLElement);
                    else
                        AddedLeft(element.Parent as AVLElement);
                    break;
                case 2:
                    if ((element.ChildRight as AVLElement).BalanceFactor == -1)
                    {
                        RotateRight(element.ChildRight.ChildLeft);
                        
                        RotateLeft(element.ChildRight);
                        
                        SetBalanceAfterDoubleRotation(element.Parent as AVLElement);
                    }
                    else
                    {
                        RotateLeft(element.ChildRight);
                        
                        element.BalanceFactor = 0;
                        
                        (element.Parent as AVLElement).BalanceFactor = 0;
                    }
                    break;
            }
        }

        private void RemovedLeft(AVLElement element)
        {
            element.BalanceFactor++;

            switch (element.BalanceFactor)
            {
                case 1:
                    return;
                case 0:
                    if (element == RootElement)
                        return;
                    if (element.Parent.ChildRight == element)
                        RemovedRight(element.Parent as AVLElement);
                    else
                        RemovedLeft(element.Parent as AVLElement);
                    break;
                case 2:
                    AVLElement subRoot;
                    if ((element.ChildRight as AVLElement).BalanceFactor == -1)
                    {
                        RotateRight(element.ChildRight.ChildLeft);
                        
                        RotateLeft(element.ChildRight);

                        subRoot = element.Parent as AVLElement;
                        
                        SetBalanceAfterDoubleRotation(subRoot);
                    }
                    else
                    {
                        RotateLeft(element.ChildRight);
                        
                        subRoot = element.Parent as AVLElement;
                        
                        if (subRoot.BalanceFactor == 0)
                        {
                            element.BalanceFactor = 1;
                            
                            subRoot.BalanceFactor = -1;
                            
                            return;
                        }

                        element.BalanceFactor = subRoot.BalanceFactor = 0;
                    }

                    if (subRoot == RootElement)
                        return;
                    
                    if (subRoot.Parent.ChildRight == subRoot)
                        RemovedRight(subRoot.Parent as AVLElement);
                    else
                        RemovedLeft(subRoot.Parent as AVLElement);
                    break;
            }
        }

        private void RemovedRight(AVLElement element)
        {
            element.BalanceFactor--;
            
            switch (element.BalanceFactor)
            {
                case -1:
                    return;
                case 0:
                    if (element == RootElement)
                        return;
                    if (element.Parent.ChildRight == element)
                        RemovedRight(element.Parent as AVLElement);
                    else
                        RemovedLeft(element.Parent as AVLElement);
                    break;
                case -2:
                    AVLElement subRoot;
                    if ((element.ChildLeft as AVLElement).BalanceFactor==1)
                    {
                        RotateLeft(element.ChildLeft.ChildRight);
                        
                        RotateRight(element.ChildLeft);
                        
                        subRoot = element.Parent as AVLElement;
                        
                        SetBalanceAfterDoubleRotation(subRoot);
                    }
                    else
                    {
                        RotateRight(element.ChildLeft);
                        
                        subRoot = element.Parent as AVLElement;
                        
                        if (subRoot.BalanceFactor == 0)
                        {
                            subRoot.BalanceFactor = 1;

                            element.BalanceFactor = -1;

                            return;
                        }

                        element.BalanceFactor = subRoot.BalanceFactor = 0;
                    }

                    if (subRoot == RootElement)
                        return;
                    
                    if (subRoot.Parent.ChildRight == subRoot)
                        RemovedRight(subRoot.Parent as AVLElement);
                    else
                        RemovedLeft(subRoot.Parent as AVLElement);
                    break;
            }
        }
        private void SetBalanceAfterDoubleRotation(AVLElement subRoot)
        {
            var right = (AVLElement)subRoot.ChildRight;
            
            var left = (AVLElement)subRoot.ChildLeft;

            switch (subRoot.BalanceFactor)
            {
                case -1:
                    left.BalanceFactor = 0;
                    right.BalanceFactor = 1;
                    break;
                case 1:
                    left.BalanceFactor = -1;
                    right.BalanceFactor = 0;
                    break;
                case 0:
                    left.BalanceFactor = right.BalanceFactor = 0;
                    break;
            }

            subRoot.BalanceFactor = 0;
        }
    }
}
