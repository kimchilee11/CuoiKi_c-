using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_QLMA
    {

        private static BLL_QLMA _Instance;
        public static BLL_QLMA Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_QLMA();
                }
                return _Instance;
            }
            set { }
        }
        public void DeleteRecord_MANL(String id)
        {
            DAL_QLMA.Instance.DeleteRecord(id);
        }
        public List<MonAn_NguyenLieu> GetNLMonAn(String monan)
        {
            return DAL_QLMA.Instance.GetNguyenLieusByNameMonAn(monan);
        }
        public void EditNLMonAn(MonAn_NguyenLieu item , String id)
        {
            DAL_QLMA.Instance.EditRecord(item, id);
        }
        public MonAn_NguyenLieu GetNguyenLieuMA_ByID(String id)
        {
            return DAL_QLMA.Instance.GetNguyenLieuMA_ByID(id);
        }
        public int GetMonAnByName(String name)
        {
            return DAL_QLMA.Instance.GetMonAnByName(name).IdMonAn;
        }
        public void InsertRecord(MonAn_NguyenLieu comp)
        {
            DAL_QLMA.Instance.InsertRecord(comp);
        }
        public List<MonAn_NguyenLieu> Sort(String name, int status = 1)
        {
            return DAL_QLMA.Instance.Sort(name, status);
        }
        public List<MonAn_NguyenLieu> SearchRecords(String name, String ma)
        {
            return DAL_QLMA.Instance.SearchRecords(name, ma);
        }
        public MonAn[] GetAllMonAn()
        {
            return DAL_QLMA.Instance.GetAllMonAn();
        }
        public NguyenLieu[] GetAllNL()
        {
            return DAL_QLMA.Instance.GetAllNL();
        }
    }
}
