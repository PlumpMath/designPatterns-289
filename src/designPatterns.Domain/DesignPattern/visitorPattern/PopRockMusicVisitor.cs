using System.Collections.Generic;
using System.Linq;

namespace designPatterns.Domain.DesignPattern.visitorPattern
{
    public class PopRockMusicVisitor : IMusicVisitor
    {
        public List<Song> Songs { get; protected set; }

        public List<Song> Visit(List<Song> items)
        {
            Songs = items.Where(x => x.Genre == "Pop/Rock").ToList();
            return Songs;
        }
    }
}