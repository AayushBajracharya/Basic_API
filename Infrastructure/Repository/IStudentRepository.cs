using Domain.Entities;

namespace Infrastructure.Repository
{
    public interface IStudentRepository
    {
        //Task<IEnumerable<Student>> GetAllStudentAsync();
        Task<IQueryable<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<int> AddStudentAsync(Student student);
    }
}
