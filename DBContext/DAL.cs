
using QuanLyNhanVien.DBContext;

namespace QuanLyNhanVien
{
    public class DAL
    {
        public DeAnDAL DeAns;
        public DiaDiemDAL DiaDiems;
        public NhanVienDAL NhanViens;
        public PhanCongDAL PhanCongs;
        public PhongBanDAL PhongBans;

        public DAL()
        {
            DeAns = new DeAnDAL();
            DiaDiems = new DiaDiemDAL();
            NhanViens = new NhanVienDAL();
            PhanCongs = new PhanCongDAL();
            PhongBans = new PhongBanDAL();
        }
    }
}