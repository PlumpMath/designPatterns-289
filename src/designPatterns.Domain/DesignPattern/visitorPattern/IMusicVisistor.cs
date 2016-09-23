using System.Collections.Generic;

namespace designPatterns.Domain.DesignPattern.visitorPattern
{
    public interface IMusicVisitor
    {
        List<Song> Visit(List<Song> items);
    }
}