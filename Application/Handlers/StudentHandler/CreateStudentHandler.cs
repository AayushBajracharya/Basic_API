using Application.Mapper.MapStudent;
using Domain.Command.Cmd.StudentCmd;
using Infrastructure.Repository;
using MediatR;

namespace Application.Handlers.StudentHandler
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IStudentRepository _repo;

        public CreateStudentHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var insert = request.create.ToEntity();
            return await _repo.AddStudentAsync(insert);
        }
    }
}
