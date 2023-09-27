using MediatR;
using Microsoft.AspNetCore.Components;
using TodoApp.Features.ChangeState;
using TodoApp.Features.Delete;

namespace TodoApp.Features.Get
{
    public partial class GetTodosListComponent
    {
        [Inject]
        private NavigationManager? NavigationManager { get; set; }
        [Inject]
        private ISender? Sender { get; set; }

        private IEnumerable<TodoResponse>? tasks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var query = new GetTodos.Query();
            tasks = await Sender!.Send(query);
        }

        async Task ChangeTaskStateAsync(int taskId)
        {
            var command = new ChangeTaskState.Command() { TaskId = taskId };
            await Sender!.Send(command);
            NavigationManager!.NavigateTo("/", true);
        }

        async Task DeleteTaskAsync(int taskId)
        {
            var command = new DeleteTodo.Command() { TaskId = taskId };
            await Sender!.Send(command);
            NavigationManager!.NavigateTo("/", true);
        }
    }
}
