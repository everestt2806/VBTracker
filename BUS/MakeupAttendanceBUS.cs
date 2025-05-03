using System;
using System.Collections.Generic;
using VBTracker.DAL;
using VBTracker.DTO;

namespace VBTracker.BUS
{
    public class MakeupAttendanceBUS
    {
        private MakeupAttendanceDAL makeupAttendanceDAL;

        public MakeupAttendanceBUS()
        {
            makeupAttendanceDAL = new MakeupAttendanceDAL();
        }

        public List<MakeupAttendanceDTO> GetAllMakeupAttendances()
        {
            return makeupAttendanceDAL.GetAll();
        }

        public MakeupAttendanceDTO GetMakeupAttendanceByID(string makeupAttendanceID)
        {
            if (string.IsNullOrEmpty(makeupAttendanceID))
                throw new ArgumentException("Mã điểm danh bù không được để trống");

            return makeupAttendanceDAL.GetByID(makeupAttendanceID);
        }

        public List<MakeupAttendanceDTO> GetMakeupAttendancesByMakeupClassID(string makeupClassID)
        {
            if (string.IsNullOrEmpty(makeupClassID))
                throw new ArgumentException("Mã lớp học bù không được để trống");

            return makeupAttendanceDAL.GetByMakeupClassID(makeupClassID);
        }

        public List<MakeupAttendanceDTO> GetMakeupAttendancesByStudentID(string studentID)
        {
            if (string.IsNullOrEmpty(studentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            return makeupAttendanceDAL.GetByStudentID(studentID);
        }

        public bool AddMakeupAttendance(MakeupAttendanceDTO makeupAttendance)
        {
            ValidateMakeupAttendanceData(makeupAttendance);

            // Kiểm tra mã điểm danh bù đã tồn tại chưa
            if (makeupAttendanceDAL.GetByID(makeupAttendance.MakeupAttendanceID) != null)
                throw new Exception("Mã điểm danh bù đã tồn tại");

            return makeupAttendanceDAL.Insert(makeupAttendance);
        }

        public bool UpdateMakeupAttendance(MakeupAttendanceDTO makeupAttendance)
        {
            ValidateMakeupAttendanceData(makeupAttendance);

            // Kiểm tra điểm danh bù tồn tại
            MakeupAttendanceDTO existingAttendance = makeupAttendanceDAL.GetByID(makeupAttendance.MakeupAttendanceID);
            if (existingAttendance == null)
                throw new Exception("Điểm danh bù không tồn tại");

            return makeupAttendanceDAL.Update(makeupAttendance);
        }

        public bool DeleteMakeupAttendance(string makeupAttendanceID)
        {
            if (string.IsNullOrEmpty(makeupAttendanceID))
                throw new ArgumentException("Mã điểm danh bù không được để trống");

            // Kiểm tra điểm danh bù tồn tại
            MakeupAttendanceDTO existingAttendance = makeupAttendanceDAL.GetByID(makeupAttendanceID);
            if (existingAttendance == null)
                throw new Exception("Điểm danh bù không tồn tại");

            return makeupAttendanceDAL.Delete(makeupAttendanceID);
        }

        private void ValidateMakeupAttendanceData(MakeupAttendanceDTO makeupAttendance)
        {
            if (makeupAttendance == null)
                throw new ArgumentNullException(nameof(makeupAttendance), "Thông tin điểm danh bù không được để trống");

            if (string.IsNullOrEmpty(makeupAttendance.MakeupAttendanceID))
                throw new ArgumentException("Mã điểm danh bù không được để trống");

            if (string.IsNullOrEmpty(makeupAttendance.StudentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            if (string.IsNullOrEmpty(makeupAttendance.MakeupClassID))
                throw new ArgumentException("Mã lớp học bù không được để trống");

            if (string.IsNullOrEmpty(makeupAttendance.Status))
                throw new ArgumentException("Trạng thái điểm danh không được để trống");

            // Kiểm tra trạng thái hợp lệ
            if (makeupAttendance.Status != "Present" && makeupAttendance.Status != "Absent" && makeupAttendance.Status != "Late")
                throw new ArgumentException("Trạng thái điểm danh không hợp lệ. Chỉ chấp nhận: Present, Absent, Late");
        }
    }
}
