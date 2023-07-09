using BlazorServer.Domain.Exceptions.Generic;

namespace BlazorServer.Domain.Exceptions.User;

public class ConflictUserNameException : ConflictDataException
{
    public ConflictUserNameException(string message) : base(message) { }
}