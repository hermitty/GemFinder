using System;

namespace GemFinder.Identity.Exceptions
{
    public interface IExceptionToMessageMapper
    {
        object Map(Exception exception, object message);
    }
}