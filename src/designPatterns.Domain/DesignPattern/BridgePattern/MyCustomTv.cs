using System;

namespace designPatterns.Domain.DesignPattern.BridgePattern
{
    public class MyCustomTv
    {
        public IVideoSource VideoSource { get; set; }

        public MyCustomTv()
        {
            VideoSource = null;
        }

        public string ShowTvGuide()
        {
            return (VideoSource != null
                ? VideoSource.GetTvGuide()
                : "Please select a Video Source to get TV guide from");
        }

        public string PlayTv()
        {
            return (VideoSource != null
                ? VideoSource.PlayVideo() 
                : "Please select a Video Source to play");
        }
    }
}