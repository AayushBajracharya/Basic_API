using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Repository;

namespace Application.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _repo;

        public StudentServices(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Student>> GetAllStudentAsync()
        {
            return await _repo.GetAllStudentAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _repo.GetStudentByIdAsync(id);
        }

        public async Task<int> AddStudentAsync(Student student)
        {
            return await _repo.AddStudentAsync(student);
        }
    }
}
