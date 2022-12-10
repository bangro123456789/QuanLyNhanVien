using System.Collections.Generic;
using QuanLyNhanVien.Models;

namespace QuanLyNhanVien.BLL
{
    public class NhanVienBLL
    {
        private DAL _dal = new DAL();

        public List<NhanVien> NhanViens()
        {
            return _dal.NhanViens.NhanViens();
        }

        public int Add(NhanVien nhanVien)
        {
            return _dal.NhanViens.Add(nhanVien);
        }

        public int Update(NhanVien nhanVien)
        {
            return _dal.NhanViens.Update(nhanVien);
        }

        public int Delete(int id)
        {
            return _dal.NhanViens.Delete(id);
        }
    }
}