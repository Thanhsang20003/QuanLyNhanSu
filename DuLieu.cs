using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom8_QuanLyNhanSu
{
    internal class DuLieu
    {
        SqlConnection conn;
        string constr = "Data Source=DUCTIN; Initial Catalog=QLNhansu4;User Id=sa;Password=123";
        public DuLieu()
        {
            conn = new SqlConnection(constr);

        }
        public void OpenDuLieu()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public void CloseDuLieu()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public int GetDuLieu(string sql, SqlParameter[] parameters)
        {
            OpenDuLieu();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                int kq = cmd.ExecuteNonQuery();
                CloseDuLieu();
                return kq;
            }
        }
        public int ExecuteScalar(string sql, SqlParameter[] parameters = null)
        {
            OpenDuLieu();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                object result = cmd.ExecuteScalar();
                CloseDuLieu();

                // Kiểm tra xem result có null không
                if (result != null && result is int)
                {
                    return (int)result;
                }
                return 0; 
            }
        }

        public object getExceuteScalar(string sql)
        {
            OpenDuLieu();
            SqlCommand cmd = new SqlCommand(sql, conn);
            object kq = cmd.ExecuteScalar();
            CloseDuLieu();
            return kq;
        }

        public object ExecuteScalar2(string sql, SqlParameter[] parameters = null)
        {
            OpenDuLieu();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                object result = cmd.ExecuteScalar();
                CloseDuLieu();

                // Trả về kết quả
                return result;
            }
        }

        public DataTable GetDataTable(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int TacDongDataTable(string sql, DataTable dt)
        {
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                    int kq = da.Update(dt);
                    return kq;
                }
            }
            catch (Exception ex)
            {
                // Ghi log hoặc hiển thị thông báo lỗi
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                return 0; // Hoặc giá trị nào đó biểu thị không thành công
            }

        }
        public DataTable GetDataTable2(string sql, SqlParameter[] parameters = null)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            if (parameters != null)
            {
                da.SelectCommand.Parameters.AddRange(parameters);
            }
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool KiemTraTrungKhoaChinh(string tableName, string primaryKey, string primaryValue)
        {
            string sql = $"SELECT COUNT(*) FROM {tableName} WHERE {primaryKey} = @PrimaryValue";
            SqlParameter[] parameters = { new SqlParameter("@PrimaryValue", primaryValue) };

            int count = ExecuteScalar(sql, parameters);
            return count > 0; // Nếu số lượng > 0 thì tồn tại, trả về true
        }
        public bool KiemTraKhoaNgoai(string foreignKeyTable, string foreignKeyColumn, string primaryValue)
        {
            string sql = $"SELECT COUNT(*) FROM {foreignKeyTable} WHERE {foreignKeyColumn} = @PrimaryValue";
            SqlParameter[] parameters = { new SqlParameter("@PrimaryValue", primaryValue) };

            int count = ExecuteScalar(sql, parameters);
            return count > 0; // Nếu số lượng > 0 thì khóa ngoại đang được sử dụng, trả về true
        }

    }
}
