using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL.Entities
{
    public class Book
    {
        public Book()
        {
            this.BorrowRecords = new HashSet<BorrowRecord>();
        }
        [Key]
        [Required]
        public string Id_Book { get; set; }
        public string Title { get; set; }
        public virtual ICollection<BorrowRecord> BorrowRecords { get; set; }
    }
}
