using System;
using System.Collections.Generic;
using System.Data;
using Data;
using MySql.Data.MySqlClient;

namespace Bus
{
    // ================== LỚP XỬ LÝ KHÓA HỌC ==================
    public class BUS
    {
        public static int CapNhatDuLieu(string tenBang, Dictionary<string, object> duLieuCapNhat, string dieuKienWhere, params MySqlParameter[] parameters)
        {
            return Data.SQLServer.CapNhatDuLieu(tenBang, duLieuCapNhat, dieuKienWhere, parameters);
        }
        
        public static DataTable LayDanhSachKhoaHoc()
        {
            return SQLServer.laydulieutheotenbang("courses");
        }

      
        // Xóa khóa học
        public static int XoaKhoaHoc(string courseId)
        {
            return SQLServer.XoaDuLieu("Courses", "CourseID = @CourseID",
                new MySqlParameter("@CourseID", courseId));
        }

        // Cập nhật khóa học
        public static int CapNhatKhoaHoc(string courseId, string courseName, string level,
                                   string description, decimal tuitionFee, int duration,
                                   DateTime startDate, DateTime endDate)
        {
            var data = new Dictionary<string, object>
            {
                ["CourseName"] = courseName,
                ["Level"] = level,
                ["Description"] = description,
                ["TuitionFee"] = tuitionFee,
                ["Duration"] = duration,
                ["StartDate"] = startDate,
                ["EndDate"] = endDate
            };

            return SQLServer.CapNhatDuLieu("Courses", data, "CourseID = @CourseID",
                new MySqlParameter("@CourseID", courseId));
        }
        // Tự động sinh mã khóa học
        // Hàm sinh mã khóa học tự động
        public static string TaoMaKhoaHocTuDong(DateTime startDate)
        {
            return SQLServer.GenerateCourseID("", startDate); // Nếu bạn không cần phân biệt cấp độ
        }

        // Hàm thêm khóa học
        public static int ThemKhoaHoc(string courseId, string courseName, string level,
                                    string description, decimal tuitionFee, int duration,
                                    DateTime startDate, DateTime endDate)
        {
            return Data.SQLServer.ThemKhoaHoc(courseId, courseName, level, description, tuitionFee, duration, startDate, endDate);
        }
        // Hàm mới: Tìm khóa học theo tên hoặc mã
        public static DataTable TimKhoaHocTheoTenHoacMa(string keyword)
        {
            return Data.SQLServer.laydulieutheotenbang($"Courses WHERE CourseID LIKE '%{keyword}%' OR CourseName LIKE '%{keyword}%'");
        }
        public static int XoaKhoaHocKhongRangBuoc(string courseId)
        {
            return Data.SQLServer.XoaKhoaHocKhongRangBuoc(courseId);
        }

        // ================== LỚP XỬ LÝ SINH VIÊN ==================
        public class StudentBUS
        {
            public static int ThemSinhVien(string studentId, string fullName, DateTime dateOfBirth,
                                            string gender, string phone, string address,
                                            DateTime registrationDate, string status, string password)
            {
                if (string.IsNullOrWhiteSpace(studentId))
                    throw new ArgumentException("Mã sinh viên không được để trống.");

                if (string.IsNullOrWhiteSpace(fullName))
                    throw new ArgumentException("Họ tên không được để trống.");

                return SQLServer.ThemSinhVien(studentId, fullName, dateOfBirth, gender, phone, address,
                                              registrationDate, status, password);
            }
            public static DataTable LayDanhSachHocVien()
            {
                return Data.SQLServer.LayDanhSachHocVien();
            }
            public static DataTable LayDanhSachHocVienTheoTrangThai(string status)
            {
                return Data.SQLServer.LayDanhSachHocVienTheoTrangThai(status);
            }
            public static DataTable TimHocVienTheoMa(string studentId)
            {
                string sql = "SELECT * FROM Students WHERE StudentID = @StudentID";
                return Data.SQLServer.ExecuteQuery(sql,
                    new MySqlParameter("@StudentID", studentId));
            }
        }

        // ================== LỚP XỬ LÝ LỚP HỌC ==================
        public class ClassBUS
        {
            public static DataTable LayDanhLopHoc()
            {
                return SQLServer.laydulieutheotenbang("classes");
            }
            public static int GetMaxStudentFromClass(string classId)
            {
                return Data.SQLServer.GetMaxStudentFromClass(classId);
            }
            // Hàm xóa lớp học
            public static int XoaLopHoc(string classId)
            {
                int deletedRows = 0;

                try
                {
                    if (!Data.SQLServer.taoketnoi()) return 0;

                    // Bước 1: Xóa các bản ghi phụ thuộc
                    deletedRows += Data.SQLServer.XoaDuLieu("Enrollments", "ClassID = @ClassID", new MySqlParameter("@ClassID", classId));
                    deletedRows += Data.SQLServer.XoaDuLieu("Attendance", "ClassID = @ClassID", new MySqlParameter("@ClassID", classId));
                    deletedRows += Data.SQLServer.XoaDuLieu("Results", "ClassID = @ClassID", new MySqlParameter("@ClassID", classId));
                    deletedRows += Data.SQLServer.XoaDuLieu("Tests", "ClassID = @ClassID", new MySqlParameter("@ClassID", classId));

                    // Bước 2: Xóa lớp học
                    deletedRows += Data.SQLServer.XoaDuLieu("Classes", "ClassID = @ClassID", new MySqlParameter("@ClassID", classId));
                }
                catch (Exception )
                {
                    
                    return -1;
                }
                finally
                {
                    if (Data.SQLServer.conn.State == ConnectionState.Open)
                        Data.SQLServer.conn.Close();
                }

                return deletedRows;
            }
            public static int ThemLopHoc(string classId, string courseId, string teacherId, string className,
                                         int maxStudent, string schedule, string room)
            {
                if (string.IsNullOrWhiteSpace(classId))
                    throw new ArgumentException("Mã lớp không được để trống.");

                if (string.IsNullOrWhiteSpace(className))
                    throw new ArgumentException("Tên lớp không được để trống.");

                if (maxStudent <= 0)
                    throw new ArgumentException("Số lượng học viên tối đa phải lớn hơn 0.");

                return SQLServer.ThemLopHoc(classId, courseId, teacherId, className, maxStudent, schedule, room);
            }

            public static DataTable LopHocTheoTenHoacMa(string keyword)
            {
                return Data.SQLServer.laydulieutheotenbang($"Classes WHERE ClassID LIKE '%{keyword}%' OR ClassName LIKE '%{keyword}%'");
            }
            public static int CapNhatLopHoc(
                string classId,
                string courseId,
                string teacherId,
                string className,
                int maxStudent,
            string schedule,
    string room)
            {
                var data = new Dictionary<string, object>
                {
                    ["CourseID"] = courseId,
                    ["TeacherID"] = teacherId,
                    ["ClassName"] = className,
                    ["MaxStudent"] = maxStudent,
                    ["Schedule"] = schedule,
                    ["Room"] = room
                };

                string dieuKienWhere = "ClassID = @ClassID";
                var parameters = new MySqlParameter[]
                {
        new MySqlParameter("@ClassID", classId)
                };

                return SQLServer.CapNhatDuLieu("Classes", data, dieuKienWhere, parameters);
            }

            public static string TaoMaLopHoc(string tenLop)
            {
                return Data.SQLServer.TaoMaLopHoc(tenLop);
            }

            public static DataTable LayDanhSachHocVienTheoLop(string classId)
            {
                return Data.SQLServer.LayDanhSachHocVienTheoLop(classId);
            }
        }
            // ================== LỚP XỬ LÝ ĐĂNG KÝ ==================
            public class EnrollmentBUS
        {

            // Hàm sinh mã đăng ký tự động
            public static int TaoMaDangKyTuDong()
            {
                return Data.SQLServer.TaoMaDangKyTuDong();
            }


            public static int ThemDangKy(string studentId, string classId,
                             DateTime enrollDate, string status)
            {
                if (string.IsNullOrWhiteSpace(studentId))
                    throw new ArgumentException("Mã sinh viên không được để trống.");
                if (string.IsNullOrWhiteSpace(classId))
                    throw new ArgumentException("Mã lớp học không được để trống.");

                return SQLServer.ThemDangKy(studentId, classId, enrollDate, status);
            }

            public static bool KiemTraDaDangKy(string studentId, string classId)
            {
                return Data.SQLServer.KiemTraDaDangKy(studentId, classId);
            }



        }

        // ================== LỚP XỬ LÝ GIÁO VIÊN ==================
        public class TeacherBUS
        {
            

            public static DataTable LayDanhSachGiaoVien()
            {
                return Data.SQLServer.laydulieutheotenbang("Teachers");
            }
            public static int ThemGiaoVien(string teacherId, string fullName, string specialty,
                                   DateTime createdAt, string degree, string email,
                                   string phone, string status)
            {
                if (string.IsNullOrWhiteSpace(teacherId))
                    throw new ArgumentException("Mã giáo viên không được để trống.");

                if (string.IsNullOrWhiteSpace(fullName))
                    throw new ArgumentException("Tên giáo viên không được để trống.");

                if (string.IsNullOrWhiteSpace(email))
                    throw new ArgumentException("Email không được để trống.");

                return SQLServer.ThemGiaoVien(teacherId, fullName, specialty, createdAt, degree, email, phone, status);
            }
            public static bool KiemTraDangNhapGiaoVien(string teacherId, string password)
            {
                return Data.SQLServer.KiemTraDangNhapGiaoVien(teacherId, password);
            }
        }

        // ================== LỚP XỬ LÝ HỌC PHÍ ==================
        public class FeeBUS
        {
            public static int ThemHocPhi(string feeId, string studentId, string classId,
                                 decimal amountDue, decimal paidAmount,
                                 DateTime dueDate, DateTime paymentDate, string status)
            {
                if (string.IsNullOrWhiteSpace(feeId))
                    throw new ArgumentException("Mã học phí không được để trống.");

                if (string.IsNullOrWhiteSpace(studentId))
                    throw new ArgumentException("Mã sinh viên không được để trống.");

                if (amountDue < 0 || paidAmount < 0)
                    throw new ArgumentException("Số tiền phải lớn hơn hoặc bằng 0.");

                return SQLServer.ThemHocPhi(feeId, studentId, classId, amountDue, paidAmount, dueDate, paymentDate, status);
            }

            public static DataTable LayHocPhiTheoHocVien(string studentId)
            {
                string sql = "SELECT * FROM Fees WHERE StudentID = @StudentID";
                return Data.SQLServer.ExecuteQuery(sql,
                    new MySqlParameter("@StudentID", studentId));
            }

          
        }

        // ================== LỚP XỬ LÝ BÀI THI ==================
        public class TestBUS
        {
            public static int ThemBaiThi(string testId, string classId, string testName,
                         DateTime testDate, string description, decimal fee)
            {
                if (string.IsNullOrWhiteSpace(testId))
                    throw new ArgumentException("Mã bài thi không được để trống.");

                if (string.IsNullOrWhiteSpace(testName))
                    throw new ArgumentException("Tên bài thi không được để trống.");

                return SQLServer.ThemBaiThi(testId, classId, testName, testDate, description, fee);
            }
        }

        // ================== LỚP XỬ LÝ ĐIỂM ==================
        public class ResultBUS
        {
            public static int ThemDiem(string resultId, string studentId, string testId, decimal score, string note)
            {
                if (string.IsNullOrWhiteSpace(resultId))
                    throw new ArgumentException("Mã kết quả không được để trống.");

                if (score < 0 || score > 10)
                    throw new ArgumentException("Điểm phải nằm trong khoảng từ 0 đến 10.");

                return SQLServer.ThemDiem(resultId, studentId, testId, score, note);
            }
        }

        // ================== LỚP XỬ LÝ ĐIỂM DANH ==================
        public static class AttendanceBUS
        {
            // Get StudentID by Name
            public static string GetStudentID(string studentName)
            {
                DataTable dt = Data.SQLServer.laydulieutheotenbang("Students");
                foreach (DataRow row in dt.Rows)
                {
                    if (row["FullName"].ToString() == studentName)
                    {
                        return row["StudentID"].ToString();
                    }
                }
                throw new Exception($"Học viên '{studentName}' không tìm thấy.");
            }

            // Get ClassID by Name
            public static string GetClassID(string className)
            {
                DataTable dt = Data.SQLServer.laydulieutheotenbang("Classes");
                foreach (DataRow row in dt.Rows)
                {
                    if (row["ClassName"].ToString() == className)
                    {
                        return Convert.ToString(row["ClassID"]);
                    }
                }
                throw new Exception($"Class '{className}' not found.");
            }

            // Check if attendance already exists
            public static bool CheckAttendance(string studentID, string classID, DateTime date)
            {
                string sql = $"SELECT COUNT(*) FROM attendance WHERE StudentID = {studentID} AND ClassID = {classID} AND Date = '{date:yyyy-MM-dd}'";
                try
                {
                    if (!Data.SQLServer.taoketnoi()) return false;

                    using (MySqlCommand cmd = new MySqlCommand(sql, Data.SQLServer.conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (Exception )
                {
                    
                    return false;
                }
                finally
                {
                    if (Data.SQLServer.conn.State == ConnectionState.Open)
                        Data.SQLServer.conn.Close();
                }

                
            }

            // Insert new attendance record
            public static bool InsertAttendance(string studentID, string classID, DateTime date, string status)
            {
                string sql = $"INSERT INTO attendance (StudentID, ClassID, Date, Status) VALUES ({studentID}, {classID}, '{date:yyyy-MM-dd}', '{status}')";

                try
                {
                    if (!Data.SQLServer.taoketnoi()) return false;

                    using (MySqlCommand cmd = new MySqlCommand(sql, Data.SQLServer.conn))
                    {
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception )
                {
                   
                    return false;
                }
                finally
                {
                    if (Data.SQLServer.conn.State == ConnectionState.Open)
                        Data.SQLServer.conn.Close();
                }
            }
        }

        
        

        //lấy danh sách khóa học

        static void Main(string[] args)
            {
            }
        }
    }
