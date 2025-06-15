using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace Data
{
    public class SQLServer
    {
        public static MySqlConnection conn;
        public static string chuoiketnoi = "Server=localhost;Database=hv_tt_nn;Uid=root;Pwd=1234;";

        // Hàm tạo kết nối an toàn
        public static bool taoketnoi()
        {
            try
            {
                if (conn == null || conn.State == ConnectionState.Closed)
                {
                    conn = new MySqlConnection(chuoiketnoi);
                    conn.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kết nối: " + ex.Message);
                return false;
            }
        }

        // Lấy dữ liệu theo tên bảng
        public static DataTable laydulieutheotenbang(string tenbang)
        {
            string sql = "SELECT * FROM " + tenbang;
            DataTable dt = new DataTable();
            try
            {
                if (!taoketnoi()) return dt;
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi đọc dữ liệu: " + ex.Message);
                return dt;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        // Thêm khóa học
        public static int ThemKhoaHoc(string courseId, string courseName, string level,
                                      string description, decimal tuitionFee, int duration,
                                      DateTime startDate, DateTime endDate)
        {
            string sql = @"INSERT INTO Courses 
                   (CourseID, CourseName, Level, Description, TuitionFee, Duration, StartDate, EndDate) 
                   VALUES 
                   (@CourseID, @CourseName, @Level, @Description, @TuitionFee, @Duration, @StartDate, @EndDate)";
            int sodong = 0;
            try
            {
                if (!taoketnoi()) return 0;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    cmd.Parameters.AddWithValue("@CourseName", courseName);
                    cmd.Parameters.AddWithValue("@Level", level);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@TuitionFee", tuitionFee);
                    cmd.Parameters.AddWithValue("@Duration", duration);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm khóa học: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return sodong;
        }

        // Thêm sinh viên
        public static int ThemSinhVien(string studentId, string fullName, DateTime dateOfBirth,
                                string gender, string phone, string address,
                                DateTime registrationDate, string status, string password)
        {
            string sql = @"INSERT INTO Students 
                   (StudentID, FullName, DateOfBirth, Gender, Phone, Address, RegistrationDate, Status, Password) 
                   VALUES 
                   (@StudentID, @FullName, @DateOfBirth, @Gender, @Phone, @Address, @RegistrationDate, @Status, @Password)";
            int sodong = 0;
            try
            {
                if (!taoketnoi()) return 0;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@RegistrationDate", registrationDate);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Password", password);

                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm sinh viên: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return sodong;
        }

        // Thêm lớp học
        public static int ThemLopHoc(string classId, string courseId, string teacherId, string className,
                             int maxStudent, string schedule, string room)
        {
            string sql = @"INSERT INTO Classes 
                   (ClassID, CourseID, TeacherID, ClassName, MaxStudent, Schedule, Room) 
                   VALUES 
                   (@ClassID, @CourseID, @TeacherID, @ClassName, @MaxStudent, @Schedule, @Room)";
            int sodong = 0;
            try
            {
                if (!taoketnoi()) return 0;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                    cmd.Parameters.AddWithValue("@ClassName", className);
                    cmd.Parameters.AddWithValue("@MaxStudent", maxStudent);
                    cmd.Parameters.AddWithValue("@Schedule", schedule);
                    cmd.Parameters.AddWithValue("@Room", room);

                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm lớp học: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return sodong;
        }

        // Thêm đăng ký
        public static int ThemDangKy(string studentId, string classId,
                              DateTime enrollDate, string status)
        {
            string sql = @"INSERT INTO Enrollments 
                   (StudentID, ClassID, EnrollDate, Status) 
                   VALUES 
                   (@StudentID, @ClassID, @EnrollDate, @Status)";
            int sodong = 0;
            try
            {
                if (!taoketnoi()) return 0;
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    cmd.Parameters.AddWithValue("@EnrollDate", enrollDate);
                    cmd.Parameters.AddWithValue("@Status", status);
                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm đăng ký: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return sodong;
        }

        // Thêm bài thi
        public static int ThemBaiThi(string testId, string classId, string testName,
                     DateTime testDate, string description, decimal fee)
        {
            string sql = @"INSERT INTO Tests 
                   (TestID, ClassID, TestName, TestDate, Description, Fee) 
                   VALUES 
                   (@TestID, @ClassID, @TestName, @TestDate, @Description, @Fee)";
            int sodong = 0;
            try
            {
                if (!taoketnoi()) return 0;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TestID", testId);
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    cmd.Parameters.AddWithValue("@TestName", testName);
                    cmd.Parameters.AddWithValue("@TestDate", testDate);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Fee", fee);

                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm bài thi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return sodong;
        }

        // Thêm học phí
        public static int ThemHocPhi(string studentId, string classId,
                              decimal amountDue, decimal paidAmount,
                              DateTime dueDate, DateTime? paymentDate, int status)
        {
            string sql = @"INSERT INTO tuition_fees
                   (StudentID, ClassID, AmountDue, PaidAmount, DueDate, PaymentDate, Status) 
                   VALUES 
                   (@StudentID, @ClassID, @AmountDue, @PaidAmount, @DueDate, @PaymentDate, @Status)";

            try
            {
                if (!taoketnoi()) return -1;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    cmd.Parameters.AddWithValue("@AmountDue", amountDue);
                    cmd.Parameters.AddWithValue("@PaidAmount", paidAmount);
                    cmd.Parameters.AddWithValue("@DueDate", dueDate);
                    cmd.Parameters.AddWithValue("@PaymentDate", paymentDate.HasValue ? (object)paymentDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", status); // Truyền kiểu int
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm học phí: " + ex.Message);
                
                return -1;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public static bool KiemTraTonTaiHocVien(string studentId)
        {
            string sql = "SELECT COUNT(*) FROM Students WHERE StudentID = @StudentID";
            try
            {
                if (!taoketnoi()) return false;
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kiểm tra tồn tại học viên: " + ex.Message);
                return false;
            }
        }
        public static bool KiemTraTonTaiLopHoc(string classId)
        {
            string sql = "SELECT COUNT(*) FROM Classes WHERE ClassID = @ClassID";
            try
            {
                if (!taoketnoi()) return false;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kiểm tra tồn tại lớp học: " + ex.Message);
                return false;
            }
        }
        public static DataTable LayDanhSachHocVienChuaDangKy(string classId)
        {
            string sql = @"SELECT s.StudentID, s.FullName 
                   FROM Students s
                   WHERE s.StudentID NOT IN (
                       SELECT e.StudentID FROM Enrollments e WHERE e.ClassID = @ClassID
                   ) AND s.Status = 'Active'";

            return ExecuteQuery(sql, new MySqlParameter("@ClassID", classId));
        }

        // Thêm giáo viên
        public static int ThemGiaoVien(string teacherId, string fullName, string specialty,
                               DateTime createdAt, string degree, string email,
                               string phone, string status)
        {
            string sql = @"INSERT INTO Teachers 
                   (TeacherID, FullName, Specialty, created_at, Degree, Email, Phone, Status) 
                   VALUES 
                   (@TeacherID, @FullName, @Specialty, @created_at, @Degree, @Email, @Phone, @Status)";
            int sodong = 0;
            try
            {
                if (!taoketnoi()) return 0;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Specialty", specialty);
                    cmd.Parameters.AddWithValue("@created_at", createdAt);
                    cmd.Parameters.AddWithValue("@Degree", degree);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Status", status);

                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm giáo viên: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return sodong;
        }

        // Thêm điểm
        public static int ThemDiem(string resultId, string studentId, string testId, decimal score, string note)
        {
            string sql = @"INSERT INTO Results 
                   (ResultID, StudentID, TestID, Score, Note) 
                   VALUES 
                   (@ResultID, @StudentID, @TestID, @Score, @Note)";
            int sodong = 0;
            try
            {    
                if (!taoketnoi()) return 0;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ResultID", resultId);
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@TestID", testId);
                    cmd.Parameters.AddWithValue("@Score", score);
                    cmd.Parameters.AddWithValue("@Note", note);

                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm điểm: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return sodong;
        }

        // Thêm điểm danh
        public static int ThemDiemDanh(string attendanceId, string studentId, string classId,
                               DateTime date, string status)
        {
            string sql = @"INSERT INTO Attendance 
                   (AttendanceID, StudentID, ClassID, Date, Status) 
                   VALUES 
                   (@AttendanceID, @StudentID, @ClassID, @Date, @Status)";
            int sodong = 0;
            try
            {
                if (!taoketnoi()) return 0;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@AttendanceID", attendanceId);
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Status", status);

                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm điểm danh: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return sodong;
        }

        // Cập nhật dữ liệu
        public static int CapNhatDuLieu(string tenBang, Dictionary<string, object> duLieuCapNhat, string dieuKienWhere, params MySqlParameter[] parameters)
        {
            if (string.IsNullOrEmpty(tenBang) || string.IsNullOrEmpty(dieuKienWhere) || duLieuCapNhat == null || duLieuCapNhat.Count == 0)
                return -1;

            StringBuilder sql = new StringBuilder("UPDATE " + tenBang + " SET ");
            foreach (var item in duLieuCapNhat)
            {
                sql.Append($"{item.Key} = @{item.Key}, ");
            }
            sql.Length -= 2; // Xóa dấu ", "
            sql.Append(" WHERE " + dieuKienWhere);

            int sodong = 0;
            try
            {
                if (!taoketnoi()) return 0;

                using (MySqlCommand cmd = new MySqlCommand(sql.ToString(), conn))
                {
                    foreach (var item in duLieuCapNhat)
                    {
                        cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                    }

                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật dữ liệu: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return sodong;
        }

        // Xóa dữ liệu
        public static int XoaDuLieu(string tenBang, string dieuKienWhere, params MySqlParameter[] parameters)
        {
            if (string.IsNullOrEmpty(tenBang) || string.IsNullOrEmpty(dieuKienWhere))
                return -1;

            string sql = $"DELETE FROM {tenBang} WHERE {dieuKienWhere}";
            int sodong = 0;
            try
            {
                if (!taoketnoi()) return 0;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa dữ liệu: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return sodong;
        }

        // Lấy mã học viên lớn nhất
        public static string LayMaHocVienLonNhat()
        {
            string sql = "SELECT StudentID FROM Students WHERE StudentID LIKE 'hv%' ORDER BY StudentID DESC LIMIT 1";
            string maCuoi = null;
            try
            {
                if (!taoketnoi()) return null;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        maCuoi = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy mã học viên: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return maCuoi;
        }

        // Tạo mã học viên tự động
        public static string TaoMaHocVienTuDong()
        {
            string prefix = "hv";
            string maCuoi = LayMaHocVienLonNhat();
            int stt = 1;
            if (!string.IsNullOrEmpty(maCuoi) && maCuoi.StartsWith(prefix))
            {
                string soSauMa = maCuoi.Substring(prefix.Length);
                if (int.TryParse(soSauMa, out int currentNumber))
                {
                    stt = currentNumber + 1;
                }
            }
            return prefix + stt.ToString("D3");
        }

        // Tạo mã lớp học
        public static string TaoMaPhu(string tenLop)
        {
            string[] words = tenLop.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string maPhu = "";
            foreach (var word in words)
            {
                if (!string.IsNullOrWhiteSpace(word))
                {
                    maPhu += char.ToUpper(word[0]);
                }
            }
            return maPhu;
        }

        public static int LaySoThuTuLonNhat(string prefix)
        {
            string sql = $"SELECT MAX(CAST(SUBSTRING(ClassID, LENGTH('{prefix}') + 1, LENGTH(ClassID)) AS UNSIGNED)) " +
                         $"FROM Classes WHERE ClassID LIKE '{prefix}%'";
            int maxNumber = 0;
            try
            {
                if (!taoketnoi()) return 0;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        maxNumber = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy số thứ tự: " + ex.Message);
            }
            return maxNumber;
        }

        public static string TaoMaLopHoc(string tenLop)
        {
            string prefix = "TA";
            string maPhu = TaoMaPhu(tenLop);
            string baseCode = prefix + maPhu;
            int nextNumber = LaySoThuTuLonNhat(baseCode) + 1;
            return $"{baseCode}{nextNumber:D3}";
        }

        public static int LaySoThuTuLonNhat_2(string prefix)
        {
            string sql = $@"SELECT MAX(CAST(SUBSTRING(CourseID, LENGTH('{prefix}') + 1, 3) AS UNSIGNED)) 
                    FROM Courses 
                    WHERE CourseID LIKE '{prefix}%'";
            int maxNumber = 0;
            try
            {
                if (!taoketnoi()) return 0;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        maxNumber = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy số thứ tự khóa học: " + ex.Message);
            }
            return maxNumber;
        }

        // Sinh mã khóa học
        public static string GenerateCourseID(string level, DateTime startDate)
        {
            string datePart = startDate.ToString("yyyyMMdd");
            string prefix = $"KH{datePart}";
            int nextNumber = LaySoThuTuLonNhat(prefix) + 1;
            return $"{prefix}{nextNumber:D3}";
        }

        public static string TaoMaKhoaHocTuDong(string level, DateTime startDate)
        {
            string levelCode;

            if (level == "Dễ")
            {
                levelCode = "DE";
            }
            else if (level == "Trung bình")
            {
                levelCode = "TB";
            }
            else if (level == "Khó")
            {
                levelCode = "KHO";
            }
            else if (level == "Nâng cao")
            {
                levelCode = "NC";
            }
            else
            {
                levelCode = "XX";
            }

            string prefix = $"KH{levelCode}{startDate:yyyyMMdd}";
            int nextNumber = SQLServer.LaySoThuTuLonNhat(prefix) + 1;
            return $"{prefix}{nextNumber:D3}";
        }

        // Danh sách cấp độ
        public static List<string> LayDanhSachLevel()
        {
            return new List<string> { "Dễ", "Trung bình", "Khó", "Nâng cao" };
        }

        //xóa ràng buộc 
        public static int XoaLopHoc(string classId)
        {
            int sodong = 0;
            try
            {
                if (!taoketnoi()) return 0;

                using (MySqlCommand cmd = new MySqlCommand("XoaLopHoc", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_classId", classId);
                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa lớp học: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return sodong;
        }

       

        public static DataTable LayDanhSachHocVienTheoLop(string classId)
        {
            string sql = @"SELECT s.StudentID, s.FullName, s.Phone, s.Email, e.EnrollDate, e.Status 
                   FROM Students s
                   INNER JOIN Enrollments e ON s.StudentID = e.StudentID
                   WHERE e.ClassID = @ClassID";
            DataTable dt = new DataTable();
            try
            {
                if (!taoketnoi()) return dt;
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tải danh sách học viên theo lớp: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }
        public static bool KiemTraDaDangKy(string studentId, string classId)
        {
            string sql = "SELECT COUNT(*) FROM Enrollments WHERE StudentID = @StudentID AND ClassID = @ClassID";
            try
            {
                if (!taoketnoi()) return false;
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kiểm tra đăng ký: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public static int GetMaxStudentFromClass(string classId)
        {
            string sql = "SELECT MaxStudent FROM Classes WHERE ClassID = @ClassID";
            try
            {
                if (!taoketnoi()) return 0;
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int maxStudent))
                    {
                        return maxStudent;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy MaxStudent: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return 0;
        }
    
        public static int TaoMaDangKyTuDong()
        {
            string sql = "SELECT MAX(EnrollmentID) FROM Enrollments";
            try
            {
                if (!taoketnoi()) return 0;
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();
                    int nextNumber = 1;
                    if (result != null && result != DBNull.Value)
                    {
                        nextNumber = Convert.ToInt32(result) + 1;
                    }
                    return nextNumber;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tạo mã đăng ký: " + ex.Message);
                return 0;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public static int XoaKhoaHoc(string courseId)
        {
            int deletedRows = 0;

            try
            {
                if (!Data.SQLServer.taoketnoi()) return 0;

                // Bước 1: Xóa các bản ghi phụ thuộc
                deletedRows += Data.SQLServer.XoaDuLieu("Classes", "CourseID = @CourseID", new MySqlParameter("@CourseID", courseId));

                // Bước 2: Xóa khóa học
                deletedRows += Data.SQLServer.XoaDuLieu("Courses", "CourseID = @CourseID", new MySqlParameter("@CourseID", courseId));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa khóa học: " + ex.Message);
                return -1;
            }
            finally
            {
                if (Data.SQLServer.conn.State == ConnectionState.Open)
                    Data.SQLServer.conn.Close();
            }

            return deletedRows;
        }

        public static int XoaKhoaHocKhongRangBuoc(string courseId)
        {
            int deletedRows = 0;

            try
            {
                if (!Data.SQLServer.taoketnoi()) return 0;

                // Tắt ràng buộc khóa ngoại tạm thời
                using (MySqlCommand cmd = new MySqlCommand("SET FOREIGN_KEY_CHECKS = 0;", Data.SQLServer.conn))
                    cmd.ExecuteNonQuery();

                // Bước 1: Xóa các bảng phụ thuộc theo thứ tự từ sâu đến nông
                deletedRows += Data.SQLServer.XoaDuLieu("test_results", "ClassID IN (SELECT ClassID FROM Classes WHERE CourseID = @CourseID)", new MySqlParameter("@CourseID", courseId));
                deletedRows += Data.SQLServer.XoaDuLieu("Tests", "ClassID IN (SELECT ClassID FROM Classes WHERE CourseID = @CourseID)", new MySqlParameter("@CourseID", courseId));
                deletedRows += Data.SQLServer.XoaDuLieu("Attendance", "ClassID IN (SELECT ClassID FROM Classes WHERE CourseID = @CourseID)", new MySqlParameter("@CourseID", courseId));
                deletedRows += Data.SQLServer.XoaDuLieu("Enrollments", "ClassID IN (SELECT ClassID FROM Classes WHERE CourseID = @CourseID)", new MySqlParameter("@CourseID", courseId));
                deletedRows += Data.SQLServer.XoaDuLieu("tuition_fees", "ClassID IN (SELECT ClassID FROM Classes WHERE CourseID = @CourseID)", new MySqlParameter("@CourseID", courseId));

                // Bước 2: Xóa lớp học
                deletedRows += Data.SQLServer.XoaDuLieu("Classes", "CourseID = @CourseID", new MySqlParameter("@CourseID", courseId));

                // Bước 3: Xóa khóa học
                deletedRows += Data.SQLServer.XoaDuLieu("Courses", "CourseID = @CourseID", new MySqlParameter("@CourseID", courseId));

                // Bật lại ràng buộc khóa ngoại
                using (MySqlCommand cmd = new MySqlCommand("SET FOREIGN_KEY_CHECKS = 1;", Data.SQLServer.conn))
                    cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa khóa học: " + ex.Message);
                return -1;
            }
            finally
            {
                if (Data.SQLServer.conn.State == ConnectionState.Open)
                    Data.SQLServer.conn.Close();
            }

            return deletedRows;
        }

        public static DataTable LayDanhSachGiaoVien()
        {
            string sql = "SELECT * FROM Teachers";
            DataTable dt = new DataTable();
            try
            {
                if (!taoketnoi()) return dt;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tải danh sách giáo viên: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }
        public static bool KiemTraDangNhapGiaoVien(string teacherId, string password)
        {
            string sql = "SELECT COUNT(*) FROM Teachers WHERE TeacherID = @TeacherID AND Password = @Password";
            try
            {
                if (!taoketnoi()) return false;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kiểm tra đăng nhập giáo viên: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public static DataTable LayDanhSachHocVien()
        {
            string sql = "SELECT * FROM Students";
            DataTable dt = new DataTable();

            try
            {
                if (!taoketnoi()) return dt;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tải danh sách học viên: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return dt;
        }
        public static DataTable LayDanhSachHocVienTheoTrangThai(string status)
        {
            string sql = "SELECT * FROM Students WHERE Status = @Status";
            DataTable dt = new DataTable();

            try
            {
                if (!taoketnoi()) return dt;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy danh sách học viên theo trạng thái: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return dt;
        }
        public static DataTable LayDanhSachDiemDanh()
        {
            string sql = "SELECT * FROM Attendance";
            DataTable dt = new DataTable();
            try
            {
                if (!taoketnoi()) return dt;
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tải danh sách điểm danh: " + ex.Message);
                return dt;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public static DataTable LayDanhSachDiemDanhTheoLopVaNgay(string classId, string date)
        {
            string sql = "SELECT * FROM Attendance WHERE ClassID = @ClassID AND Date = @Date";
            DataTable dt = new DataTable();
            try
            {
                if (!taoketnoi()) return dt;
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    cmd.Parameters.AddWithValue("@Date", date);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tải danh sách điểm danh theo lớp và ngày: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }

        public static DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                if (!taoketnoi()) return dt;

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thực thi truy vấn: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }
        // Main method (nếu cần)



        static void Main(string[] args)
        {
            // Có thể để trống hoặc chạy thử nghiệm ở đây
        }
    }
}