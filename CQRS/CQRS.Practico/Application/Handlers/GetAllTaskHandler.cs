using AutoMapper;
using CQRS.Practico.Application.DTOs;
using CQRS.Practico.Domain;
using CQRS.Practico.Infrastructure;
using CQRS.Practico.Infrastructure.Commands;
using CQRS.Practico.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Practico.Application.Handlers
{
    public class GetAllTaskHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskItemDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllTaskHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskItemDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<TaskItem> taskItem = await _dbContext.taskItems.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TaskItemDto>>(taskItem);
        }
    }

}
