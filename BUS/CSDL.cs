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
        }

        // ================== LỚP XỬ LÝ LỚP HỌC ==================
        public class ClassBUS
        {
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
        }

        // ================== LỚP XỬ LÝ ĐĂNG KÝ ==================
        public class EnrollmentBUS
        {
            public static int ThemDangKy(string enrollmentId, string studentId, string classId,
                                 DateTime enrollDate, string status)
            {
                if (string.IsNullOrWhiteSpace(enrollmentId))
                    throw new ArgumentException("Mã đăng ký không được để trống.");

                if (string.IsNullOrWhiteSpace(studentId))
                    throw new ArgumentException("Mã sinh viên không được để trống.");

                if (string.IsNullOrWhiteSpace(classId))
                    throw new ArgumentException("Mã lớp học không được để trống.");

                return SQLServer.ThemDangKy(enrollmentId, studentId, classId, enrollDate, status);
            }
        }

        // ================== LỚP XỬ LÝ GIÁO VIÊN ==================
        public class TeacherBUS
        {
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
        public class AttendanceBUS
        {
            public static int ThemDiemDanh(string attendanceId, string studentId, string classId,
                                   DateTime date, string status)
            {
                if (string.IsNullOrWhiteSpace(attendanceId))
                    throw new ArgumentException("Mã điểm danh không được để trống.");

                if (string.IsNullOrWhiteSpace(studentId))
                    throw new ArgumentException("Mã sinh viên không được để trống.");

                if (string.IsNullOrWhiteSpace(classId))
                    throw new ArgumentException("Mã lớp học không được để trống.");

                return SQLServer.ThemDiemDanh(attendanceId, studentId, classId, date, status);
            }
        }
        //lấy danh sách khóa học
        
            static void Main(string[] args)
            {
            }
        }
    }
