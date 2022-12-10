using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanVien.Utils;

namespace QuanLyNhanVien.Models
{
    public class DiaDiem
    {
        private int id;
        private string diaDiem;

        public DiaDiem()
        {
        }

        public DiaDiem(int id, string diaDiem)
        {
            this.id = id;
            this.diaDiem = diaDiem;
        }
        [DisplayName("Id")]

        public int Id
        {
            get => id;
            set => id = value;
        }
        [DisplayName("DiaDiem")]
        public string DiaDiem1
        {
            get => diaDiem;
            set => diaDiem = value;
        }

      
    }
}