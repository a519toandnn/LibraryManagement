using QuanLyThuVien;
using QuanLyThuVien.DAL.Repository;
using QuanLyThuVien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL
{
    public class Book_BLL
    {
        private static Book_BLL _Instance;
        public static Book_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Book_BLL();
                }
                return _Instance;
            }
            private set { }
        }

        public List<CBBItem> getBook()
        {
            List<CBBItem> book = new List<CBBItem>();
            book = Book_DAL.Instance.getBook().Select(p => new CBBItem(p.Id_Book, p.Title)).ToList();
            return book;
        }
    }
}
