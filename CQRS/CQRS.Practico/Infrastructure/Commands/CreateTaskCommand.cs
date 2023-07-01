using CQRS.Practico.Application.DTOs;
using MediatR;

namespace CQRS.Practico.Infrastructure.Commands
{
    public record CreateTaskCommand(string title,string description): IRequest<TaskItemDto>;
    
}
