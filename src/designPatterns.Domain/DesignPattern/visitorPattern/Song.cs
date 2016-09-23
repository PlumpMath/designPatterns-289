namespace designPatterns.Domain.DesignPattern.visitorPattern
{
    public class Song {
        public string Genre { get; protected set; }
        public string Name { get; protected set; }
        public string Band { get; protected set; }

        public Song(string name, string band, string genre) {
            Name = name;
            Genre = genre;
            Band = band;
        }
    }
}