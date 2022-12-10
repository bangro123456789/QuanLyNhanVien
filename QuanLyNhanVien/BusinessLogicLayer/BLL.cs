namespace QuanLyNhanVien.BLL
{
    public class BLL
    {
        public DeAnBLL DeAns;
        public DiaDiemBLL DiaDiems;
        public NhanVienBLL NhanViens;
        public PhanCongBLL PhanCongs;
        public PhongBanBLL PhongBans;

        public BLL()
        {
            DeAns = new DeAnBLL();
            DiaDiems = new DiaDiemBLL();
            NhanViens = new NhanVienBLL();
            PhanCongs = new PhanCongBLL();
            PhongBans = new PhongBanBLL();
        }
    }
}