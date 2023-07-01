using AutoMapper;
using CQRS.Practico.Application.DTOs;
using CQRS.Practico.Domain;
using CQRS.Practico.Infrastructure;
using CQRS.Practico.Infrastructure.Commands;
using MediatR;

namespace CQRS.Practico.Application.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, TaskItemDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateTaskHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TaskItemDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            //_dbContext

            var taskItem = new TaskItem
            {
                Title = request.title,
                Description = request.description,
                IsCompleted = false
            };

            _dbContext.taskItems.Add(taskItem);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TaskItemDto>(taskItem);
        }


    }
}
