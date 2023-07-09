using BlazorServer.Domain.Enums;
using MediatR;

namespace BlazorServer.Application.Estate.Commands.Update;

public record UpdateEstateRequest : IRequest<UpdateEstateResponse>
{
    public string CurrentTitle { get; set; }
    public string NewTitle { get; set; }
    public EstateType NewType { get; set; }
    public DateTime NewDateOfPurchase { get; set; }
    public decimal NewInitialPrice { get; set; }
    public Period NewPeriodOfPriceReduction { get; set; }
}