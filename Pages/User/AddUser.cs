using BlazorServer.Application.User.Commands.Add;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages.User;

public partial class AddUser
{
    public AddUserRequest AddUserRequest { get; set; } = new AddUserRequest();
    [Inject]
    public ISender sender { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    
    protected async void CreateEmployee()
    {
        await sender.Send(AddUserRequest);
        NavigationManager.NavigateTo("/users");
    }
    void Cancel()
    {
        NavigationManager.NavigateTo("/users");
    }
}