using BlazorServer.Domain.Exceptions.Generic;

namespace BlazorServer.Domain.Exceptions.Estate;

public class EstateTitleNotFoundException : NotFoundException
{
    public EstateTitleNotFoundException(string message) : base(message) { }
}