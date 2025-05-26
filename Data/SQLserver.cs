using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Data
{
    public class SQLServer
    {
        public static SqlConnection conn;
        public static string chuoiketnoi = "Data source = MSI; database = QLHangHoa; integrated security = true";
        public static Boolean taoketnoi()
        {
            conn = new SqlConnection(chuoiketnoi);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static DataTable laydulieutheotenbang(String tenbang)
        {
            string sql = "select * from " + tenbang;
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandText = sql;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception)
            {
                return dt;
            }
        }

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
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TestID", testId);
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    cmd.Parameters.AddWithValue("@TestName", testName);
                    cmd.Parameters.AddWithValue("@TestDate", testDate);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Fee", fee);

                    conn.Open();
                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return sodong;
        }
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
                using (SqlCommand cmd = new SqlCommand(sql, conn))
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

                    conn.Open();
                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return sodong;
        }

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
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                    cmd.Parameters.AddWithValue("@ClassName", className);
                    cmd.Parameters.AddWithValue("@MaxStudent", maxStudent);
                    cmd.Parameters.AddWithValue("@Schedule", schedule);
                    cmd.Parameters.AddWithValue("@Room", room);

                    conn.Open();
                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return sodong;
        }

        public static int ThemDangKy(string enrollmentId, string studentId, string classId,
                             DateTime enrollDate, string status)
        {
            string sql = @"INSERT INTO Enrollments 
                   (EnrollmentID, StudentID, ClassID, EnrollDate, Status) 
                   VALUES 
                   (@EnrollmentID, @StudentID, @ClassID, @EnrollDate, @Status)";

            int sodong = 0;

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@EnrollmentID", enrollmentId);
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    cmd.Parameters.AddWithValue("@EnrollDate", enrollDate);
                    cmd.Parameters.AddWithValue("@Status", status);

                    conn.Open();
                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return sodong;
        }

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
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    cmd.Parameters.AddWithValue("@CourseName", courseName);
                    cmd.Parameters.AddWithValue("@Level", level);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@TuitionFee", tuitionFee);
                    cmd.Parameters.AddWithValue("@Duration", duration);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    conn.Open();
                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return sodong;
        }
        public static int ThemDiem(string resultId, string studentId, string testId, decimal score, string note)
        {
            string sql = @"INSERT INTO Results 
                   (ResultID, StudentID, TestID, Score, Note) 
                   VALUES 
                   (@ResultID, @StudentID, @TestID, @Score, @Note)";

            int sodong = 0;

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ResultID", resultId);
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@TestID", testId);
                    cmd.Parameters.AddWithValue("@Score", score);
                    cmd.Parameters.AddWithValue("@Note", note);

                    conn.Open();
                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return sodong;
        }

        public static int ThemHocPhi(string feeId, string studentId, string classId,
                             decimal amountDue, decimal paidAmount,
                             DateTime dueDate, DateTime paymentDate, string status)
        {
            string sql = @"INSERT INTO Fees 
                   (FeeID, StudentID, ClassID, AmountDue, PaidAmount, DueDate, PaymentDate, Status) 
                   VALUES 
                   (@FeeID, @StudentID, @ClassID, @AmountDue, @PaidAmount, @DueDate, @PaymentDate, @Status)";

            int sodong = 0;

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FeeID", feeId);
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    cmd.Parameters.AddWithValue("@AmountDue", amountDue);
                    cmd.Parameters.AddWithValue("@PaidAmount", paidAmount);
                    cmd.Parameters.AddWithValue("@DueDate", dueDate);
                    cmd.Parameters.AddWithValue("@PaymentDate", paymentDate);
                    cmd.Parameters.AddWithValue("@Status", status);

                    conn.Open();
                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return sodong;
        }

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
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Specialty", specialty);
                    cmd.Parameters.AddWithValue("@created_at", createdAt);
                    cmd.Parameters.AddWithValue("@Degree", degree);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Status", status);

                    conn.Open();
                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return sodong;
        }

        

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
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@AttendanceID", attendanceId);
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@ClassID", classId);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Status", status);

                    conn.Open();
                    sodong = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return sodong;
        }
        static void Main(string[] args)
        {
        }
    }
}
