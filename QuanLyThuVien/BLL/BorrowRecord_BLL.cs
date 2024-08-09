using QuanLyThuVien;
using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repository;
using QuanLyThuVien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuanLyThuVien.DAL.Repository.BorrowRecord_DAL;

namespace QuanLyThuVien.BLL
{
    public class BorrowRecord_BLL
    {
        public delegate bool Compare(object o1, object o2);
        private static BorrowRecord_BLL _Instance;
        public static BorrowRecord_BLL Instance
        {
            get 
            {
                if (_Instance == null)
                {
                    _Instance = new BorrowRecord_BLL();
                }
                return _Instance;
            }
            private set { }
        }

        public List<CBBItem> getBook()
        {
            List<CBBItem> book = new List<CBBItem>();
            book = BorrowRecord_DAL.Instance.getBook().ToList();
            return book;
        }

        public List<BorrowRecord_View> getBorrowRecords(string ID_Book)
        {
            List<BorrowRecord_View> borrowRecords = new List<BorrowRecord_View>();
            if (ID_Book == "0")
            {
                borrowRecords = BorrowRecord_DAL.Instance.getBorrowRecords();
            }
            else
            {
                borrowRecords = BorrowRecord_DAL.Instance.getBorrowRecordsCondition(ID_Book).ToList();
            }
            return borrowRecords;
        }
        public List<BorrowRecord_View> searchBorrowRecords(string search)
        {
            List<BorrowRecord_View> borrowRecords = new List<BorrowRecord_View>();
            if (search == "")
            {
                borrowRecords = BorrowRecord_DAL.Instance.getBorrowRecords();
            }
            else
            {
                borrowRecords = BorrowRecord_DAL.Instance.searchBorrowRecords(search).ToList();
            }
            return borrowRecords;
        }
        public List<BorrowRecord_View> Sort(string sort)
        {
            List<BorrowRecord_View> borrowrecords = new List<BorrowRecord_View>();
            borrowrecords = BorrowRecord_DAL.Instance.getBorrowRecords().ToList();
            Compare compare = null;
            switch (sort)
            {
                case "MSSV":
                {
                    compare = BorrowRecord_View.CompareMSSV;
                    break;
                }
                case "Name":
                {
                    compare = BorrowRecord_View.CompareName;
                    break;
                }
                case "Title":
                {
                    compare = BorrowRecord_View.CompareTitle;
                    break;
                }
                case "BorrowRecordID":
                {
                    compare = BorrowRecord_View.CompareBorrowRecordID;  
                    break;
                }
            }
            for (int i = 0; i < borrowrecords.Count - 1; i++)
            {
                for (int j = i + 1; j < borrowrecords.Count; j++)
                {
                    if (compare != null && compare(borrowrecords[i], borrowrecords[j]))
                    {
                        BorrowRecord_View temp = borrowrecords[i];
                        borrowrecords[i] = borrowrecords[j];
                        borrowrecords[j] = temp;
                    }
                }
            }
            return borrowrecords;
        }

        public void delBorrowRecord(string borrow_id)
        {
            BorrowRecord_DAL.Instance.delBorrowRecord(borrow_id);
        }
        
        public void Update(BorrowRecord record)
        {
            BorrowRecord_DAL.Instance.Update(record);
        }
    }
}
