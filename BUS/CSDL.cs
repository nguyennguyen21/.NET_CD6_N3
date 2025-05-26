using System;
using Data;

namespace BUS
{
    public class CSDL
    {
        // ========== SINH VIÊN ==========
        public static int ThemSinhVien(
            string studentId,
            string fullName,
            DateTime dateOfBirth,
            string gender,
            string phone,
            string address,
            DateTime registrationDate,
            string status,
            string password)
        {
            return SQLServer.ThemSinhVien(studentId, fullName, dateOfBirth, gender, phone, address, registrationDate, status, password);
        }

        // ========== LỚP HỌC ==========
        public static int ThemLopHoc(
            string classId,
            string courseId,
            string teacherId,
            string className,
            int maxStudent,
            string schedule,
            string room)
        {
            return SQLServer.ThemLopHoc(classId, courseId, teacherId, className, maxStudent, schedule, room);
        }

        // ========== KHÓA HỌC ==========
        public static int ThemKhoaHoc(
            string courseId,
            string courseName,
            string level,
            string description,
            decimal tuitionFee,
            int duration,
            DateTime startDate,
            DateTime endDate)
        {
            return SQLServer.ThemKhoaHoc(courseId, courseName, level, description, tuitionFee, duration, startDate, endDate);
        }

        // ========== ĐĂNG KÝ HỌC ==========
        public static int ThemDangKy(
            string enrollmentId,
            string studentId,
            string classId,
            DateTime enrollDate,
            string status)
        {
            return SQLServer.ThemDangKy(enrollmentId, studentId, classId, enrollDate, status);
        }

        // ========== GIÁO VIÊN ==========
        public static int ThemGiaoVien(
            string teacherId,
            string fullName,
            string specialty,
            DateTime createdAt,
            string degree,
            string email,
            string phone,
            string status)
        {
            return SQLServer.ThemGiaoVien(teacherId, fullName, specialty, createdAt, degree, email, phone, status);
        }

        // ========== BÀI THI ==========
        public static int ThemBaiThi(
            string testId,
            string classId,
            string testName,
            DateTime testDate,
            string description,
            decimal fee)
        {
            return SQLServer.ThemBaiThi(testId, classId, testName, testDate, description, fee);
        }

        // ========== KẾT QUẢ ==========
        public static int ThemDiem(
            string resultId,
            string studentId,
            string testId,
            decimal score,
            string note)
        {
            return SQLServer.ThemDiem(resultId, studentId, testId, score, note);
        }

        // ========== HỌC PHÍ ==========
        public static int ThemHocPhi(
            string feeId,
            string studentId,
            string classId,
            decimal amountDue,
            decimal paidAmount,
            DateTime dueDate,
            DateTime paymentDate,
            string status)
        {
            return SQLServer.ThemHocPhi(feeId, studentId, classId, amountDue, paidAmount, dueDate, paymentDate, status);
        }

        // ========== ĐIỂM DANH ==========
        public static int ThemDiemDanh(
            string attendanceId,
            string studentId,
            string classId,
            DateTime date,
            string status)
        {
            return SQLServer.ThemDiemDanh(attendanceId, studentId, classId, date, status);
        }
    }
}