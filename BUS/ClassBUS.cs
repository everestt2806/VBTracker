using System;
using System.Collections.Generic;
using VBTracker.DAL;
using VBTracker.DTO;

namespace VBTracker.BUS
{
    public class ClassBUS
    {
        private ClassDAL classDAL;
        private SubjectDAL subjectDAL;
        private SemesterDAL semesterDAL;
        private LecturerDAL lecturerDAL;

        public ClassBUS()
        {
            classDAL = new ClassDAL();
            subjectDAL = new SubjectDAL();
            semesterDAL = new SemesterDAL();
            lecturerDAL = new LecturerDAL();
        }

        public List<ClassDTO> GetAllClasses()
        {
            return classDAL.GetAllClasses();
        }

        public List<ClassDTO> GetClassesByLecturerID(string lecturerID)
        {
            if (string.IsNullOrEmpty(lecturerID))
                throw new ArgumentException("Mã giảng viên không được để trống");

            return classDAL.GetClassesByLecturerID(lecturerID);
        }

        public List<ClassDTO> GetClassesByStudentID(string studentID)
        {
            if (string.IsNullOrEmpty(studentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            return classDAL.GetClassesByStudentID(studentID);
        }

        public ClassDTO GetClassByID(string classID)
        {
            if (string.IsNullOrEmpty(classID))
                throw new ArgumentException("Mã lớp học không được để trống");

            return classDAL.GetClassByID(classID);
        }

        public bool AddClass(ClassDTO classDTO)
        {
            ValidateClassData(classDTO);

            // Kiểm tra mã lớp học đã tồn tại chưa
            if (classDAL.GetClassByID(classDTO.ClassID) != null)
                throw new Exception("Mã lớp học đã tồn tại");

            // Kiểm tra môn học tồn tại
            if (subjectDAL.GetSubjectByID(classDTO.SubjectID) == null)
                throw new Exception("Môn học không tồn tại");

            // Kiểm tra học kỳ tồn tại
            if (semesterDAL.GetSemesterByID(classDTO.SemesterID) == null)
                throw new Exception("Học kỳ không tồn tại");

            // Kiểm tra giảng viên tồn tại
            if (lecturerDAL.GetLecturerByID(classDTO.LecturerID) == null)
                throw new Exception("Giảng viên không tồn tại");

            return classDAL.Insert(classDTO);
        }

        public bool UpdateClass(ClassDTO classDTO)
        {
            ValidateClassData(classDTO);

            // Kiểm tra lớp học tồn tại
            ClassDTO existingClass = classDAL.GetClassByID(classDTO.ClassID);
            if (existingClass == null)
                throw new Exception("Lớp học không tồn tại");

            // Kiểm tra môn học tồn tại
            if (subjectDAL.GetSubjectByID(classDTO.SubjectID) == null)
                throw new Exception("Môn học không tồn tại");

            // Kiểm tra học kỳ tồn tại
            if (semesterDAL.GetSemesterByID(classDTO.SemesterID) == null)
                throw new Exception("Học kỳ không tồn tại");

            // Kiểm tra giảng viên tồn tại
            if (lecturerDAL.GetLecturerByID(classDTO.LecturerID) == null)
                throw new Exception("Giảng viên không tồn tại");

            return classDAL.Update(classDTO);
        }

        public bool DeleteClass(string classID)
        {
            if (string.IsNullOrEmpty(classID))
                throw new ArgumentException("Mã lớp học không được để trống");

            // Kiểm tra lớp học tồn tại
            ClassDTO existingClass = classDAL.GetClassByID(classID);
            if (existingClass == null)
                throw new Exception("Lớp học không tồn tại");

            // TODO: Kiểm tra các ràng buộc khác trước khi xóa (ví dụ: lớp học đã có sinh viên đăng ký)

            return classDAL.Delete(classID);
        }

        private void ValidateClassData(ClassDTO classDTO)
        {
            if (classDTO == null)
                throw new ArgumentNullException("Dữ liệu lớp học không được để trống");

            if (string.IsNullOrEmpty(classDTO.ClassID))
                throw new ArgumentException("Mã lớp học không được để trống");

            if (string.IsNullOrEmpty(classDTO.SubjectID))
                throw new ArgumentException("Mã môn học không được để trống");

            if (string.IsNullOrEmpty(classDTO.SemesterID))
                throw new ArgumentException("Mã học kỳ không được để trống");

            if (string.IsNullOrEmpty(classDTO.LecturerID))
                throw new ArgumentException("Mã giảng viên không được để trống");

            if (string.IsNullOrEmpty(classDTO.ClassName))
                throw new ArgumentException("Tên lớp học không được để trống");

            if (classDTO.MaxStudents <= 0)
                throw new ArgumentException("Số lượng sinh viên tối đa phải lớn hơn 0");
        }
    }
}
