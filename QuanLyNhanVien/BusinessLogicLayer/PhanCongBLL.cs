using System.Collections.Generic;
using QuanLyNhanVien;
using QuanLyNhanVien.Models;

namespace QuanLyNhanVien.BLL
{
    public class PhanCongBLL
    {
        private DAL _dal = new DAL();

        public List<PhanCong> PhanCongs()
        {
            return _dal.PhanCongs.PhanCongs();
        }

        public int Add(PhanCong phanCong)
        {
            return _dal.PhanCongs.Add(phanCong);
        }

        public int Update(PhanCong phanCong)
        {
            return _dal.PhanCongs.Update(phanCong);
        }

        public int Delete(int id)
        {
            return _dal.PhanCongs.Delete(id);
        }
    }
}