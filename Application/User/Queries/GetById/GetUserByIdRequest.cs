using MediatR;

namespace BlazorServer.Application.User.Queries.GetById;

public record GetUserByIdRequest(int UserId) : IRequest<GetUserByIdResponse>;