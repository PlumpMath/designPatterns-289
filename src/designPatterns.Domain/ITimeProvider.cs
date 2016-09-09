using System;

namespace designPatterns.Domain
{
    public interface ITimeProvider
    {
        DateTime Now();
    }
}