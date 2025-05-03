using System;
using System.Collections.Generic;
using VBTracker.DAL;
using VBTracker.DTO;

namespace VBTracker.BUS
{
    public class GradeBUS
    {
        private GradeDAL gradeDAL;
        private StudentDAL studentDAL;
        private ClassDAL classDAL;
        private LecturerDAL lecturerDAL;

        public GradeBUS()
        {
            gradeDAL = new GradeDAL();
            studentDAL = new StudentDAL();
            classDAL = new ClassDAL();
            lecturerDAL = new LecturerDAL();
        }

        public List<GradeDTO> GetGradesByClassID(string classID)
        {
            if (string.IsNullOrEmpty(classID))
                throw new ArgumentException("Mã lớp học không được để trống");

            return gradeDAL.GetGradesByClassID(classID);
        }

        public List<GradeDTO> GetGradesByStudentID(string studentID)
        {
            if (string.IsNullOrEmpty(studentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            return gradeDAL.GetGradesByStudentID(studentID);
        }

        public GradeDTO GetGradeByID(string gradeID)
        {
            if (string.IsNullOrEmpty(gradeID))
                throw new ArgumentException("Mã điểm không được để trống");

            return gradeDAL.GetById(gradeID);
        }

        public bool AddGrade(GradeDTO grade)
        {
            ValidateGradeData(grade);

            // Kiểm tra mã điểm đã tồn tại chưa
            if (gradeDAL.GetById(grade.GradeID) != null)
                throw new Exception("Mã điểm đã tồn tại");

            // Kiểm tra sinh viên tồn tại
            if (studentDAL.GetStudentByID(grade.StudentID) == null)
                throw new Exception("Sinh viên không tồn tại");

            // Kiểm tra lớp học tồn tại
            if (classDAL.GetClassByID(grade.ClassID) == null)
                throw new Exception("Lớp học không tồn tại");

            // Kiểm tra giảng viên chấm điểm tồn tại (nếu có)
            if (!string.IsNullOrEmpty(grade.GradedBy) && lecturerDAL.GetLecturerByID(grade.GradedBy) == null)
                throw new Exception("Giảng viên chấm điểm không tồn tại");

            return gradeDAL.Insert(grade);
        }

        public bool UpdateGrade(GradeDTO grade)
        {
            ValidateGradeData(grade);

            // Kiểm tra điểm tồn tại
            GradeDTO existingGrade = gradeDAL.GetById(grade.GradeID);
            if (existingGrade == null)
                throw new Exception("Điểm không tồn tại");

            // Kiểm tra sinh viên tồn tại
            if (studentDAL.GetStudentByID(grade.StudentID) == null)
                throw new Exception("Sinh viên không tồn tại");

            // Kiểm tra lớp học tồn tại
            if (classDAL.GetClassByID(grade.ClassID) == null)
                throw new Exception("Lớp học không tồn tại");

            // Kiểm tra giảng viên chấm điểm tồn tại (nếu có)
            if (!string.IsNullOrEmpty(grade.GradedBy) && lecturerDAL.GetLecturerByID(grade.GradedBy) == null)
                throw new Exception("Giảng viên chấm điểm không tồn tại");

            return gradeDAL.Update(grade);
        }

        public bool DeleteGrade(string gradeID)
        {
            if (string.IsNullOrEmpty(gradeID))
                throw new ArgumentException("Mã điểm không được để trống");

            // Kiểm tra điểm tồn tại
            GradeDTO existingGrade = gradeDAL.GetById(gradeID);
            if (existingGrade == null)
                throw new Exception("Điểm không tồn tại");

            return gradeDAL.Delete(gradeID);
        }

        // Tính điểm trung bình cho sinh viên trong một lớp học
        public decimal CalculateAverageGrade(string studentID, string classID)
        {
            if (string.IsNullOrEmpty(studentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            if (string.IsNullOrEmpty(classID))
                throw new ArgumentException("Mã lớp học không được để trống");

            List<GradeDTO> grades = gradeDAL.GetGradesByStudentID(studentID);
            grades = grades.FindAll(g => g.ClassID == classID);

            if (grades.Count == 0)
                return 0;

            decimal totalWeightedScore = 0;
            decimal totalWeight = 0;

            foreach (GradeDTO grade in grades)
            {
                decimal percentage = grade.Score / grade.MaxScore;
                totalWeightedScore += percentage * grade.Weight;
                totalWeight += grade.Weight;
            }

            if (totalWeight == 0)
                return 0;

            return Math.Round(totalWeightedScore / totalWeight * 10, 2); // Điểm thang 10
        }

        private void ValidateGradeData(GradeDTO grade)
        {
            if (grade == null)
                throw new ArgumentNullException("Dữ liệu điểm không được để trống");

            if (string.IsNullOrEmpty(grade.GradeID))
                throw new ArgumentException("Mã điểm không được để trống");

            if (string.IsNullOrEmpty(grade.StudentID))
                throw new ArgumentException("Mã sinh viên không được để trống");

            if (string.IsNullOrEmpty(grade.ClassID))
                throw new ArgumentException("Mã lớp học không được để trống");

            if (string.IsNullOrEmpty(grade.AssignmentType))
                throw new ArgumentException("Loại bài tập không được để trống");

            if (grade.Score < 0)
                throw new ArgumentException("Điểm số không được âm");

            if (grade.MaxScore <= 0)
                throw new ArgumentException("Điểm tối đa phải lớn hơn 0");

            if (grade.Weight <= 0)
                throw new ArgumentException("Trọng số phải lớn hơn 0");

            if (grade.Score > grade.MaxScore)
                throw new ArgumentException("Điểm số không được lớn hơn điểm tối đa");
        }
    }
}
