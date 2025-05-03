using System;
using System.Collections.Generic;
using VBTracker.DAL;
using VBTracker.DTO;

namespace VBTracker.BUS
{
    public class ScheduleBUS
    {
        private ScheduleDAL scheduleDAL;
        private ClassDAL classDAL;
        private RoomDAL roomDAL;

        public ScheduleBUS()
        {
            scheduleDAL = new ScheduleDAL();
            classDAL = new ClassDAL();
            roomDAL = new RoomDAL();
        }

        public List<ScheduleDTO> GetAllSchedules()
        {
            return scheduleDAL.GetAll();
        }

        public List<ScheduleDTO> GetSchedulesByClassID(string classID)
        {
            if (string.IsNullOrEmpty(classID))
                throw new ArgumentException("Mã lớp học không được để trống");

            return scheduleDAL.GetSchedulesByClassID(classID);
        }

        public List<ScheduleDTO> GetSchedulesByRoomID(string roomID)
        {
            if (string.IsNullOrEmpty(roomID))
                throw new ArgumentException("Mã phòng học không được để trống");

            return scheduleDAL.GetSchedulesByRoomID(roomID);
        }

        public ScheduleDTO GetScheduleByID(string scheduleID)
        {
            if (string.IsNullOrEmpty(scheduleID))
                throw new ArgumentException("Mã lịch học không được để trống");

            return scheduleDAL.GetScheduleByID(scheduleID);
        }

        public bool AddSchedule(ScheduleDTO schedule)
        {
            ValidateScheduleData(schedule);

            // Kiểm tra mã lịch học đã tồn tại chưa
            if (scheduleDAL.GetScheduleByID(schedule.ScheduleID) != null)
                throw new Exception("Mã lịch học đã tồn tại");

            // Kiểm tra lớp học tồn tại
            if (classDAL.GetClassByID(schedule.ClassID) == null)
                throw new Exception("Lớp học không tồn tại");

            // Kiểm tra phòng học tồn tại
            if (roomDAL.GetById(schedule.RoomID) == null)
                throw new Exception("Phòng học không tồn tại");

            // Kiểm tra xung đột lịch học
            if (IsScheduleConflict(schedule))
                throw new Exception("Lịch học bị trùng với lịch học khác trong cùng phòng");

            return scheduleDAL.Insert(schedule);
        }

        public bool UpdateSchedule(ScheduleDTO schedule)
        {
            ValidateScheduleData(schedule);

            // Kiểm tra lịch học tồn tại
            ScheduleDTO existingSchedule = scheduleDAL.GetScheduleByID(schedule.ScheduleID);
            if (existingSchedule == null)
                throw new Exception("Lịch học không tồn tại");

            // Kiểm tra lớp học tồn tại
            if (classDAL.GetClassByID(schedule.ClassID) == null)
                throw new Exception("Lớp học không tồn tại");

            // Kiểm tra phòng học tồn tại
            if (roomDAL.GetById(schedule.RoomID) == null)
                throw new Exception("Phòng học không tồn tại");

            // Kiểm tra xung đột lịch học (trừ chính lịch học này)
            if (IsScheduleConflict(schedule, schedule.ScheduleID))
                throw new Exception("Lịch học bị trùng với lịch học khác trong cùng phòng");

            return scheduleDAL.Update(schedule);
        }

        public bool DeleteSchedule(string scheduleID)
        {
            if (string.IsNullOrEmpty(scheduleID))
                throw new ArgumentException("Mã lịch học không được để trống");

            // Kiểm tra lịch học tồn tại
            ScheduleDTO existingSchedule = scheduleDAL.GetScheduleByID(scheduleID);
            if (existingSchedule == null)
                throw new Exception("Lịch học không tồn tại");

            // TODO: Kiểm tra các ràng buộc khác trước khi xóa (ví dụ: lịch học đã có điểm danh)

            return scheduleDAL.Delete(scheduleID);
        }

        // Kiểm tra xung đột lịch học
        private bool IsScheduleConflict(ScheduleDTO schedule, string excludeScheduleID = null)
        {
            List<ScheduleDTO> roomSchedules = scheduleDAL.GetSchedulesByRoomID(schedule.RoomID);

            foreach (ScheduleDTO existingSchedule in roomSchedules)
            {
                // Bỏ qua chính lịch học này (khi cập nhật)
                if (!string.IsNullOrEmpty(excludeScheduleID) && existingSchedule.ScheduleID == excludeScheduleID)
                    continue;

                // Kiểm tra trùng ngày học
                if (existingSchedule.DayOfWeek == schedule.DayOfWeek)
                {
                    // Kiểm tra trùng ca học
                    if (existingSchedule.Session == schedule.Session)
                    {
                        // Kiểm tra trùng tuần học
                        // Có xung đột nếu có bất kỳ tuần nào trùng nhau
                        if ((existingSchedule.WeekStart <= schedule.WeekEnd && existingSchedule.WeekEnd >= schedule.WeekStart))
                            return true;
                    }
                }
            }

            return false;
        }

        private void ValidateScheduleData(ScheduleDTO schedule)
        {
            if (schedule == null)
                throw new ArgumentNullException("Dữ liệu lịch học không được để trống");

            if (string.IsNullOrEmpty(schedule.ScheduleID))
                throw new ArgumentException("Mã lịch học không được để trống");

            if (string.IsNullOrEmpty(schedule.ClassID))
                throw new ArgumentException("Mã lớp học không được để trống");

            if (string.IsNullOrEmpty(schedule.RoomID))
                throw new ArgumentException("Mã phòng học không được để trống");

            if (string.IsNullOrEmpty(schedule.DayOfWeek))
                throw new ArgumentException("Ngày học không được để trống");

            if (string.IsNullOrEmpty(schedule.Session))
                throw new ArgumentException("Ca học không được để trống");

            if (schedule.WeekStart <= 0)
                throw new ArgumentException("Tuần bắt đầu phải lớn hơn 0");

            if (schedule.WeekEnd <= 0)
                throw new ArgumentException("Tuần kết thúc phải lớn hơn 0");

            if (schedule.WeekStart > schedule.WeekEnd)
                throw new ArgumentException("Tuần bắt đầu không được lớn hơn tuần kết thúc");

            // Kiểm tra ngày học hợp lệ
            string[] validDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            bool validDay = false;
            foreach (string day in validDays)
            {
                if (schedule.DayOfWeek == day)
                {
                    validDay = true;
                    break;
                }
            }
            if (!validDay)
                throw new ArgumentException("Ngày học không hợp lệ");

            // Kiểm tra ca học hợp lệ
            string[] validSessions = { "1", "2", "3", "4" };
            bool validSession = false;
            foreach (string session in validSessions)
            {
                if (schedule.Session == session)
                {
                    validSession = true;
                    break;
                }
            }
            if (!validSession)
                throw new ArgumentException("Ca học không hợp lệ");
        }
    }
}
