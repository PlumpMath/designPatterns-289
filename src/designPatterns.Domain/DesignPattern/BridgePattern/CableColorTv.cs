namespace designPatterns.Domain.DesignPattern.BridgePattern
{
    public class CableColorTv : IVideoSource
    {
        const string SourceName = "Cable Color TV";

        string IVideoSource.GetTvGuide()
        {
            return string.Format("Getting TV guide from - {0}", SourceName);
        }

        string IVideoSource.PlayVideo()
        {
            return string.Format("Playing - {0}", SourceName);
        }
    }
}