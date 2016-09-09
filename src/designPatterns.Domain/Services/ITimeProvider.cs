using System;

namespace designPatterns.Domain.Services
{
    public interface ITimeProvider
    {
        DateTime Now();
    }
}