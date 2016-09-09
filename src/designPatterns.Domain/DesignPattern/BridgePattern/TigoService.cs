namespace designPatterns.Domain.DesignPattern.BridgePattern
{
    public class TigoService : IVideoSource
    {
        const string SourceName = "Tigo TV";

        public string GetTvGuide()
        {
            return string.Format("Getting TV guide from - {0}", SourceName);
        }

        public string PlayVideo()
        {
            return string.Format("Playing - {0}", SourceName);
        }
    }
}