namespace OmniSenseNetwork.GSP.BLL.Redis
{
    public interface IRedisCoreBL
    {
        void SubscribeToKeySpaceNotifications(string key, IRedisCallbackBL bl);

        void SubscribeToKeyEventNotifications(RedisEventType eventType, IRedisCallbackBL bl);
    }
}
