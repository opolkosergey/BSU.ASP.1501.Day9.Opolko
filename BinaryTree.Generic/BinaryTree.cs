using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Generic
{
    public class BinaryTree<T>
    {
        public sealed class DefaultComparerException : Exception
        { public DefaultComparerException(string message) : base(message) { } }
        public class BinaryTreeNode<T>
        {
            public T Value;
            public BinaryTreeNode<T> Left;
            public BinaryTreeNode<T> Right;

            public BinaryTreeNode(T value)
            {
                Value = value;
            }
        }
        public IComparer<T> Comparer { get; set; }

        private BinaryTreeNode<T> _root;
        public BinaryTree() : this(Comparer<T>.Default) { }
        public BinaryTree(IComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException();
            Comparer = comparer;
        }
        public BinaryTreeNode<T> GetRoot() => _root;
        public void AddValue(T value)
        {
            if (value == null)
                throw new ArgumentException();
            if (_root == null)
            {
                _root = new BinaryTreeNode<T>(value);
                return;
            }
            if (!Contains(value))
                AddNode(ref _root, value);
        }
        public bool Contains(T value) => FindNode(_root, value) != null;
        public IEnumerable<T> Inorder() => Inorder(_root);
        public IEnumerable<T> Preorder() => Preorder(_root);
        public IEnumerable<T> Postorder() => Postorder(_root);
        private void AddNode(ref BinaryTreeNode<T> root, T value)
        {
            try
            {
                if (root == null)
                {
                    root = new BinaryTreeNode<T>(value);
                    return;
                }

                if (Comparer.Compare(root.Value, value) > 0) AddNode(ref root.Left, value);

                if (Comparer.Compare(root.Value, value) < 0) AddNode(ref root.Right, value);
            }
            catch (ArgumentException)
            {
                throw new DefaultComparerException("Invavid default comparer" + nameof(Comparer));
            }
        }
        private BinaryTreeNode<T> FindNode(BinaryTreeNode<T> root, T value)
        {
            try
            {
                if (root != null)
                {
                    if (Comparer.Compare(root.Value, value) == 0)
                        return root;
                    if (Comparer.Compare(root.Value, value) > 0)
                        return FindNode(root.Left, value);
                    if (Comparer.Compare(root.Value, value) < 0)
                        return FindNode(root.Right, value);
                }
            }
            catch (ArgumentException)
            {
                throw new DefaultComparerException("Invavid default comparer" + nameof(Comparer));
            }
            return null;
        }
        private IEnumerable<T> Inorder(BinaryTreeNode<T> node)
        {
            if (node == null)
                yield break;
            foreach (var n in Inorder(node.Left))
                yield return n;

            yield return node.Value;
            foreach (var n in Inorder(node.Right))
                yield return n;
        }
        private IEnumerable<T> Preorder(BinaryTreeNode<T> node)
        {
            if (node == null)
                yield break;
            yield return node.Value;

            foreach (var n in Preorder(node.Left))
                yield return n;

            foreach (var n in Preorder(node.Right))
                yield return n;
        }
        private IEnumerable<T> Postorder(BinaryTreeNode<T> node)
        {
            if (node == null)
                yield break;

            foreach (var n in Postorder(node.Left))
                yield return n;

            foreach (var n in Postorder(node.Right))
                yield return n;
            yield return node.Value;
        }
    }
}
