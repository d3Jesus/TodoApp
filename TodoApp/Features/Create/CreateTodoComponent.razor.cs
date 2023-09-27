using MediatR;
using Microsoft.AspNetCore.Components;

namespace TodoApp.Features.Create
{
    public partial class CreateTodoComponent
    {
        [Inject]
        private NavigationManager? NavigationManager { get; set; }
        [Inject]
        private ISender? Sender { get; set; }
        private CreateTodo.Command request { get; set; } = new();

        async Task HandleSubmitAsync()
        {
            await Sender!.Send(request);

            NavigationManager!.NavigateTo("/", true);
        }
    }
}
