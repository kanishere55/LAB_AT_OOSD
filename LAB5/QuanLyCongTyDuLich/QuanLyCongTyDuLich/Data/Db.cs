using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCongTyDuLich.Data
{
    /// <summary>Lớp hỗ trợ truy cập SQL Server; Form không viết SQL trực tiếp.</summary>
    public static class Db
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["QuanLyCongTyDuLichDB"].ConnectionString; }
        }

        public static SqlConnection OpenConnection()
        {
            var cn = new SqlConnection(ConnectionString);
            try { cn.Open(); return cn; }
            catch { cn.Dispose(); throw; }
        }

        public static T Transaction<T>(System.Func<SqlConnection, SqlTransaction, T> action)
        {
            using (var cn = OpenConnection())
            using (var tr = cn.BeginTransaction(IsolationLevel.Serializable))
            {
                try { T result = action(cn, tr); tr.Commit(); return result; }
                catch { try { tr.Rollback(); } catch { } throw; }
            }
        }

        public static DataTable Query(SqlConnection cn, SqlTransaction tr, string sql, params SqlParameter[] ps)
        {
            using (var cmd = new SqlCommand(sql, cn, tr))
            using (var da = new SqlDataAdapter(cmd))
            { cmd.Parameters.AddRange(ps); var dt = new DataTable(); da.Fill(dt); return dt; }
        }

        public static object Scalar(SqlConnection cn, SqlTransaction tr, string sql, params SqlParameter[] ps)
        {
            using (var cmd = new SqlCommand(sql, cn, tr)) { cmd.Parameters.AddRange(ps); return cmd.ExecuteScalar(); }
        }

        public static int Execute(SqlConnection cn, SqlTransaction tr, string sql, params SqlParameter[] ps)
        {
            using (var cmd = new SqlCommand(sql, cn, tr)) { cmd.Parameters.AddRange(ps); return cmd.ExecuteNonQuery(); }
        }

        public static DataTable Query(string sql, params SqlParameter[] ps)
        {
            using (var cn = OpenConnection())
            using (var cmd = new SqlCommand(sql, cn))
            using (var da = new SqlDataAdapter(cmd))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static int Execute(string sql, params SqlParameter[] ps)
        {
            using (var cn = OpenConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteNonQuery();
            }
        }

        public static object Scalar(string sql, params SqlParameter[] ps)
        {
            using (var cn = OpenConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>Tạo SqlParameter, chuỗi rỗng / null được ghi thành DBNull.</summary>
        public static SqlParameter P(string name, object value)
        {
            var s = value as string;
            if (value == null || (s != null && s.Trim().Length == 0)) return new SqlParameter(name, System.DBNull.Value);
            return new SqlParameter(name, s != null ? s.Trim() : value);
        }
    }
}
