using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanVien.Models;
using QuanLyNhanVien.Utils;

namespace QuanLyNhanVien.DBContext
{
    public class PhongBanDAL
    {
        public List<PhongBan> PhongBans()
        {
            List<PhongBan> PhongBanList = new List<PhongBan>();
            string sql = "GetPhongBan";
            Provider provider = new Provider();
            DataTable dt = provider.Select(CommandType.StoredProcedure, sql);
            foreach (DataRow row in dt.Rows)
            {
                PhongBanList.Add(new PhongBan()
                {
                    DiaDiem = row["DiaDiem"].ToString(),
                    Id = int.Parse(row["Id"].ToString()),
                    IdDiadiem = int.Parse(row["IdDiaDiem"].ToString()),
                    TenPhong = row["TenPhong"].ToString(),
                    TruongPhong = row["TruongPhong"].ToString()
                });
            }

            return PhongBanList;
        }

        public int Add(PhongBan PhongBan)
        {
            string sql = "AddPhongBan";
            Provider provider = new Provider();
            int rs = provider.ExcuteNonQuery(CommandType.StoredProcedure, sql,
                new SqlParameter {ParameterName = "@TenPhong", Value = PhongBan.TenPhong},
                new SqlParameter {ParameterName = "@TruongPhong", Value = PhongBan.TruongPhong},
                new SqlParameter {ParameterName = "@IdDiaDiem", Value = PhongBan.IdDiadiem});
            return rs;
        }

        public int Update(PhongBan PhongBan)
        {
            string sql = "UpdatePhongBan";
            Provider provider = new Provider();
            int rs = provider.ExcuteNonQuery(CommandType.StoredProcedure, sql,
                new SqlParameter {ParameterName = "@Id", Value = PhongBan.Id},
                new SqlParameter {ParameterName = "@TenPhong", Value = PhongBan.TenPhong},
                new SqlParameter {ParameterName = "@TruongPhong", Value = PhongBan.TruongPhong},
                new SqlParameter {ParameterName = "@IdDiaDiem", Value = PhongBan.IdDiadiem});
            return rs;
        }

        public int Delete(int id)
        {
            string sql = "DeletePhongBan";
            Provider provider = new Provider();
            int rs = provider.ExcuteNonQuery(CommandType.StoredProcedure, sql,
                new SqlParameter {ParameterName = "@Id", Value = id});
            return rs;
        }
    }
}