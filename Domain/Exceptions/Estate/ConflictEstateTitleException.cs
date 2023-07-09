using BlazorServer.Domain.Exceptions.Generic;

namespace BlazorServer.Domain.Exceptions.Estate;

public class ConflictEstateTitleException : ConflictDataException
{
    public ConflictEstateTitleException(string message) : base(message) { }
}