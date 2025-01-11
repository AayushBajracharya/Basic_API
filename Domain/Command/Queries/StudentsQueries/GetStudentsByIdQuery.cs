using Domain.DTOs.StudentDTOs;
using MediatR;

namespace Domain.Command.Queries.StudentsQueries
{
    public record GetStudentsByIdQuery(int id) : IRequest<ViewStudentDTO>;
}
