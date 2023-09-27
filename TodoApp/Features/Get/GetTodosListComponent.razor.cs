using MediatR;
using Microsoft.AspNetCore.Components;

namespace TodoApp.Features.Get
{
    public partial class GetTodosListComponent
    {
        [Inject]
        private ISender? Sender { get; set; }

        private IEnumerable<TodoResponse>? tasks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var query = new GetTodos.Query();
            tasks = await Sender!.Send(query);
        }
    }
}
