using BlazorServer.Application.User.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages.User;

public partial class UpdateUser
{
    [Parameter]
    public string Id { get; set; }
    [Inject]
    public ISender sender { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public UpdateUserRequest UpdateUserRequest { get; set; } = new UpdateUserRequest();
    
    protected async void Update()
    {
        await sender.Send(UpdateUserRequest);
        NavigationManager.NavigateTo("/users");
    }
    void Cancel()
    {
        NavigationManager.NavigateTo("/users");
    }
    
}