using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.UI
{
    public class LengthIntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            var xl = x.ToString();
            var yl = y.ToString();
            if (xl.Length == yl.Length) return 0;
            return (xl.Length > yl.Length) ? 1 : -1;
        }
    }

    public class LengthStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length == y.Length) return 0;
            return (x.Length > y.Length) ? 1 : -1;
        }
    }

    public class LengthBookTitleComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Title.Length == y.Title.Length) return 0;
            return (x.Title.Length > y.Title.Length) ? 1 : -1;
        }
    }

    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            if (x.X == y.X && x.Y == y.Y) return 0;
            return (Math.Pow(x.X, 2) + Math.Pow(x.Y, 2) > Math.Pow(y.X, 2) + Math.Pow(y.Y, 2)) ? 1 : -1;
        }
    }
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X}-{Y}";
        }
    }
    public class Book : IComparable<Book>
    {
        public Book(string author, string title, double price, int pages)
        {
            Author = author;
            Title = title;
            Price = price;
            Pages = pages;
        }

        public string Author { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Pages { get; set; }

        public int CompareTo(Book other)
        {
            if (other == null) return -1;
            return Pages.CompareTo(other.Pages);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Author + '\n');
            sb.Append(Title + '\n');
            sb.Append(Pages + '\n');
            return sb.ToString();
        }
    }
}
