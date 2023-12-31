using BlazorServer.Domain.Exceptions.Estate;
using BlazorServer.Domain.Exceptions.User;
using BlazorServer.Infrastructure.Interfaces;
using BlazorServer.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Application.Estate.Commands.Add;

public class AddEstateCommandHandler : IRequestHandler<AddEstateRequest, AddEstateResponse>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IUserEstateManager _userEstateManager;

    public AddEstateCommandHandler(ApplicationDbContext dbContext, IUserEstateManager userEstateManager)
    {
        _dbContext = dbContext;
        _userEstateManager = userEstateManager;
    }

    public async Task<AddEstateResponse> Handle(AddEstateRequest request, CancellationToken cancellationToken)
    {
        var isEstateTitleExists = await _dbContext.Estates.AnyAsync(e => e.Title == request.Title, cancellationToken);
        if (isEstateTitleExists)
        {
            // throw new Exception("The estate with specified title already exists!");
            throw new ConflictEstateTitleException("The estate with specified title already exists!");
        }

        var user = await _dbContext.Users
            .Include(u => u.Estates)
            .FirstOrDefaultAsync(u => u.Name == request.UserName, cancellationToken);
        if (user is null)
        {
            // throw new Exception("The owner(user) with specified name doesn't exists!");
            throw new UserNameNotFoundException("The owner(user) with specified name doesn't exists!");
        }

        var estateCurrentPrice = Domain.Entities.Estate.CalculateCurrentPrice(request.InitialPrice,
            request.DateOfPurchase, request.PeriodOfPriceReduction);
        var estatePriceReduction =
            Domain.Entities.Estate.CalculatePriceReduction(request.InitialPrice, estateCurrentPrice);
        var estate = new Domain.Entities.Estate()
        {
            Title = request.Title,
            User = user,
            Type = request.Type,
            DateOfPurchase = request.DateOfPurchase,
            InitialPrice = request.InitialPrice,
            PeriodOfPriceReduction = request.PeriodOfPriceReduction,
            CurrentPrice = estateCurrentPrice,
            PriceReduction = estatePriceReduction
        };

        await _dbContext.Estates.AddAsync(estate, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        await _userEstateManager.UpdateUserSumEstatesAsync(user.Name, cancellationToken);

        return new AddEstateResponse(estate.Id);
    }
}