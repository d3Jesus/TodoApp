using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;

namespace TodoApp.Features.Get;

public static class GetTodos
{
    public class Query : IRequest<IEnumerable<TodoResponse>> { }

    internal sealed class Handler : IRequestHandler<Query, IEnumerable<TodoResponse>>
    {
        private readonly TodoDbContext _context;

        public Handler(TodoDbContext context) => _context = context;

        public async Task<IEnumerable<TodoResponse>> Handle(Query request, CancellationToken cancellationToken)
            => await _context.TodoItems
                .Select(item => new TodoResponse
                {
                    Id = item.Id,
                    Title = item.Title,
                    WasCompleted = item.WasCompleted,
                    ItemCssClass = item.WasCompleted ? "completed" : string.Empty
                })
                .ToListAsync(cancellationToken);
    }
}
