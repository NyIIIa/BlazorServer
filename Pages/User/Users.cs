using BlazorServer.Application.User.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages.User;


public partial class Users
{
    [Inject]
    private ISender sender { get; set; }

    public IEnumerable<GetAllUsersResponse> _users { get; set; } = new List<GetAllUsersResponse>();
    
    protected override async Task OnInitializedAsync()
    {
        var users = await sender.Send(new GetAllUsersRequest());
        
        _users = users;
    }
}