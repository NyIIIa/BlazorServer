using BlazorServer.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Application.Estate.Queries.GetAll;

public class GetAllEstatesCommandHandler : IRequestHandler<GetAllEstatesRequest, IEnumerable<GetAllEstatesResponse>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetAllEstatesCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<GetAllEstatesResponse>> Handle(GetAllEstatesRequest request, CancellationToken cancellationToken)
    {
        //the best way to use AutoMapper 
        var getAllEstatesResponse = await _dbContext.Estates
            .Include(e => e.User)
            .Select(e => new GetAllEstatesResponse
                {
                    Id = e.Id,
                    Title = e.Title,
                    CurrentPrice = e.CurrentPrice,
                    DateOfPurchase = e.DateOfPurchase,
                    InitialPrice = e.InitialPrice,
                    PriceReduction = e.PriceReduction,
                    PeriodOfPriceReduction = e.PeriodOfPriceReduction,
                    Type = e.Type,
                    UserName = e.User.Name
                }).ToListAsync(cancellationToken);

        return getAllEstatesResponse;
    }
}