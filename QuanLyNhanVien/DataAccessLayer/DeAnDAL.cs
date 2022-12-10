using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanVien.Models;
using QuanLyNhanVien.Utils;

namespace QuanLyNhanVien.DBContext
{
    public class DeAnDAL
    {
        public List<DeAn> DeAns()
        {
            List<DeAn> DeAnList = new List<DeAn>();
            string sql = "GetDeAn";
            Provider provider = new Provider();
            DataTable dt = provider.Select(CommandType.StoredProcedure, sql);
            foreach (DataRow row in dt.Rows)
            {
                DeAnList.Add(new DeAn()
                {
                    Id = int.Parse(row["Id"].ToString()),

                    TenDA = row["TenDA"].ToString(),
                    DiaDiem = row["DiaDiem"].ToString(),
                    TenPhong = row["TenPhong"].ToString(),
                    IdPhong = Int32.Parse(row["IdPhong"].ToString()),
                });
            }

            return DeAnList;
        }

        public int Add(DeAn DeAn)
        {
            string sql = "AddDeAn";
            Provider provider = new Provider();
            int rs = provider.ExcuteNonQuery(CommandType.StoredProcedure, sql,
                new SqlParameter {ParameterName = "@TenDA", Value = DeAn.TenDA},
                new SqlParameter {ParameterName = "@DiaDiem", Value = DeAn.DiaDiem},
                new SqlParameter {ParameterName = "@IdPhong", Value = DeAn.IdPhong});
            return rs;
        }

        public int Update(DeAn DeAn)
        {
            string sql = "UpdateDeAn";
            Provider provider = new Provider();
            int rs = provider.ExcuteNonQuery(CommandType.StoredProcedure, sql,
                new SqlParameter {ParameterName = "@Id", Value = DeAn.Id},
                new SqlParameter {ParameterName = "@TenDA", Value = DeAn.TenDA},
                new SqlParameter {ParameterName = "@DiaDiem", Value = DeAn.DiaDiem},
                new SqlParameter {ParameterName = "@IdPhong", Value = DeAn.IdPhong});
            return rs;
        }

        public int Delete(int id)
        {
            string sql = "DeleteDeAn";
            Provider provider = new Provider();
            int rs = provider.ExcuteNonQuery(CommandType.StoredProcedure, sql,
                new SqlParameter {ParameterName = "@Id", Value = id});
            return rs;
        }
    }
}