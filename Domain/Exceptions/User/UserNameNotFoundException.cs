using BlazorServer.Domain.Exceptions.Generic;

namespace BlazorServer.Domain.Exceptions.User;

public class UserNameNotFoundException : NotFoundException
{
    public UserNameNotFoundException(string message) : base(message) { }
}