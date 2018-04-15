using OmniSenseNetwork.GSP.Common.Helpers;

namespace OmniSenseNetwork.GSP.BLL.Redis
{
    public sealed class RedisEventType : TypeSafeCollection
    {
        public static readonly RedisEventType Expired = new RedisEventType("expired");

        private RedisEventType(string name)
            :base(name)
        {
        }
    }
}
