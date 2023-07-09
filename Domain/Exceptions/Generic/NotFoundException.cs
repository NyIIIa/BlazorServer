namespace BlazorServer.Domain.Exceptions.Generic;

public class NotFoundException : Exception
{
    protected NotFoundException(string message) : base(message){}
}