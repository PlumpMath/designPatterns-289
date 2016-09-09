using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designPatterns.Domain.DesignPattern.BridgePattern
{
    public interface IVideoSource
    {
        string GetTvGuide();
        string PlayVideo();
    }
}
