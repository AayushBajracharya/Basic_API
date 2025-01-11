using Domain.DTOs.StudentDTOs;
using MediatR;

namespace Domain.Command.Cmd.StudentCmd
{
    public record CreateStudentCommand(CreateStudentDTO create) : IRequest<int>;

}
