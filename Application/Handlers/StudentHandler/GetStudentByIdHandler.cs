using Application.Mapper.MapStudent;
using Domain.Command.Queries.StudentsQueries;
using Domain.DTOs.StudentDTOs;
using Infrastructure.Repository;
using MediatR;

namespace Application.Handlers.StudentHandler
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentsByIdQuery, ViewStudentDTO>
    {
        private readonly IStudentRepository _repo;

        public GetStudentByIdHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<ViewStudentDTO> Handle(GetStudentsByIdQuery request, CancellationToken cancellationToken)
        {
            var viewById = await _repo.GetStudentByIdAsync(request.id);
            return viewById?.ToDto();
        }
    }
}
