using Domain.DTOs.StudentDTOs;
using MediatR;

namespace Domain.Queries
{
    public class GetFilteredStudentQuery : IRequest<IEnumerable<ViewStudentDTO>>
    {
        public string? SearchTerm { get; set; }
        public string? SortBy { get; set; }
        public bool IsDescending { get; set; }
    }
}
