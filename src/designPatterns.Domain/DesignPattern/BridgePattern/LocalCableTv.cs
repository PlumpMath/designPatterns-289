namespace designPatterns.Domain.DesignPattern.BridgePattern
{
    public class LocalCableTv : IVideoSource
    {
        const string SourceName = "Local Cabel TV";

        public string GetTvGuide()
        {
            return string.Format("Getting TV guide from - {0}", SourceName); ;
        }

        public string PlayVideo()
        {
            return string.Format("Playing - {0}", SourceName);
        }
    }
}