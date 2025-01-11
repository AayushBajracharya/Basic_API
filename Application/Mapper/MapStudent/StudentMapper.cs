using System.Reflection;
using Domain.DTOs.StudentDTOs;
using Domain.Entities;

namespace Application.Mapper.MapStudent
{
    public static class StudentMapper
    {
        public static ViewStudentDTO ToDto(this Student students)
        {
            return new ViewStudentDTO
            {
                StudentId = students.StudentId,
                Name = students.Name,
                FatherName = students.FatherName,
                MotherName = students.MotherName,
                Gender = students.Gender,
                DoB = students.DoB,
                Email = students.Email,
                Faculty = students.Faculty,
                Semester = students.Semester,
                PhoneNo = students.PhoneNo
            };
        }

        public static Student ToEntity(this CreateStudentDTO dto)
        {
            return new Student
            {
                Name = dto.Name,
                FatherName = dto.FatherName,
                MotherName = dto.MotherName,
                Gender = dto.Gender,
                DoB = dto.DoB,
                Email = dto.Email,
                Password = dto.Password,
                Faculty = dto.Faculty,
                Semester = dto.Semester,
                PhoneNo = dto.PhoneNo
            };
        }

        public static Student ToEntity(this UpdateStudentDTO dto, Student existingEntity)
        {
            existingEntity.Name = dto.Name;
            existingEntity.FatherName = dto.FatherName;
            existingEntity.MotherName = dto.MotherName;
            existingEntity.Gender = dto.Gender;
            existingEntity.DoB = dto.DoB;
            existingEntity.Email = dto.Email;
            existingEntity.Password = dto.Password;
            existingEntity.Faculty = dto.Faculty;
            existingEntity.Semester = dto.Semester;
            existingEntity.PhoneNo = dto.PhoneNo;
            return existingEntity;
        }
    }
}
