using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Enums;
using TodoApp.Models;

namespace TodoApp.Features.Get;

public static class GetTodos
{
    public class Query : IRequest<IEnumerable<TodoResponse>> 
    {
        public string TaskState { get; set; } = string.Empty;
    }

    internal sealed class Handler : IRequestHandler<Query, IEnumerable<TodoResponse>>
    {
        private readonly TodoDbContext _context;

        public Handler(TodoDbContext context) => _context = context;

        public async Task<IEnumerable<TodoResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            IQueryable<TodoResponse> tasks = _context.TodoItems
                                                .Select(item => new TodoResponse
                                                {
                                                    Id = item.Id,
                                                    Title = item.Title,
                                                    WasCompleted = item.WasCompleted,
                                                    ItemCssClass = item.WasCompleted ? "completed" : string.Empty
                                                });

            if (string.IsNullOrEmpty(request.TaskState))
                return await tasks.ToListAsync(cancellationToken);

            bool state = request.TaskState.Equals(TaskState.Completed.ToString());

            return await tasks
                    .Where(task => task.WasCompleted == state)
                    .ToListAsync(cancellationToken);
        }
    }
}
