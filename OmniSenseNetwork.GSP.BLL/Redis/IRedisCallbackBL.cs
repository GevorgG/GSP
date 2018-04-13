namespace OmniSenseNetwork.GSP.BLL.Redis
{
    public interface IRedisCallbackBL
    {
        void HandleEvent(string param, string value);
    }
}
