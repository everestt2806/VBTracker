using System;
using System.Collections.Generic;
using VBTracker.DAL;
using VBTracker.DTO;

namespace VBTracker.BUS
{
    public class AttendanceBUS
    {
        private AttendanceDAL attendanceDAL;
        private StudentDAL studentDAL;
        private ScheduleDAL scheduleDAL;

        public AttendanceBUS()
        {
            attendanceDAL = new AttendanceDAL();
            studentDAL = new StudentDAL();
            scheduleDAL = new ScheduleDAL();
        }

        public List<AttendanceDTO> GetAttendanceByScheduleID(string scheduleID)
        {
            if (string.IsNullOrEmpty(scheduleID))
                throw new ArgumentException("Mã lịch học không được để trống");

            return attendanceDAL.GetAttendanceByScheduleID(scheduleID);
        }

        public List<AttendanceDTO> GetAttendanceByStudentID(string studentID)
        {
            if (string.IsNullOrEmpty(studentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            return attendanceDAL.GetAttendanceByStudentID(studentID);
        }

        public AttendanceDTO GetAttendanceByID(string attendanceID)
        {
            if (string.IsNullOrEmpty(attendanceID))
                throw new ArgumentException("Mã điểm danh không được để trống");

            return attendanceDAL.GetAttendanceByID(attendanceID);
        }

        public bool AddAttendance(AttendanceDTO attendance)
        {
            ValidateAttendanceData(attendance);

            // Kiểm tra mã điểm danh đã tồn tại chưa
            if (attendanceDAL.GetAttendanceByID(attendance.AttendanceID) != null)
                throw new Exception("Mã điểm danh đã tồn tại");

            // Kiểm tra sinh viên tồn tại
            if (studentDAL.GetStudentByID(attendance.StudentID) == null)
                throw new Exception("Sinh viên không tồn tại");

            // Kiểm tra lịch học tồn tại
            if (scheduleDAL.GetScheduleByID(attendance.ScheduleID) == null)
                throw new Exception("Lịch học không tồn tại");

            return attendanceDAL.Insert(attendance);
        }

        public bool UpdateAttendance(AttendanceDTO attendance)
        {
            ValidateAttendanceData(attendance);

            // Kiểm tra điểm danh tồn tại
            AttendanceDTO existingAttendance = attendanceDAL.GetAttendanceByID(attendance.AttendanceID);
            if (existingAttendance == null)
                throw new Exception("Điểm danh không tồn tại");

            // Kiểm tra sinh viên tồn tại
            if (studentDAL.GetStudentByID(attendance.StudentID) == null)
                throw new Exception("Sinh viên không tồn tại");

            // Kiểm tra lịch học tồn tại
            if (scheduleDAL.GetScheduleByID(attendance.ScheduleID) == null)
                throw new Exception("Lịch học không tồn tại");

            return attendanceDAL.Update(attendance);
        }

        public bool DeleteAttendance(string attendanceID)
        {
            if (string.IsNullOrEmpty(attendanceID))
                throw new ArgumentException("Mã điểm danh không được để trống");

            // Kiểm tra điểm danh tồn tại
            AttendanceDTO existingAttendance = attendanceDAL.GetAttendanceByID(attendanceID);
            if (existingAttendance == null)
                throw new Exception("Điểm danh không tồn tại");

            return attendanceDAL.Delete(attendanceID);
        }

        private void ValidateAttendanceData(AttendanceDTO attendance)
        {
            if (attendance == null)
                throw new ArgumentNullException("Dữ liệu điểm danh không được để trống");

            if (string.IsNullOrEmpty(attendance.AttendanceID))
                throw new ArgumentException("Mã điểm danh không được để trống");

            if (string.IsNullOrEmpty(attendance.StudentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            if (string.IsNullOrEmpty(attendance.ScheduleID))
                throw new ArgumentException("Mã lịch học không được để trống");

            if (attendance.AttendanceDate == DateTime.MinValue)
                throw new ArgumentException("Ngày điểm danh không hợp lệ");

            if (string.IsNullOrEmpty(attendance.Status))
                throw new ArgumentException("Trạng thái điểm danh không được để trống");

            // Kiểm tra trạng thái điểm danh hợp lệ
            if (attendance.Status != "Present" && attendance.Status != "Absent" && attendance.Status != "Late")
                throw new ArgumentException("Trạng thái điểm danh không hợp lệ (Present, Absent, Late)");
        }
    }
}
