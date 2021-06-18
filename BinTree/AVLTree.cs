using System;
using static Praktikum.BinTree.TreeElement;

namespace Praktikum.BinTree
{
    class AVLTree : BinSearchTree
    {
        private AVLTreeElement newRoot;
        public enum Direction
        {

            Left = -1,
            None = 0,
            Right = 1

        }


        public override bool Delete(int elem)
        {
            #region Recursive Delete
            /* AVLTreeElement parent = (AVLTreeElement)this.TraverseAndFind(elem);
                      if (parent == null)
                       {
                           return false;
                       }

                       bool removed = base.Delete(elem);
                       if (!removed)
                       {
                           return false;
                       }
                       else
                       {
                           while (parent != null)
                           {
                               int balance = this.getBalance(parent);
                               if (Math.Abs(balance) == 1)
                               {
                                   break;
                               }
                               else if (Math.Abs(balance) == 2)
                               {
                                   this.ReBalance(parent, balance);
                               }
                               parent = parent.Parent as AVLTreeElement;
                           }
                           return true;*/

            #endregion
        
              if (!Search(elem))
                 return false;
            RemoveAndReBalance();
            return true;
        }

    
        private void RemoveAndReBalance()
        {
            if (lastFoundElement.ChildLeft != null && lastFoundElement.ChildRight != null)
            {
                PrepareSymmetricPredecessor(GetSymmetricPreedecessor(lastFoundElement));
            }
           if (TryEradicate())
            RootElement = RootElement.ChildRight ?? RootElement.ChildLeft;
            DisposeCurrenBalance();

        }

        protected void DisposeCurrenBalance()
        {
            if (lastFoundElement.GetParentDirection() == Direction.Right)
            {
                RemoveCurrentAndRebalanceRight();
            }

            else
            {
                RemoveCurrentAndRebalanceLeft();
            }
            
        }
        protected bool TryEradicate()
        {
            if (lastFoundElement != RootElement)
            {
                return false;
            }
            Eradicate();
            return true;
        }

        private void Eradicate()
        {
            RootElement = RootElement.ChildRight ?? RootElement.ChildLeft;
        }

        protected void RemoveCurrentAndRebalanceLeft()
        {
            if (!(lastFoundElement.Parent is AVLTreeElement currentParent))
                return;

            currentParent.ChildLeft = lastFoundElement.ChildRight ?? lastFoundElement.ChildLeft;

            ShortestPathLeft(currentParent);
        }

        protected void RemoveCurrentAndRebalanceRight()
        {
            if (!(lastFoundElement.Parent is AVLTreeElement currentParent))
            {
                return;
            }
            currentParent.ChildRight = lastFoundElement.ChildRight ?? lastFoundElement.ChildLeft;
            ShortestPathRight(currentParent);
        }

        private TreeElement GetSymmetricPreedecessor(TreeElement element)
        {
            var symmetricPredecessor = element.ChildLeft;
            while (symmetricPredecessor.ChildRight != null)
            {
                symmetricPredecessor = symmetricPredecessor.ChildRight;
            }
            return symmetricPredecessor;
        }

        private void PrepareSymmetricPredecessor(TreeElement element)
        {
            lastFoundElement.Value = element.Value;
            lastFoundElement = element;    
        }






        /*   private void RemoveAndRebalance()
           {
               if (lastFoundElement.ChildLeft != null && lastFoundElement.ChildRight != null)
               { SystemmetricPredecessor(GetSymmetricPredecessor(lastFoundElement)); }

               if (lastFoundElement != RootElement) ;

               else
               {
                   RootElement = RootElement.ChildRight ?? RootElement.ChildLeft;
               }
               DisposeCurrentAndRebalance();


           }

           private void DisposeCurrentAndRebalance()
           {
                if (!(RootElement.Parent is AVLTreeElement currentParent))
                    return;

                  var parentDirection = RootElement.GetParentDirection();

                  if (parentDirection == Direction.Right)
                    currentParent.ChildRight = RootElement.ChildRight ?? RootElement.ChildLeft;
                  else
                    currentParent.ChildLeft = RootElement.ChildRight ?? RootElement.ChildLeft;

                  if (parentDirection == Direction.Right)
                     ShortestPathRight(currentParent);
                  else
                     ShortestPathLeft(currentParent);

               if (lastFoundElement.GetParentDirection() == Direction.Right)
               {
                   if (!(lastFoundElement.Parent is AVLTreeElement currentParent))
                       return;
                   currentParent.ChildRight = lastFoundElement.ChildRight ?? lastFoundElement.ChildLeft;
                   ShortestPathRight(currentParent);
               }
               else
               {
                   if (!(lastFoundElement.Parent is AVLTreeElement currentParent))
                       return;
                   currentParent.ChildLeft = lastFoundElement.ChildRight ?? lastFoundElement.ChildLeft;
                   ShortestPathLeft(currentParent);
               }
           }


           private TreeElement GetSymmetricPredecessor(TreeElement element)
           {
               var symmetricPredecessor = element.ChildLeft;
               while (symmetricPredecessor.ChildRight != null)
                   symmetricPredecessor = symmetricPredecessor.ChildRight;
               return symmetricPredecessor;
           }

           private void SystemmetricPredecessor(TreeElement element)
           {
               lastFoundElement.Value = element.Value;
               lastFoundElement = element;
           }
    */



        #region Einfügen
        public override bool Insert(int elem)

         { 
               if (Search(elem))
                   return false;

               AVLTreeElement add = new AVLTreeElement(lastFoundElement as AVLTreeElement, elem);

               if (RootElement == null)
                   RootElement = add;

               else
               {
                  // RootElement = RecursiveInsert(RootElement as AVLTreeElement, add);
                   if (add.Value > lastFoundElement.Value)
                       lastFoundElement.ChildRight = add;
                   else
                       lastFoundElement.ChildLeft = add;

                   lastFoundElement = add;
               }
                    LengthedPathParent(add);

               return true;
           }




            private void LengthedPathParent(AVLTreeElement element)
            {

                if (element == null || !(element.Parent is AVLTreeElement avlParent))
                    return;

                switch (element.GetParentDirection())
                {
                    case Direction.Left:
                        LengthedPathLeft(avlParent);
                        break;
                    case Direction.None:
                        break;
                    case Direction.Right:
                        LengthedPathRight(avlParent);
                        break;
                    default:
                        break;
                }

            }

            private void LengthedPathRight(AVLTreeElement element)
            {
                element.BalanceFactor++;

                switch (element.BalanceFactor)
                {
                    case 0:
                        return;
                    case 1:
                        LengthedPathParent(element);
                        break;
                    case 2:
                        BalancedRotateLeft(element);
                        break;
                }
            }

            private void LengthedPathLeft(AVLTreeElement element)
            {
                element.BalanceFactor--;

                switch (element.BalanceFactor)
                {
                    case 0:
                        return;
                    case -1:
                        LengthedPathParent(element);
                        break;
                    case -2:
                        BalancedRotateRight(element);
                        break;
                }
            }

            private void BalancedRotateLeft(AVLTreeElement element)
            {
                if (!(element.ChildRight is AVLTreeElement avlRight))
                    return;

                if (avlRight.BalanceFactor == -1)
                    DoubleRotationLeft(element);
                else
                    SingleRotationLeft(element);
            }

            private void BalancedRotateRight(TreeElement element)
            {
                if (!(element.ChildLeft is AVLTreeElement avlLeft))
                    return;

                if (avlLeft.BalanceFactor == 1)
                    DoubleRotationRight(element);
                else
                    SingleRotationRight(element);
            }

            private void SingleRotationRight(TreeElement rotateDown)
            {
                RotateRight(rotateDown);
                AVLTreeElement right = rotateDown as AVLTreeElement;
                newRoot = rotateDown.Parent as AVLTreeElement;

                if (newRoot.BalanceFactor == 0)
                {
                    right.BalanceFactor = -1;

                    newRoot.BalanceFactor = 1;
                }
                else
                {
                    right.BalanceFactor = newRoot.BalanceFactor = 0;
                }
            }

            private void SingleRotationLeft(TreeElement rotateDown)
            {
                RotateLeft(rotateDown);

                var left = rotateDown as AVLTreeElement;
                newRoot = rotateDown.Parent as AVLTreeElement;

                if (newRoot.BalanceFactor == 0)
                {
                    left.BalanceFactor = 1;

                    newRoot.BalanceFactor = -1;
                }
                else
                    left.BalanceFactor = newRoot.BalanceFactor = 0;
            }

            private void DoubleRotationRight(TreeElement element)
            {
                RotateLeft(element.ChildLeft);

                RotateRight(element);

                newRoot = (AVLTreeElement)element.Parent;

                RebalanceAfterDoubleRotation();


            }

            private void DoubleRotationLeft(TreeElement element)
            {
                RotateRight(element.ChildRight);

                RotateLeft(element);

                newRoot = (AVLTreeElement)element.Parent;

                RebalanceAfterDoubleRotation();
            }

            private void RebalanceAfterDoubleRotation()
            {
                var right = (AVLTreeElement)newRoot.ChildRight;
                var left = (AVLTreeElement)newRoot.ChildLeft;

                switch (newRoot.BalanceFactor)
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

                newRoot.BalanceFactor = 0;
            }

            private void ShortenedParentOf(AVLTreeElement element)
            {
                if (element == null || !(element.Parent is AVLTreeElement avlParent))
                    return;

                switch (element.GetParentDirection())
                {
                    case Direction.Left:
                        ShortestPathLeft(avlParent);
                        break;
                    case Direction.None:
                        return;
                    case Direction.Right:
                        ShortestPathRight(avlParent);
                        break;
                    default:
                        break;
                }
            }

            private void ShortestPathRight(AVLTreeElement element)
            {
                element.BalanceFactor--;

                switch (element.BalanceFactor)
                {
                    case -1:
                        return;
                    case 0:
                        ShortenedParentOf(element);
                        break;
                    case -2:
                        BalancedRotateRight(element);
                        ShortenedParentOf(newRoot);
                        break;

                }
            }

            private void ShortestPathLeft(AVLTreeElement element)
            {
                element.BalanceFactor++;

                switch (element.BalanceFactor)
                {
                    case 1:
                        return;
                    case 0:
                        ShortenedParentOf(element);
                        break;
                    case 2:
                        BalancedRotateLeft(element);
                        ShortenedParentOf(newRoot);
                        break;
                }
 }

         }
        #endregion

        #region RecursiveInsert
/*
        public override bool Insert(int element)
        {
            if (Search(element))
                return false;

            AVLTreeElement add = new AVLTreeElement(lastFoundElement as AVLTreeElement, element);
            if (RootElement == null)
                RootElement = add;

            else
            {

                if (add.Value > lastFoundElement.Value)
                    lastFoundElement.ChildRight = add;
                else
                    lastFoundElement.ChildLeft = add;

                lastFoundElement = add;

            }

            AVLTreeElement parent = add.Parent as AVLTreeElement;

            while (parent != null)
            {
                int balance = this.getBalance(parent);
                if (Math.Abs(balance) == 2)
                {
                    ReBalance(parent, balance);
                }
                parent = parent.Parent as AVLTreeElement;
            }

            return true;

        }

        protected void ReBalance(AVLTreeElement parent, int balance)
        {
            if (balance == 2)
            {
                int right = getBalance(parent.ChildRight as AVLTreeElement);
                if (right == 1 || right == 0)
                {
                    RotateLeft(parent);
                }
                else if (right == -1)
                {
                    RotateRight(parent.ChildRight);
                    RotateLeft(parent);
                }
            }
            else if (balance == -2)
            {
                int left = getBalance(parent.ChildLeft as AVLTreeElement);
                if (left == 1)
                {
                    RotateLeft(parent.ChildLeft);
                    RotateRight(parent);
                }

                else if (left == -1 || left == 0)
                {
                    RotateRight(parent);
                }
            }
        }

        protected int getBalance(AVLTreeElement root)
        {
            return this.GetHeight(root.ChildRight as AVLTreeElement) - this.GetHeight(root.ChildLeft as AVLTreeElement);
        }

        private int GetHeight(AVLTreeElement pathTree)
        {
            if (pathTree == null)
                return 0;

            if (pathTree.ChildLeft == null && pathTree.ChildRight == null)
                return 1;

            int leftHeight = GetHeight(pathTree.ChildLeft as AVLTreeElement);
            int rightHeight = GetHeight(pathTree.ChildRight as AVLTreeElement);

            if (leftHeight > rightHeight)
            {
                return leftHeight + 1;
            }
            else
            {
                return rightHeight + 1;
            }
        }*/
#endregion
        
    }



