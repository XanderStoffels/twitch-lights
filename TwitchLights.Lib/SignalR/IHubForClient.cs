using System.Threading.Tasks;

namespace TwitchLights.Lib.SignalR
{
    public interface IHubForClient
    {
       Task Subscribe(string channel);
       Task Unsubscribe(string channel);
    }
}
