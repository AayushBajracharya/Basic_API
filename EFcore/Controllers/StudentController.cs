﻿using Azure;
using Domain.Command.Cmd.StudentCmd;
using Domain.Command.Queries.StudentsQueries;
using Domain.DTOs.StudentDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EFcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StudentController> _logger;


        public StudentController(IMediator mediator, ILogger<StudentController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentAsync()
        {
            _logger.LogInformation($"{nameof(GetAllStudentAsync)} trigger function received a request with param query");
            var students = await _mediator.Send(new GetAllStudentsQuery());
            _logger.LogInformation($"{nameof(GetAllStudentAsync)}  trigger function returned a response");
            return Ok(students);
        }


        [HttpPost]
        public async Task<IActionResult> AddStudentAsync(CreateStudentDTO student)
        {
            _logger.LogInformation($"{nameof(AddStudentAsync)} trigger function received a request with param query");
            var id = await _mediator.Send(new CreateStudentCommand(student));
            _logger.LogInformation($"{nameof(AddStudentAsync)}  trigger function returned a response");
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            _logger.LogInformation($"{nameof(GetStudentByIdAsync)} trigger function received a request with param query");
            var getById = await _mediator.Send(new GetStudentsByIdQuery(id));
            _logger.LogInformation($"{nameof(GetStudentByIdAsync)}  trigger function returned a response");
            return getById != null ? Ok(getById) : NotFound();
        }

    }
}
