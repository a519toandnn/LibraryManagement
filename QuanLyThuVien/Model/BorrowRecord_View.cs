using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Model
{
    public class BorrowRecord_View
    {

        public string MSSV { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string BorrowRecordID { get; set; }
        public DateTime BorrowDate { get; set; }
        public string IsReturn { get; set; }

        public static bool CompareMSSV(object o1, object o2)
        {
            return (o1 as BorrowRecord_View).MSSV.CompareTo((o2 as BorrowRecord_View).MSSV) > 0;
        }
        public static bool CompareName(object o1, object o2)
        {
            return (o1 as BorrowRecord_View).Name.CompareTo((o2 as BorrowRecord_View).Name) > 0;
        }
        public static bool CompareTitle(object o1, object o2)
        {
            return (o1 as BorrowRecord_View).Title.CompareTo((o2 as BorrowRecord_View).Title) > 0;
        }
        public static bool CompareBorrowRecordID(object o1, object o2)
        {
            return  ((o1 as BorrowRecord_View).BorrowRecordID.CompareTo((o2 as BorrowRecord_View).BorrowRecordID)) > 0;
        }
    }
}
