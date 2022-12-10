
using System.Collections.Generic;
using QuanLyNhanVien.Models;


namespace QuanLyNhanVien.BLL
{
    public class DeAnBLL
    {
        private DAL _dal = new DAL();

        public List<DeAn> DeAns()
        {
            return _dal.DeAns.DeAns();
        }

        public int Add(DeAn DeAn)
        {
            return _dal.DeAns.Add(DeAn);
        }

        public int Update(DeAn DeAn)
        {
            return _dal.DeAns.Update(DeAn);
        }

        public int Delete(int id)
        {
            return _dal.DeAns.Delete(id);
        }
    }
}