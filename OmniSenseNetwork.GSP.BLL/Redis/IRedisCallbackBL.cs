using System;
namespace OmniSenseNetwork.GSP.BLL.Redis
{
    public interface IRedisCallbackBL
    {
        void HandleEvent(string eventType, string value);
    }
}
