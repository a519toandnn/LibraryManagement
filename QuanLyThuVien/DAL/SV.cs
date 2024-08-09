using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL.Entities
{
    public class SV
    {
        public SV()
        {
            this.BorrowRecords = new HashSet<BorrowRecord>();
        }
        [Key]
        [Required]
        public string MSSV { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BorrowRecord> BorrowRecords { get; set; }
    }
}
