using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;

namespace TodoApp.Features.Delete
{
    public static class DeleteTodo
    {
        public class Command : IRequest<bool>
        {
            public int TaskId { get; set; }
        }

        internal sealed class Handler : IRequestHandler<Command, bool>
        {
            private readonly TodoDbContext _context;

            public Handler(TodoDbContext context) => _context = context;

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var task = _context.TodoItems.FirstOrDefault(x => x.Id == request.TaskId);

                if (task == null)
                {
                    return false;
                }

                _context.Entry(task).State = EntityState.Deleted;

                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
        }
    }
}
