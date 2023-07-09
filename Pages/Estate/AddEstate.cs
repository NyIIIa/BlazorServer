using BlazorServer.Application.Estate.Commands.Add;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages.Estate;

public partial class AddEstate
{
    public AddEstateRequest AddEstateRequest { get; set; } = new AddEstateRequest();
    [Inject]
    public ISender sender { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    
    protected async void CreateEstate()
    {
        await sender.Send(AddEstateRequest);
        NavigationManager.NavigateTo("/estates");
    }
    void Cancel()
    {
        NavigationManager.NavigateTo("/estates");
    }
}