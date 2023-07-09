using BlazorServer.Domain.Enums;
using MediatR;

namespace BlazorServer.Application.Estate.Commands.Add;


public record AddEstateRequest : IRequest<AddEstateResponse>
{
    public string Title { get; set; }
    public string UserName { get; set; }
    public EstateType Type { get; set; }
    public DateTime DateOfPurchase { get; set; }
    public decimal InitialPrice { get; set; }
    public Period PeriodOfPriceReduction { get; set; }
}