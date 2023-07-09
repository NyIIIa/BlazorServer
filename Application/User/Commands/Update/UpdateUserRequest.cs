using MediatR;

namespace BlazorServer.Application.User.Commands.Update;

public record UpdateUserRequest : IRequest<UpdateUserResponse>
{
    public string CurrentName { get; set; }
    public string NewName { get; set; }
    public string NewEmail { get; set; }
    public string NewPhoneNumber { get; set; }
}
