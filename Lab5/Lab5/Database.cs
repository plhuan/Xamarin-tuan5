using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Lab5
{
    class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        string DB_PATH = "bookstore.db";

        public bool CreateDatabase()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, DB_PATH);
                var conection = new SQLiteConnection(path);

                conection.CreateTable<Book>();
                conection.CreateTable<Cart>();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Book> GetBookList()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, DB_PATH);
                var connection = new SQLiteConnection(path);

                return connection.Table<Book>().ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<Book> GetOneBook(int bId)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, DB_PATH);
                var connection = new SQLiteConnection(path);

                return connection.Query<Book>("SELECT * FROM Book WHERE bId=" + bId.ToString());
            }
            catch
            {
                return null;
            }
        }
        
        public bool CreateBook(Book book)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, DB_PATH);
                var connection = new SQLiteConnection(path);

                connection.Insert(book);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBook(Book book)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, DB_PATH);
                var connection = new SQLiteConnection(path);

                connection.Delete(book);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateBook(Book book)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, DB_PATH);
                var connection = new SQLiteConnection(path);

                connection.Update(book);

                return true;
            }
            catch
            {
                return false;
            }
        }

        // CART
        public List<Cart> GetCartList()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, DB_PATH);
                var connection = new SQLiteConnection(path);

                return connection.Table<Cart>().ToList();
            }
            catch
            {
                return null;
            }
        }
        public bool AddCart(Cart cart)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, DB_PATH);
                var connection = new SQLiteConnection(path);

                connection.Insert(cart);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
