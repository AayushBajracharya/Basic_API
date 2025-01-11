﻿namespace Domain.DTOs.StudentDTOs
{
    public class CreateStudentDTO
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Gender { get; set; }
        public DateTime DoB { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Faculty { get; set; }
        public string Semester { get; set; }
        public string PhoneNo { get; set; }
    }
}
