using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SeedData : DropCreateDatabaseIfModelChanges<Model1>
    {
        protected override void Seed(Model1 context)
        {
            context.MonAns.AddRange(new MonAn[]
            {
                new MonAn{ IdMonAn = 1, Ten = "Kim Chi"},
                new MonAn{ IdMonAn = 2, Ten = "Thit heo"},
                new MonAn{ IdMonAn = 3, Ten = "Cha Ca" },
                new MonAn{ Ten = "Com Suon"},
            });
            context.NguyenLieus.AddRange(new NguyenLieu[] {
                new NguyenLieu { IdNguyenLieu = 1 , Ten = "Muoi", TinhTrang= false  },
                new NguyenLieu { IdNguyenLieu = 2 , Ten = "Hat Tieu", TinhTrang= false },
                new NguyenLieu { Ten = "Duong", TinhTrang= false},
            });
            context.MonAn_NguyenLieus.AddRange(new MonAn_NguyenLieu[] {
                new MonAn_NguyenLieu { Id = "00001", SoLuong = 100, IdNguyenLieu = 1, IdMonAn = 2, DonViTinh = "Rau"  },
                new MonAn_NguyenLieu { Id = "00002", SoLuong = 100, IdNguyenLieu = 2, IdMonAn = 2, DonViTinh = "Bo"  },
                new MonAn_NguyenLieu { Id = "00003", SoLuong = 100, IdNguyenLieu = 3, IdMonAn = 2, DonViTinh = "Cai"  },
            });
        }

    }
}
