using CQRS.Practico.Application.DTOs;
using MediatR;

namespace CQRS.Practico.Infrastructure.Commands
{
    public record UpdateTaskCommand(int id,string title,string description,bool isCompleted) 
        : IRequest<TaskItemDto>;

}
