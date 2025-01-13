using Application.Mapper.MapStudent;
using Domain.DTOs.StudentDTOs;
using Domain.Queries;
using Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.StudentHandler
{
    public class GetFilteredStudentHandler : IRequestHandler<GetFilteredStudentQuery, IEnumerable<ViewStudentDTO>>
    {
        private readonly IStudentRepository _repository;

        public GetFilteredStudentHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ViewStudentDTO>> Handle(GetFilteredStudentQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetAllStudentAsync();  // Await here

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(p => p.Name.Contains(request.SearchTerm) || p.Email.Contains(request.SearchTerm));
            }

            if (!string.IsNullOrEmpty(request.SortBy))
            {
                query = request.IsDescending
                    ? query.OrderByDescending(p => EF.Property<object>(p, request.SortBy))
                    : query.OrderBy(p => EF.Property<object>(p, request.SortBy));
            }

            var result = query.ToList().Select(p => p.ToDto());
            return result;
        }

    }
}
