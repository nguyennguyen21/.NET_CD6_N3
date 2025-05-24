using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AdminLodash.TacVu
{
    internal class AdminLogin
    {
        // Hàm kiểm tra đăng nhập mẫu
        public bool KiemTraDangNhap(string tenDangNhap, string matKhau, Action<string> onError)
        {
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                onError("Vui lòng nhập tên đăng nhập!");
                return false;
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                onError("Vui lòng nhập mật khẩu!");
                return false;
            }

            // Giả lập kiểm tra tài khoản (sẽ thay bằng truy vấn DB sau)
            if (tenDangNhap == "admin" && matKhau == "123")
            {
                return true;
            }
            else
            {
                onError("Tên đăng nhập hoặc mật khẩu không đúng.");
                return false;
            }
        }
    }
}