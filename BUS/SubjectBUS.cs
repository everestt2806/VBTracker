using System;
using System.Collections.Generic;
using VBTracker.DAL;
using VBTracker.DTO;

namespace VBTracker.BUS
{
    public class SubjectBUS
    {
        private SubjectDAL subjectDAL;

        public SubjectBUS()
        {
            subjectDAL = new SubjectDAL();
        }

        public List<SubjectDTO> GetAllSubjects()
        {
            return subjectDAL.GetAll();
        }

        public SubjectDTO GetSubjectByID(string subjectID)
        {
            if (string.IsNullOrEmpty(subjectID))
                throw new ArgumentException("Mã môn học không được để trống");

            return subjectDAL.GetSubjectByID(subjectID);
        }

        public bool AddSubject(SubjectDTO subject)
        {
            ValidateSubjectData(subject);

            // Kiểm tra mã môn học đã tồn tại chưa
            if (subjectDAL.GetSubjectByID(subject.SubjectID) != null)
                throw new Exception("Mã môn học đã tồn tại");

            // Kiểm tra tên môn học đã tồn tại chưa
            List<SubjectDTO> allSubjects = subjectDAL.GetAll();
            if (allSubjects.Exists(s => s.SubjectName.Equals(subject.SubjectName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Tên môn học đã tồn tại");

            return subjectDAL.Insert(subject);
        }

        public bool UpdateSubject(SubjectDTO subject)
        {
            ValidateSubjectData(subject);

            // Kiểm tra môn học tồn tại
            SubjectDTO existingSubject = subjectDAL.GetSubjectByID(subject.SubjectID);
            if (existingSubject == null)
                throw new Exception("Môn học không tồn tại");

            // Kiểm tra tên môn học đã tồn tại chưa (trừ tên của chính môn học này)
            List<SubjectDTO> allSubjects = subjectDAL.GetAll();
            if (allSubjects.Exists(s => s.SubjectName.Equals(subject.SubjectName, StringComparison.OrdinalIgnoreCase) &&
                                       !s.SubjectID.Equals(subject.SubjectID)))
                throw new Exception("Tên môn học đã tồn tại");

            return subjectDAL.Update(subject);
        }

        public bool DeleteSubject(string subjectID)
        {
            if (string.IsNullOrEmpty(subjectID))
                throw new ArgumentException("Mã môn học không được để trống");

            // Kiểm tra môn học tồn tại
            SubjectDTO existingSubject = subjectDAL.GetSubjectByID(subjectID);
            if (existingSubject == null)
                throw new Exception("Môn học không tồn tại");

            // TODO: Kiểm tra các ràng buộc khác trước khi xóa (ví dụ: môn học đã có lớp học)

            return subjectDAL.Delete(subjectID);
        }

        private void ValidateSubjectData(SubjectDTO subject)
        {
            if (subject == null)
                throw new ArgumentNullException("Dữ liệu môn học không được để trống");

            if (string.IsNullOrEmpty(subject.SubjectID))
                throw new ArgumentException("Mã môn học không được để trống");

            if (string.IsNullOrEmpty(subject.SubjectName))
                throw new ArgumentException("Tên môn học không được để trống");

            if (subject.Credits <= 0)
                throw new ArgumentException("Số tín chỉ phải lớn hơn 0");
        }
    }
}
