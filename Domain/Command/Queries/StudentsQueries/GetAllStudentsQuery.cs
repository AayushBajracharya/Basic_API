using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.StudentDTOs;
using MediatR;

namespace Domain.Command.Queries.StudentsQueries
{
    public record GetAllStudentsQuery : IRequest<IEnumerable<ViewStudentDTO>>;

}
