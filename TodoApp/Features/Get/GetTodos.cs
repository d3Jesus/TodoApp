using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Features.Get;

public static class GetTodos
{
    public class Query : IRequest<IEnumerable<TodoItem>> { }

    internal sealed class Handler : IRequestHandler<Query, IEnumerable<TodoItem>>
    {
        private readonly TodoDbContext _context;

        public Handler(TodoDbContext context) => _context = context;

        public async Task<IEnumerable<TodoItem>> Handle(Query request, CancellationToken cancellationToken)
            => await _context.TodoItems.ToListAsync(cancellationToken);
    }
}
