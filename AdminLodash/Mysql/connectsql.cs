using System;
using MySql.Data.MySqlClient;

namespace AdminLodash.Mysql
{
    internal class connectsql
    {
        // Chuỗi kết nối
        private static string ConnectionString = "server=localhost;port=3306;database=quan_li_hoc_vien_tt_nn;uid=root;pwd=1234;";

        // Trả về đối tượng kết nối
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // Mở kết nối và kiểm tra lỗi
        public static void OpenConnection(MySqlConnection conn)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    Console.WriteLine("Kết nối CSDL thành công.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kết nối CSDL: " + ex.Message);
            }
        }

        // Đóng kết nối
        public static void CloseConnection(MySqlConnection conn)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    Console.WriteLine("Đã đóng kết nối CSDL.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đóng kết nối: " + ex.Message);
            }
        }
    }
}