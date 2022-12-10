using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanVien.Models;
using QuanLyNhanVien.Utils;

namespace QuanLyNhanVien.DBContext
{
    public class DiaDiemDAL
    {
        public List<DiaDiem> DiaDiems()
        {
            List<DiaDiem> diaDiemList = new List<DiaDiem>();
            string sql = "GetDiaDiem";
            Provider provider = new Provider();
            DataTable dt = provider.Select(CommandType.StoredProcedure, sql);
            foreach (DataRow row in dt.Rows)
            {
                diaDiemList.Add(new DiaDiem(int.Parse(row["Id"].ToString()), row["DiaDiem"].ToString()));
            }

            return diaDiemList;
        }

        public int Add(DiaDiem diaDiem)
        {
            string sql = "AddDiaDiem";
            Provider provider = new Provider();
            int rs = provider.ExcuteNonQuery(CommandType.StoredProcedure, sql,
                new SqlParameter {ParameterName = "@DiaDiem", Value = diaDiem.DiaDiem1});
            return rs;
        }

        public int Update(DiaDiem diaDiem)
        {
            string sql = "UpdateDiadiem";
            Provider provider = new Provider();
            int rs = provider.ExcuteNonQuery(CommandType.StoredProcedure, sql,
                new SqlParameter {ParameterName = "@Id", Value = diaDiem.Id},
                new SqlParameter {ParameterName = "@DiaDiem", Value = diaDiem.DiaDiem1});
            return rs;
        }

        public int Delete(int id)
        {
            string sql = "DeleteDiaDiem";
            Provider provider = new Provider();
            int rs = provider.ExcuteNonQuery(CommandType.StoredProcedure, sql,
                new SqlParameter {ParameterName = "@Id", Value = id});
            return rs;
        }
    }
}