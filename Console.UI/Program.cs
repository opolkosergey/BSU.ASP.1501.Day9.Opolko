using System;
using System.Collections.Generic;
using static System.Console;
using BinaryTree.Generic;

namespace Console.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region int with length comparer
            var btc = new BinaryTree<int>(new LengthIntComparer());
            btc.AddValue(566666);
            btc.AddValue(56666633);
            btc.AddValue(63);
            btc.AddValue(6222);
            PrintTree(btc.GetRoot(), 0);
            WriteLine("________________________________________");
            #endregion

            #region int with default comparer
            var bti = new BinaryTree<int>();
            bti.AddValue(6);
            bti.AddValue(5);
            bti.AddValue(0);
            bti.AddValue(2);
            bti.AddValue(111);
            PrintTree(bti.GetRoot(), 0);
            WriteLine("________________________________________");
            #endregion

            #region string with default comparer
            var bts = new BinaryTree<string>();
            bts.AddValue("qwe");
            bts.AddValue("rty");
            bts.AddValue("zxc");
            bts.AddValue("bnm");
            bts.AddValue("iop");
            PrintTree(bts.GetRoot(),0);
            WriteLine("________________________________________");
            #endregion

            #region string with length comparer
            var btsc = new BinaryTree<string>(new LengthStringComparer());
            btsc.AddValue("qwerr");
            btsc.AddValue("rtyw");
            btsc.AddValue("zxc");
            btsc.AddValue("bnmuuuuu");
            btsc.AddValue("i");
            PrintTree(btsc.GetRoot(), 0);
            WriteLine("________________________________________");
            #endregion

            #region book with default comparer
            var btb = new BinaryTree<Book>();
            btb.AddValue(new Book("J. Richter", "C# via", 500.0, 800));
            btb.AddValue(new Book("D. Samal", "Sifo VMSIS", 350.0, 85));
            btb.AddValue(new Book("A. Pushkin", "E.Onegin", 110.0, 150));
            btb.AddValue(new Book("L. Tolstoi", "Voina i mir", 650.0, 1000));
            btb.AddValue(new Book("S. Perro", "Kot v sapogah", 60.0, 50));
            PrintTree(btb.GetRoot(),0);
            WriteLine("________________________________________");
            #endregion

            #region book with length title comparer
            var btblc = new BinaryTree<Book>(new LengthBookTitleComparer());
            btblc.AddValue(new Book("J. Richter", "C# via", 500.0, 800));
            btblc.AddValue(new Book("D. Samal", "Sifo VMSIS", 350.0, 85));
            btblc.AddValue(new Book("A. Pushkin", "E.Onegin", 110.0, 150));
            btblc.AddValue(new Book("L. Tolstoi", "Voina i mir", 650.0, 1000));
            btblc.AddValue(new Book("S. Perro", "Kot v sapogah", 60.0, 50));
            PrintTree(btblc.GetRoot(), 0);
            WriteLine("________________________________________");
            #endregion

            #region point with comparer
            var btpc = new BinaryTree<Point>(new PointComparer());
            btpc.AddValue(new Point(5,6));
            btpc.AddValue(new Point(88,6));
            btpc.AddValue(new Point(6,6));
            btpc.AddValue(new Point(123,90));
            btpc.AddValue(new Point(3,90));
            btpc.AddValue(new Point(0,90));
            PrintTree(btpc.GetRoot(), 0);
            WriteLine("________________________________________");
            #endregion

            #region point postorder
            foreach (var b in btpc.Postorder())
            {
                WriteLine(b);
            }
            WriteLine("________________________________________");
            #endregion

            #region point preorder
            foreach (var b in btpc.Preorder())
            {
                WriteLine(b);
            }
            WriteLine("________________________________________");
            #endregion

            #region point inorder

            foreach (var b in btpc.Inorder())
            {
                WriteLine(b);
            }
            WriteLine("________________________________________");
            #endregion
        }

        private static void PrintTree<T>(BinaryTree<T>.BinaryTreeNode<T> node, int level)
        {
            if (node == null) return;
            PrintTree(node.Right, level + 1);
            for (var i = 0; i < level; i++) Write("            ");
            {
                Write(node.Value.ToString());
                WriteLine("\n");
            }
            PrintTree(node.Left, level + 1);
        }
    }
}
