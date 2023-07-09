using MediatR;

namespace BlazorServer.Application.Estate.Queries.GetById;

public record GetEstateByIdRequest(int EstateId) : IRequest<GetEstateByIdResponse>;