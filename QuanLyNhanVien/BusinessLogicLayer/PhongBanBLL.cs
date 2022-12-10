using System.Collections.Generic;
using QuanLyNhanVien.Models;

namespace QuanLyNhanVien.BLL
{
    public class PhongBanBLL
    {
        private DAL _dal = new DAL();

        public List<PhongBan> PhongBans()
        {
            return _dal.PhongBans.PhongBans();
        }

        public int Add(PhongBan phongBan)
        {
            return _dal.PhongBans.Add(phongBan);
        }

        public int Update(PhongBan phongBan)
        {
            return _dal.PhongBans.Update(phongBan);
        }

        public int Delete(int id)
        {
            return _dal.PhongBans.Delete(id);
        }
    }
}