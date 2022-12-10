namespace QuanLyNhanVien.Models
{
    public class NhanVien
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public int Luong { get; set; }
        public int IdPhong { get; set; }
        public string TenPhong { get; set; }
    }
}