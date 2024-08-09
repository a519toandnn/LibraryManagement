using QuanLyThuVien.DAL;
using QuanLyThuVien.DAL.Context;
using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL.Repository
{
    public class SV_DAL
    {
        private DBQLTV db;
        private static SV_DAL _Instance;
        public static SV_DAL Instance
        {
            get 
            {
                if (_Instance == null)
                {
                    _Instance = new SV_DAL();
                }
                return _Instance;
            }
            private set { }
        }
        public SV_DAL()
        {
            db = new DBQLTV();
        }
        public List<SV> getSV()
        {
            return db.SVs.ToList();
        }
    }
}
