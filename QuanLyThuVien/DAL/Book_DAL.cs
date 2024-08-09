using QuanLyThuVien.DAL;
using QuanLyThuVien.DAL.Context;
using QuanLyThuVien.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL.Repository
{
    public class Book_DAL
    {
        private DBQLTV db;
        private static Book_DAL _Instance;
        public static Book_DAL Instance
        {
            get 
            {
                if (_Instance == null)
                {
                    _Instance = new Book_DAL();
                }
                return _Instance;
            }
            private set { }
        }
        private Book_DAL()
        {
            db = new DBQLTV();
        }
        public List<Book> getBook()
        {
            try
            {
                return db.Books.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
