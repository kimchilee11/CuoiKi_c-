using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("MonAn_NguyenLieu")]
    public class MonAn_NguyenLieu
    {
        [Key]
        public String Id { get; set; }
        public int SoLuong { get; set; }
        public String DonViTinh { get; set; }
        [Browsable(false)]
        public Nullable<int> IdMonAn { get; set; }
        [Browsable(false)]
        public Nullable<int> IdNguyenLieu { get; set; }

        [ForeignKey("IdMonAn")]
        public virtual MonAn MonAn { get; set; }
        [ForeignKey("IdNguyenLieu")]
        public virtual NguyenLieu NguyenLieu { get; set; }
    }
}
