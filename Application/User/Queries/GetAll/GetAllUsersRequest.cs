using MediatR;

namespace BlazorServer.Application.User.Queries.GetAll;

public record GetAllUsersRequest() : IRequest<IEnumerable<GetAllUsersResponse>>;