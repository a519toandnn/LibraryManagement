using QuanLyThuVien.DAL.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace QuanLyThuVien.DAL.Context
{
    public class DBQLTV : DbContext
    {
        // Your context has been configured to use a 'DBQLTV' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'QuanLyThuVien.DAL.Context.DBQLTV' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DBQLTV' 
        // connection string in the application configuration file.
        public DBQLTV()
            : base("name=DBQLTV")
        {
            Database.SetInitializer<DBQLTV>(new CreateDB());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<SV> SVs { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BorrowRecord> BorrowRecords { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}