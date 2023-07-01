using AutoMapper;
using CQRS.Practico.Application.DTOs;
using CQRS.Practico.Infrastructure;
using CQRS.Practico.Infrastructure.Commands;
using MediatR;

namespace CQRS.Practico.Application.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteTaskHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = _dbContext.taskItems.FirstOrDefault(c => c.Id == request.Id);
            if (taskItem == null) return false;

            _dbContext.taskItems.Remove(taskItem);
            int succes = await _dbContext.SaveChangesAsync(cancellationToken);
            return succes > 0 ? true : false;
        }
    }
}
