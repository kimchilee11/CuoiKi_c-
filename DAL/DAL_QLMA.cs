using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_QLMA
    {
        private static DAL_QLMA _Instance;
        public static DAL_QLMA Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_QLMA();
                }
                return _Instance;
            }
            set { }
        }
        public MonAn GetMonAnByName(String name)
        {
            Model1 db = new Model1();
            return db.MonAns.Where(s => s.Ten == name).Select(p => p).FirstOrDefault();
        }
        public MonAn[] GetAllMonAn()
        {
            Model1 db = new Model1();
            return db.MonAns.ToArray();
        }
        public NguyenLieu[] GetAllNL()
        {
            Model1 db = new Model1();
            return db.NguyenLieus.ToArray();
        }
        public List<MonAn_NguyenLieu> GetNguyenLieusByNameMonAn(String name)
        {
            Model1 db = new Model1();
            return db.MonAn_NguyenLieus.Where(s => s.MonAn.Ten == name).Select(p => p).ToList();
        }
        public List<MonAn_NguyenLieu> SearchRecords(String name, String ma )
        {
            Model1 db = new Model1();
            
            return db.MonAn_NguyenLieus.Where(s => s.NguyenLieu.Ten.ToLower().Contains(name.Trim().ToLower()) && s.MonAn.Ten == ma).ToList();
        }
        public List<MonAn_NguyenLieu> Sort(String name, int status)
        {
            Model1 db = new Model1();
            List<MonAn_NguyenLieu> list = null;
            if (status == 1)
            {
                list = db.MonAn_NguyenLieus.Where(s => s.MonAn.Ten.Equals(name)).Select(p => p).ToList().OrderBy(p => p.IdNguyenLieu).ToList();
            }
            if(status == 2) list = db.MonAn_NguyenLieus.Where(s => s.MonAn.Ten.Equals(name)).Select(p => p).ToList().OrderBy(p => p.SoLuong).ToList(); ;
            return list;
        }
        public MonAn_NguyenLieu  GetNguyenLieuMA_ByID(String id)
        {
            Model1 db = new Model1();
            return db.MonAn_NguyenLieus.Where(s => s.Id.Equals(id)).FirstOrDefault();
        }
        public void InsertRecord(MonAn_NguyenLieu comp)
        {
            try
            {
                Model1 db = new Model1();
                db.MonAn_NguyenLieus.Add(comp);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void DeleteRecord(string id )
        {
            try
            {
                Model1 db = new Model1();
                var item = db.MonAn_NguyenLieus.Where(s => s.Id == id).FirstOrDefault();
                if (item.NguyenLieu.TinhTrang == false) db.MonAn_NguyenLieus.Remove(item);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void EditRecord(MonAn_NguyenLieu comp, String Id)
        {
            try
            {
                Model1 db = new Model1();
                MonAn_NguyenLieu c2 = db.MonAn_NguyenLieus.Find(Id);
                c2.DonViTinh = comp.DonViTinh;
                c2.IdNguyenLieu = comp.IdNguyenLieu;
                c2.SoLuong = comp.SoLuong;
                
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        
    }
}
