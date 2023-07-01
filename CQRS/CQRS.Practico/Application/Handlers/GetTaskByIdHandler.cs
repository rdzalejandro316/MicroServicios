using AutoMapper;
using CQRS.Practico.Application.DTOs;
using CQRS.Practico.Infrastructure;
using CQRS.Practico.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Practico.Application.Handlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetTasksByIdQuery, TaskItemDto>
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskByIdHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<TaskItemDto> Handle(GetTasksByIdQuery request, CancellationToken cancellationToken)
        {
            var taskItem = await _dbContext.taskItems.FirstOrDefaultAsync(c => c.Id == request.id);
            return _mapper.Map<TaskItemDto>(taskItem);
        }
    }
}
