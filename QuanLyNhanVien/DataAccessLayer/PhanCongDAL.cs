using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanVien.Models;
using QuanLyNhanVien.Utils;

namespace QuanLyNhanVien.DBContext
{
    public class PhanCongDAL
    {
        public List<PhanCong> PhanCongs()
        {
            List<PhanCong> PhanCongList = new List<PhanCong>();
            string sql = "GetPhanCong";
            Provider provider = new Provider();
            DataTable dt = provider.Select(CommandType.StoredProcedure, sql);
            foreach (DataRow row in dt.Rows)
            {
                PhanCongList.Add(new PhanCong()
                {
                    Id = int.Parse(row["Id"].ToString()),
                    IdNhanVien = int.Parse(row["IdNhanVien"].ToString()),
                    SoDA = int.Parse(row["SoDA"].ToString()),
                    HoTen = row["HoTen"].ToString(),
                    ThoiGian = row["ThoiGian"].ToString()
                });
            }

            return PhanCongList;
        }

        public int Add(PhanCong PhanCong)
        {
            string sql = "AddPhanCong";
            Provider provider = new Provider();
            int rs = provider.ExcuteNonQuery(CommandType.StoredProcedure, sql,
                new SqlParameter {ParameterName = "@IdNhanVien", Value = PhanCong.IdNhanVien},
                new SqlParameter {ParameterName = "@SoDA", Value = PhanCong.SoDA},
                new SqlParameter {ParameterName = "@ThoiGian", Value = PhanCong.ThoiGian}
            );
            return rs;
        }

        public int Update(PhanCong PhanCong)
        {
            string sql = "UpdatePhanCong";
            Provider provider = new Provider();
            int rs = provider.ExcuteNonQuery(CommandType.StoredProcedure, sql,
                new SqlParameter {ParameterName = "@Id", Value = PhanCong.Id},
                new SqlParameter {ParameterName = "@IdNhanVien", Value = PhanCong.IdNhanVien},
                new SqlParameter {ParameterName = "@SoDA", Value = PhanCong.SoDA},
                new SqlParameter {ParameterName = "@ThoiGian", Value = PhanCong.ThoiGian}
            );
            return rs;
        }

        public int Delete(int id)
        {
            string sql = "DeletePhanCong";
            Provider provider = new Provider();
            int rs = provider.ExcuteNonQuery(CommandType.StoredProcedure, sql,
                new SqlParameter {ParameterName = "@Id", Value = id});
            return rs;
        }
    }
}