using System;
namespace OmniSenseNetwork.GSP.Common.Exceptions
{
    public class BllException : Exception
    {
        #region Ctors
        public BllException()
        {
        }

        public BllException(string message)
            :base(message)
        {
        }

        public BllException(string message, Exception innerException)
            :base(message, innerException)
        {
        }
        #endregion
    }
}
