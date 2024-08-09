using QuanLyThuVien.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.DAL.Context
{
    public class CreateDB : CreateDatabaseIfNotExists<DBQLTV>
    {
        protected override void Seed(DBQLTV db)
        {
            db.SVs.AddRange(new SV[]
            {
                new SV { MSSV = "1001", Name = "NVA"},
                new SV { MSSV = "1002", Name = "NVB"},
                new SV { MSSV = "1003", Name = "NVC"},
                new SV { MSSV = "1004", Name = "NVD"}
            });
            db.Books.AddRange(new Book[]
            {
                new Book { Id_Book = "Book_1" ,Title = "C# Programming" },
                new Book { Id_Book = "Book_2" ,Title = "Database Systems"},
                new Book { Id_Book = "Book_3" ,Title = "Algorithms"},
                new Book { Id_Book = "Book_300", Title = "300 Bai code thieu nhi"},
                new Book { Id_Book = "Book_4" ,Title = "Java Programming"},
                new Book { Id_Book = "Book_5" ,Title = "Python Programming"},
                new Book { Id_Book = "Book_6" ,Title = "C++ Programming"},
                new Book { Id_Book = "Book_7" ,Title = "C# Programming"},
            });
            db.BorrowRecords.AddRange(new BorrowRecord[]
            {
                new BorrowRecord { BorrowRecordID = "Borrow_01", BorrowDate = DateTime.Now, MSSV = "1001", Id_Book = "Book_1", IsReturn = "Yes" },
                new BorrowRecord { BorrowRecordID = "Borrow_02", BorrowDate = DateTime.Now, MSSV = "1002", Id_Book = "Book_2", IsReturn = "No" },
                new BorrowRecord { BorrowRecordID = "Borrow_03", BorrowDate = DateTime.Now, MSSV = "1003", Id_Book = "Book_3", IsReturn = "Yes" },
                new BorrowRecord { BorrowRecordID = "Borrow_04", BorrowDate = DateTime.Now, MSSV = "1001", Id_Book = "Book_300", IsReturn = "No" },
                new BorrowRecord { BorrowRecordID = "Borrow_05", BorrowDate = DateTime.Now, MSSV = "1002", Id_Book = "Book_4", IsReturn = "Yes" },
                new BorrowRecord { BorrowRecordID = "Borrow_06", BorrowDate = DateTime.Now, MSSV = "1003", Id_Book = "Book_5", IsReturn = "No" },
                new BorrowRecord { BorrowRecordID = "Borrow_07", BorrowDate = DateTime.Now, MSSV = "1004", Id_Book = "Book_6", IsReturn = "Yes" },
                new BorrowRecord { BorrowRecordID = "Borrow_08", BorrowDate = DateTime.Now, MSSV = "1002", Id_Book = "Book_7", IsReturn = "No" },
                new BorrowRecord { BorrowRecordID = "Borrow_09", BorrowDate = DateTime.Now, MSSV = "1003", Id_Book = "Book_1", IsReturn = "No" },
                new BorrowRecord { BorrowRecordID = "Borrow_10", BorrowDate = DateTime.Now, MSSV = "1004", Id_Book = "Book_2", IsReturn = "Yes" },
                new BorrowRecord { BorrowRecordID = "Borrow_11", BorrowDate = DateTime.Now, MSSV = "1001", Id_Book = "Book_3", IsReturn = "No" },
                new BorrowRecord { BorrowRecordID = "Borrow_12", BorrowDate = DateTime.Now, MSSV = "1002", Id_Book = "Book_300", IsReturn = "Yes" }
            });
        }
    }
}
