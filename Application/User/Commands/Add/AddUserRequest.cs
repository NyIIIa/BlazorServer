using MediatR;

namespace BlazorServer.Application.User.Commands.Add;

public class AddUserRequest : IRequest<AddUserResponse>
{
    public string Name { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    
}