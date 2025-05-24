using System;
using MySql.Data.MySqlClient;
using AdminLodash.Mysql;

namespace AdminLodash.TacVu
{
    internal class AdminLoginLogic
    {
        public bool KiemTraDangNhap(string username, string password,string FullName, out string errorMessage)
        {
            errorMessage = "";

            MySqlConnection conn = connectsql.GetConnection();
            connectsql.OpenConnection(conn);

            try
            {
                string query = "SELECT COUNT(*) FROM admins WHERE username = @username AND password = @password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@FullName", FullName)
                    cmd.Parameters.AddWithValue("@password", password); // Nên dùng hash mật khẩu

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        errorMessage = "Tên đăng nhập hoặc mật khẩu sai.";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi hệ thống: " + ex.Message;
                return false;
            }
            finally
            {
                connectsql.CloseConnection(conn);
            }
        }
    }
}