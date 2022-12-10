namespace QuanLyNhanVien.Models
{
    public class PhanCong
    {
        public int Id { get; set; }
        public int IdNhanVien { get; set; }
        public int SoDA { get; set; }
        public string ThoiGian { get; set; }
        public string HoTen { get; set; }
    }
}