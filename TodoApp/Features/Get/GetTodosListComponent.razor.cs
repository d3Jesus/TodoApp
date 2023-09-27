using MediatR;
using Microsoft.AspNetCore.Components;
using TodoApp.Models;

namespace TodoApp.Features.Get
{
    public partial class GetTodosListComponent
    {
        [Inject]
        private ISender? Sender { get; set; }

        private IEnumerable<TodoItem> tasks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var query = new GetTodos.Query();
            tasks = await Sender!.Send(query);
        }
    }
}
