using AutoMapper;
using CQRS.Practico.Application.DTOs;
using CQRS.Practico.Infrastructure;
using CQRS.Practico.Infrastructure.Commands;
using MediatR;

namespace CQRS.Practico.Application.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskItemDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateTaskHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<TaskItemDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = _dbContext.taskItems.FirstOrDefault(c => c.Id == request.id);
            if (taskItem == null) return null;
            

            taskItem.Title = request.title;
            taskItem.Description = request.description;
            taskItem.IsCompleted = request.isCompleted;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TaskItemDto>(taskItem);
        }


    }
}
