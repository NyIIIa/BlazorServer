using MediatR;

namespace BlazorServer.Application.Estate.Queries.GetAll;

public record GetAllEstatesRequest() : IRequest<IEnumerable<GetAllEstatesResponse>>;