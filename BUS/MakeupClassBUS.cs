using System;
using System.Collections.Generic;
using VBTracker.DAL;
using VBTracker.DTO;

namespace VBTracker.BUS
{
    public class MakeupClassBUS
    {
        private MakeupClassDAL makeupClassDAL;

        public MakeupClassBUS()
        {
            makeupClassDAL = new MakeupClassDAL();
        }

        public List<MakeupClassDTO> GetAllMakeupClasses()
        {
            return makeupClassDAL.GetAll();
        }

        public MakeupClassDTO GetMakeupClassByID(string makeupClassID)
        {
            if (string.IsNullOrEmpty(makeupClassID))
                throw new ArgumentException("Mã lớp học bù không được để trống");

            return makeupClassDAL.GetByID(makeupClassID);
        }

        public List<MakeupClassDTO> GetMakeupClassesByLecturerID(string lecturerID)
        {
            if (string.IsNullOrEmpty(lecturerID))
                throw new ArgumentException("Mã giảng viên không được để trống");

            return makeupClassDAL.GetByLecturerID(lecturerID);
        }

        public List<MakeupClassDTO> GetMakeupClassesByOriginalClassID(string originalClassID)
        {
            if (string.IsNullOrEmpty(originalClassID))
                throw new ArgumentException("Mã lớp học gốc không được để trống");

            return makeupClassDAL.GetByOriginalClassID(originalClassID);
        }

        public bool AddMakeupClass(MakeupClassDTO makeupClass)
        {
            ValidateMakeupClassData(makeupClass);

            // Kiểm tra mã lớp học bù đã tồn tại chưa
            if (makeupClassDAL.GetByID(makeupClass.MakeupClassID) != null)
                throw new Exception("Mã lớp học bù đã tồn tại");

            return makeupClassDAL.Insert(makeupClass);
        }

        public bool UpdateMakeupClass(MakeupClassDTO makeupClass)
        {
            ValidateMakeupClassData(makeupClass);

            // Kiểm tra lớp học bù tồn tại
            MakeupClassDTO existingClass = makeupClassDAL.GetByID(makeupClass.MakeupClassID);
            if (existingClass == null)
                throw new Exception("Lớp học bù không tồn tại");

            return makeupClassDAL.Update(makeupClass);
        }

        public bool DeleteMakeupClass(string makeupClassID)
        {
            if (string.IsNullOrEmpty(makeupClassID))
                throw new ArgumentException("Mã lớp học bù không được để trống");

            // Kiểm tra lớp học bù tồn tại
            MakeupClassDTO existingClass = makeupClassDAL.GetByID(makeupClassID);
            if (existingClass == null)
                throw new Exception("Lớp học bù không tồn tại");

            // TODO: Kiểm tra các ràng buộc khác trước khi xóa (ví dụ: đã có điểm danh)

            return makeupClassDAL.Delete(makeupClassID);
        }

        private void ValidateMakeupClassData(MakeupClassDTO makeupClass)
        {
            if (makeupClass == null)
                throw new ArgumentNullException(nameof(makeupClass), "Thông tin lớp học bù không được để trống");

            if (string.IsNullOrEmpty(makeupClass.MakeupClassID))
                throw new ArgumentException("Mã lớp học bù không được để trống");

            if (string.IsNullOrEmpty(makeupClass.OriginalClassID))
                throw new ArgumentException("Mã lớp học gốc không được để trống");

            if (string.IsNullOrEmpty(makeupClass.RoomID))
                throw new ArgumentException("Mã phòng học không được để trống");

            if (string.IsNullOrEmpty(makeupClass.LecturerID))
                throw new ArgumentException("Mã giảng viên không được để trống");

            if (string.IsNullOrEmpty(makeupClass.Session))
                throw new ArgumentException("Ca học không được để trống");

            if (string.IsNullOrEmpty(makeupClass.Status))
                throw new ArgumentException("Trạng thái lớp học không được để trống");

            // Kiểm tra ca học hợp lệ
            if (makeupClass.Session != "Morning" && makeupClass.Session != "Afternoon" && makeupClass.Session != "Evening")
                throw new ArgumentException("Ca học không hợp lệ. Chỉ chấp nhận: Morning, Afternoon, Evening");

            // Kiểm tra trạng thái hợp lệ
            if (makeupClass.Status != "Scheduled" && makeupClass.Status != "Completed" && makeupClass.Status != "Cancelled")
                throw new ArgumentException("Trạng thái lớp học không hợp lệ. Chỉ chấp nhận: Scheduled, Completed, Cancelled");

            // Kiểm tra ngày học bù phải sau ngày hiện tại
            if (makeupClass.MakeupDate < DateTime.Today)
                throw new ArgumentException("Ngày học bù phải từ ngày hiện tại trở đi");
        }
    }
}
