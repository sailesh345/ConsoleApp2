using System;
using System.Collections.Generic;
using System.Text;
using BookStore;
namespace BookStore
{
    class Book
    {
        readonly string BookTitle;
        readonly double BookCost;
        int BookStock;
        public Book()
        {
            Console.WriteLine("enter the title , cost and stock");
            BookTitle = Console.ReadLine();
            BookCost = int.Parse(Console.ReadLine());
            BookStock = int.Parse(Console.ReadLine());
        }
        public void DispBookDetails()
        {
            Console.WriteLine("Title:" + BookTitle);
            Console.WriteLine("Cost:" + BookCost);
            Console.WriteLine("Stock:" + BookStock);
            Console.WriteLine("-----------------------------------");
        }
        private void UpdateStock(Book b, int stock)
        {
            b.BookStock += stock;
        }
        private void Purchase(Book r, int stock)
        {
            char ch;
            Console.WriteLine("Billing Cost:" + (r.BookCost * stock));
            Console.WriteLine("enter y to purchase");
            ch = char.Parse(Console.ReadLine());
            if (ch == 'y')
                UpdateStock(r, -1 * stock);
        }
        private bool SearchForBook(string title, int stock)
        {
            bool status = false;
            if (BookTitle.Equals(title))
            {
                status = true;
                if (stock <= BookStock)
                {
                    Console.WriteLine("Book available with sufficient stock");
                    Purchase(this, stock);

                }
                else
                    Console.WriteLine("Book available but stock is insufficient");
            }
            return status;
        }
        public static void Search(Book[] books)
        {
            string title;
            int stock;
            for (int i = 0; i < 3; i++)
            {
                title = Console.ReadLine();
                stock = int.Parse(Console.ReadLine());

                if (books[0] != null && books[0].SearchForBook(title, stock))
                    continue;

                else if (books[1] != null && books[1].SearchForBook(title, stock))
                    continue;

                else if (books[2] != null && books[2].SearchForBook(title, stock))
                    continue;

                else
                    Console.WriteLine("Book not available");
            }
        }
    }
}
namespace Client
{ 
    public class BookStoreAppl_1_4
    {
        public static void Main()
        {
            Book[] books = new Book[3];
            books[0] = new Book();
            books[1] = new Book();
            books[2] = new Book();

            foreach (Book b in books)
                b.DispBookDetails();

            Book.Search(books);
        }
    }
}