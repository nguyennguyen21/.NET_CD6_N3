using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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
    namespace AdminTacVu
    {
        internal class TacVu
        {
            public void DangKyHocVien(
      string hoTen,
      DateTime ngaySinh,
      string gioiTinh,
      string sdt,
      string diaChi,
      string matKhau,
      Action<string> onError,
      Action<string> onSuccess)
            {
                // Xử lý lỗi đầu vào
                List<string> errors = new List<string>();

                if (string.IsNullOrEmpty(hoTen))
                    errors.Add("Vui lòng nhập họ và tên!\n");

                if (string.IsNullOrEmpty(matKhau))
                    errors.Add("Vui lòng nhập mật khẩu!\n");

                if (string.IsNullOrEmpty(sdt))
                    errors.Add("Vui lòng nhập số điện thoại!\n");
                else if (sdt.Length != 10 || !sdt.All(char.IsDigit))
                {
                    onError("Số điện thoại phải gồm đúng 10 chữ số!");
                    return;
                }

                if (string.IsNullOrEmpty(diaChi))
                    errors.Add("Vui lòng nhập địa chỉ!\n");

                if (string.IsNullOrEmpty(gioiTinh))
                    errors.Add("Vui lòng chọn giới tính!\n");

                if (errors.Count > 0)
                {
                    onError(string.Join("", errors));
                    return;
                }

                string StudentID = "";
                DateTime RegistrationDate = DateTime.Now;

                MySqlConnection conn = connectsql.GetConnection();
                connectsql.OpenConnection(conn);

                try
                {
                    // Tự động sinh mã học viên
                    string getLastIdQuery = "SELECT StudentId FROM students ORDER BY StudentId DESC LIMIT 1";
                    using (MySqlCommand cmdLastId = new MySqlCommand(getLastIdQuery, conn))
                    {
                        var lastIdObj = cmdLastId.ExecuteScalar();
                        if (lastIdObj != null)
                        {
                            string lastId = lastIdObj.ToString();
                            int number = int.Parse(lastId.Substring(2));
                            number++;
                            StudentID = "HV" + number.ToString("D3");
                        }
                        else
                        {
                            StudentID = "HV001";
                        }
                    }

                    // Thêm bản ghi
                    string query = @"INSERT INTO students 
                        (StudentId, FullName, DateOfBirth, Gender, Phone, Address, RegistrationDate, Password) 
                        VALUES (@StudentId, @FullName, @DateOfBirth, @Gender, @Phone, @Address, @RegistrationDate, @Password)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", StudentID);
                        cmd.Parameters.AddWithValue("@FullName", hoTen);
                        cmd.Parameters.AddWithValue("@DateOfBirth", ngaySinh);
                        cmd.Parameters.AddWithValue("@Gender", gioiTinh);
                        cmd.Parameters.AddWithValue("@Phone", sdt);
                        cmd.Parameters.AddWithValue("@Address", diaChi);
                        cmd.Parameters.AddWithValue("@RegistrationDate", RegistrationDate);
                        cmd.Parameters.AddWithValue("@Password", HashPassword(matKhau));

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            onSuccess("Đăng ký thành công với mã: " + StudentID);
                        }
                        else
                        {
                            onError("Lưu thất bại!");
                        }
                    }
                }
                finally
                {
                    connectsql.CloseConnection(conn);
                }
            }
            //Mã hóa Mk
            private string HashPassword(string password)
                {
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(password);
                        byte[] hash = sha256.ComputeHash(bytes);

                        StringBuilder builder = new StringBuilder();
                        foreach (byte b in hash)
                        {
                            builder.Append(b.ToString("x2"));
                        }
                        return builder.ToString();
                    }
                }
            }
        }
    }
}