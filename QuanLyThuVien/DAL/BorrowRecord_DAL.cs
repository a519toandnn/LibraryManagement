using QuanLyThuVien.BLL;
using QuanLyThuVien.DAL;
using QuanLyThuVien.DAL.Context;
using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuanLyThuVien.BLL.SV_BLL;

namespace QuanLyThuVien.DAL.Repository
{
    public class BorrowRecord_DAL
    {
        private DBQLTV db;
        private static BorrowRecord_DAL _Instance;
        public static BorrowRecord_DAL Instance
        {
            get 
            {
                if (_Instance == null)
                {
                    _Instance = new BorrowRecord_DAL();
                }
                return _Instance;
            }
            private set { }
        }
        public BorrowRecord_DAL()
        {
            db = new DBQLTV();
        }

        public List<CBBItem> getBook()
        {
            try
            {
                var books = db.BorrowRecords.Select(p => new { Id_Book = p.Book.Id_Book, Title = p.Book.Title }).ToList();
                return books.GroupBy(b => b.Id_Book)
                            .Select(g => g.First())
                            .Select(b => new CBBItem(b.Id_Book, b.Title))
                            .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
        public List<BorrowRecord_View> getBorrowRecords()
        {
            try
            {
                return db.BorrowRecords.Select(p => new BorrowRecord_View
                {
                    MSSV = p.MSSV,
                    Name = p.SV.Name,
                    Title = p.Book.Title,
                    BorrowRecordID = p.BorrowRecordID,
                    BorrowDate = p.BorrowDate,
                    IsReturn = p.IsReturn
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
        public List<BorrowRecord_View> getBorrowRecordsCondition(string ID_Book)
        {
            try
            {
                return db.BorrowRecords.Where(p => p.Id_Book == ID_Book).Select(p => new BorrowRecord_View
                {
                    MSSV = p.MSSV,
                    Name = p.SV.Name,
                    Title = p.Book.Title,
                    BorrowRecordID = p.BorrowRecordID,
                    BorrowDate = p.BorrowDate,
                    IsReturn = p.IsReturn
                }).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
        public List<BorrowRecord_View> searchBorrowRecords(string search)
        {
            try
            {
                return db.BorrowRecords.Where(p => p.MSSV.Contains(search) || p.SV.Name.Contains(search) || p.Book.Title.Contains(search) || p.BorrowRecordID.Contains(search)).Select(p => new BorrowRecord_View
                {
                    MSSV = p.MSSV,
                    Name = p.SV.Name,
                    Title = p.Book.Title,
                    BorrowRecordID = p.BorrowRecordID,
                    BorrowDate = p.BorrowDate,
                    IsReturn = p.IsReturn
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void delBorrowRecord(string borrow_id)
        {
            try
            {
                BorrowRecord br = db.BorrowRecords.Where(p => p.BorrowRecordID == borrow_id).FirstOrDefault();
                if (br != null)
                {
                    db.BorrowRecords.Remove(br);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
        public void Update(BorrowRecord record)
        {
            BorrowRecord br = db.BorrowRecords.Where(p => p.BorrowRecordID == record.BorrowRecordID).FirstOrDefault();
            if (br != null)
            {
                DialogResult result = MessageBox.Show("This Record ID is already exist! Do you want to update it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }
                try
                {
                    br.MSSV = record.MSSV;
                    br.Id_Book = record.Id_Book;
                    br.BorrowDate = record.BorrowDate;
                    br.IsReturn = record.IsReturn;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    db.BorrowRecords.Add(record);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
        }
    }
}
