﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("NguyenLieu")]
    public class NguyenLieu
    {
        public NguyenLieu()
        {
            MonAn_NguyenLieus = new HashSet<MonAn_NguyenLieu>();
        }
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNguyenLieu { get; set; }
        public String Ten { get; set; }
        public bool TinhTrang { get; set; }
        public virtual ICollection<MonAn_NguyenLieu> MonAn_NguyenLieus { get; set; }
        public override string ToString()
        {
            return Ten;
        }
    }
}
