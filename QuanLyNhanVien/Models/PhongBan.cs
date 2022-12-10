namespace QuanLyNhanVien.Models
{
    public class PhongBan
    {
        public int Id { get; set; }
        public string TenPhong { get; set; }
        public string TruongPhong { get; set; }
        public string DiaDiem { get; set; }
        public int IdDiadiem { get; set; }
    }
}