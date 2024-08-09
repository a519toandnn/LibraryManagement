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
    public class SV_BLL
    {
        private static SV_BLL _Instance;
        public static SV_BLL Instance
        {
            get 
            {
                if (_Instance == null)
                {
                    _Instance = new SV_BLL();
                }
                return _Instance;
            }
            private set { }
        }

        public List<CBBItem> getSV()
        {
            List<CBBItem> sv = new List<CBBItem>();
            sv = SV_DAL.Instance.getSV().Select(p => new CBBItem(p.MSSV, p.Name)).ToList();
            return sv;
        }

    }
}
