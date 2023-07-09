using BlazorServer.Application.Estate.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages.Estate;

public partial class Estates
{
    [Inject]
    private ISender sender { get; set; }

    public IEnumerable<GetAllEstatesResponse> _estates { get; set; } = new List<GetAllEstatesResponse>();
    
    protected override async Task OnInitializedAsync()
    {
        var estates = await sender.Send(new GetAllEstatesRequest());

        _estates = estates;
    }
}