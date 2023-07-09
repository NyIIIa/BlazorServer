using BlazorServer.Application.Estate.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages.Estate;

public partial class UpdateEstate
{
    [Parameter]
    public string Id { get; set; }
    [Inject]
    public ISender sender { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public UpdateEstateRequest UpdateEstateRequest { get; set; } = new UpdateEstateRequest();
    
    protected async void Update()
    {
        await sender.Send(UpdateEstateRequest);
        NavigationManager.NavigateTo("/estates");
    }
    void Cancel()
    {
        NavigationManager.NavigateTo("/estates");
    }
}