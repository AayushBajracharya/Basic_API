using Domain.Command.Cmd.StudentCmd;
using Domain.Command.Queries.StudentsQueries;
using Domain.DTOs.StudentDTOs;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EFcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : BaseApiController
    {

        // AdminController.cs
        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredStudents([FromQuery] string? searchTerm, [FromQuery] string? sortBy, [FromQuery] bool isDescending = false)
        {
            var query = new GetFilteredStudentQuery
            {
                SearchTerm = searchTerm,
                SortBy = sortBy,
                IsDescending = isDescending
            };

            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudentAsync()
        {
            Logger.LogInformation($"{nameof(GetAllStudentAsync)} trigger function received a request with param query");
            var students = await Mediator.Send(new GetAllStudentsQuery());
            Logger.LogInformation($"{nameof(GetAllStudentAsync)}  trigger function returned a response");
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentAsync(CreateStudentDTO student)
        {
            Logger.LogInformation($"{nameof(AddStudentAsync)} trigger function received a request with param query");
            var id = await Mediator.Send(new CreateStudentCommand(student));
            Logger.LogInformation($"{nameof(AddStudentAsync)}  trigger function returned a response");
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            Logger.LogInformation($"{nameof(GetStudentByIdAsync)} trigger function received a request with param query");
            var getById = await Mediator.Send(new GetStudentsByIdQuery(id));
            Logger.LogInformation($"{nameof(GetStudentByIdAsync)}  trigger function returned a response");
            return getById != null ? Ok(getById) : NotFound();
        }

    }
}
