using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL.Entities
{
    public class BorrowRecord
    {
        [Key]
        [Required]
        public string BorrowRecordID { get; set; }
        public DateTime BorrowDate { get; set; }
        public string IsReturn { get; set; }

        
        public string MSSV { get; set; }
        [ForeignKey("MSSV")]
        public virtual SV SV { get; set; }

        
        public string Id_Book { get; set; }
        [ForeignKey("Id_Book")]
        public virtual Book Book { get; set; }
    }
}
