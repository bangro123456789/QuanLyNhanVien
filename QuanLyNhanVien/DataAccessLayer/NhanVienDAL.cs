using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanVien.Models;
using QuanLyNhanVien.Utils;

namespace QuanLyNhanVien.DBContext
{
    public class NhanVienDAL
    {
        public List<NhanVien> NhanViens()
        {
            List<NhanVien> NhanVienList = new List<NhanVien>();
            string sql = "GetNhanVien";
            Provider provider = new Provider();
            DataTable dt = provider.Select(CommandType.StoredProcedure, sql);
            foreach (DataRow row in dt.Rows)
            {
                NhanVienList.Add(new NhanVien()
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Luong = int.Parse(row["Luong"].ToString()),
                    DiaChi = row["DiaChi"].ToString(),
                    GioiTinh = row["GioiTinh"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    IdPhong = Int32.Parse(row["IdPhong"].ToString()),
                    NgaySinh = row["NgaySinh"].ToString(),
                    TenPhong = row["TenPhong"].ToString()
                });
            }

            return NhanVienList;
        }

        public int Add(NhanVien NhanVien)
        {
            string sql = "AddNhanVien";
            Provider provider = new Provider();
            int rs = provider.ExcuteNonQuery(CommandType.StoredProcedure, sql,
                new SqlParameter {ParameterName = "@HoTen", Value = NhanVien.HoTen},
                new SqlParameter {ParameterName = "@NgaySinh", Value = NhanVien.NgaySinh},
                new SqlParameter {ParameterName = "@DiaChi", Value = NhanVien.DiaChi},
                new SqlParameter {ParameterName = "@GioiTinh", Value = NhanVien.GioiTinh},
                new SqlParameter {ParameterName = "@Luong", Value = NhanVien.Luong},
                new SqlParameter {ParameterName = "@IdPhong", Value = NhanVien.IdPhong});
            return rs;
        }

        public int Update(NhanVien NhanVien)
        {
            string sql = "UpdateNhanVien";
            Provider provider = new Provider();
            int rs = provider.ExcuteNonQuery(CommandType.StoredProcedure, sql,
                new SqlParameter {ParameterName = "@Id", Value = NhanVien.Id},
                new SqlParameter {ParameterName = "@HoTen", Value = NhanVien.HoTen},
                new SqlParameter {ParameterName = "@NgaySinh", Value = NhanVien.NgaySinh},
                new SqlParameter {ParameterName = "@DiaChi", Value = NhanVien.DiaChi},
                new SqlParameter {ParameterName = "@GioiTinh", Value = NhanVien.GioiTinh},
                new SqlParameter {ParameterName = "@Luong", Value = NhanVien.Luong},
                new SqlParameter {ParameterName = "@IdPhong", Value = NhanVien.IdPhong});
            return rs;
        }

        public int Delete(int id)
        {
            string sql = "DeleteNhanVien";
            Provider provider = new Provider();
            int rs = provider.ExcuteNonQuery(CommandType.StoredProcedure, sql,
                new SqlParameter {ParameterName = "@Id", Value = id});
            return rs;
        }
    }
}