using System.Collections.Generic;

namespace designPatterns.Domain.DesignPattern.visitorPattern
{
    public class MusicLibrary {
        public List<Song> Songs = new List<Song>
        {
            new Song("Pajarillos", "Marcos Vidal", "Christian"),
            new Song("La Casa de Dios", "Danilo Montero", "Christian"),
            new Song("Chandelier", "Sia", "Pop/Rock")
        };

        public List<Song> Accept(IMusicVisitor visitor)
        {
            return visitor.Visit(Songs);
        }
    }
}
