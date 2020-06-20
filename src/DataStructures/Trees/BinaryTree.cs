﻿using DataStructures.Arrays;

namespace DataStructures.Trees
{
    public class BinaryTree<T>
    {
        public BinaryTree(T rootNodeValue)
        {
            RootNode = new BinaryTreeNode<T>(rootNodeValue);
        }

        public BinaryTreeNode<T> RootNode { get; }

        /// <summary>
        /// Given a binary tree, return its nodes according to the "bottom-up" postorder traversal. From the deep to root
        /// aka Topological search
        /// Usings: deleting tree; creating sequence of dependencies (to resolve all of them in right order)
        /// </summary>
        public static T[] TraverseTreePostorder(BinaryTreeNode<T> node)
        {
            var elementsList = new ArrayList<T>();

            if (node != null)
            {
                elementsList.AddRange(TraverseTreePostorder(node.Left));
                elementsList.AddRange(TraverseTreePostorder(node.Right));
                elementsList.Add(node.Value);
            }

            return elementsList.ToArray();
        }

        /// <summary>
        /// Given a binary tree, return its nodes in inorder
        /// Usings: get sorted sequence in Binary Search Tree
        /// </summary>
        public static T[] TraverseTreeInorder(BinaryTreeNode<T> node)
        {
            var elementsList = new ArrayList<T>();

            if (node != null)
            {
                elementsList.AddRange(TraverseTreeInorder(node.Left));
                elementsList.Add(node.Value);
                elementsList.AddRange(TraverseTreeInorder(node.Right));                
            }

            return elementsList.ToArray();
        }

        /// <summary>
        /// Given a binary tree, return its nodes in preorder
        /// Usings: copy of the tree
        /// </summary>
        public static T[] TraverseTreePreorder(BinaryTreeNode<T> node)
        {
            var elementsList = new ArrayList<T>();

            if (node != null)
            {
                elementsList.Add(node.Value);
                elementsList.AddRange(TraverseTreePreorder(node.Left));                
                elementsList.AddRange(TraverseTreePreorder(node.Right));
            }

            return elementsList.ToArray();
        }

        /// <summary>
        /// Given a binary tree, return its nodes in level order (traversal in width)
        /// Usings: finding a shortest path
        /// </summary>
        public static T[] TraverseTreeLevelOrder(BinaryTreeNode<T> node)
        {
            var elementsList = new ArrayList<T>();

            var queue = new Queue<BinaryTreeNode<T>>();
            var currentNode = node;
            while(currentNode != null)
            {
                elementsList.Add(currentNode.Value);
                if (currentNode.Left != null)queue.Enqueue(currentNode.Left);
                if (currentNode.Right != null) queue.Enqueue(currentNode.Right);

                currentNode = queue.Count() != 0 ? queue.Dequeue() : null;
            }

            return elementsList.ToArray();
        }
    }

    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T nodeValue)
        {
            Value = nodeValue;
        }

        public T Value { get; }

        public BinaryTreeNode<T> Left { get; private set; }

        public BinaryTreeNode<T> Right { get; private set; }

        public void SetLeftNode(T nodeValue)
        {
            Left = new BinaryTreeNode<T>(nodeValue);
        }

        public void SetRightNode(T nodeValue)
        {
            Right = new BinaryTreeNode<T>(nodeValue);
        }

        public bool IsLeaf()
        {
            return Left == null && Right == null;
        }
    }
}
