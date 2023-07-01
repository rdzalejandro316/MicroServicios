using CQRS.Practico.Application.DTOs;
using MediatR;

namespace CQRS.Practico.Infrastructure.Queries
{
    public record GetAllTasksQuery  : IRequest<IEnumerable<TaskItemDto>>;
}
