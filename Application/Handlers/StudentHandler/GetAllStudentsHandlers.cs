using Application.Mapper.MapStudent;
using Domain.Command.Queries.StudentsQueries;
using Domain.DTOs.StudentDTOs;
using Infrastructure.Repository;
using MediatR;

namespace Application.Handlers.StudentHandler
{
    public class GetAllStudentsHandlers : IRequestHandler<GetAllStudentsQuery, IEnumerable<ViewStudentDTO>>
    {
        private readonly IStudentRepository _repo;

        public GetAllStudentsHandlers(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ViewStudentDTO>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var views = await _repo.GetAllStudentAsync();
            return views.Select(p => p.ToDto());
        }
    }
}
