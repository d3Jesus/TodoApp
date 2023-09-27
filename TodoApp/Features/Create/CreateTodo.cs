using MediatR;
using System.ComponentModel.DataAnnotations;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Features.Create
{
    public static class CreateTodo
    {
        public class Command : IRequest<bool>
        {
            [Required(ErrorMessage = "This field is required.")]
            [StringLength(50, ErrorMessage = "This field only allows {1} characters.")]
            public string Title { get; set; } = string.Empty;
        }

        internal sealed class Handler : IRequestHandler<Command, bool>
        {
            private readonly TodoDbContext _context;

            public Handler(TodoDbContext context) => _context = context;

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var itemsCount = _context.TodoItems.Count();

                TodoItem item = new()
                {
                    Id = itemsCount + 1,
                    Title = request.Title
                };

                _context.TodoItems.Add(item);

                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
        }
    }
}
