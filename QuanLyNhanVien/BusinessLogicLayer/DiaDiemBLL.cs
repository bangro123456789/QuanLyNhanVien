using System.Collections.Generic;
using QuanLyNhanVien.DBContext;
using QuanLyNhanVien.Models;

namespace QuanLyNhanVien.BLL
{
    public class DiaDiemBLL
    {
        private DAL _dal = new DAL();

        public List<DiaDiem> DiaDiems()
        {
            return _dal.DiaDiems.DiaDiems();
        }

        public int Add(DiaDiem diaDiem)
        {
            return _dal.DiaDiems.Add(diaDiem);
        }

        public int Update(DiaDiem diaDiem)
        {
            return _dal.DiaDiems.Update(diaDiem);
        }

        public int Delete(int id)
        {
            return _dal.DiaDiems.Delete(id);
        }
    }
}