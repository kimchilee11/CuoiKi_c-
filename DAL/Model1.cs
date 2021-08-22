using System;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
            Database.SetInitializer<Model1>(new SeedData());
        }
        public virtual DbSet<MonAn> MonAns { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieus { get; set; }
        public virtual DbSet<MonAn_NguyenLieu> MonAn_NguyenLieus { get; set; }

    }

}