using System;

namespace OmniSenseNetwork.GSP.Common.Exceptions
{
    public class DalException : Exception
    {
        #region Ctors
        public DalException()
        {
        }

        public DalException(string message)
            : base(message)
        {
        }

        public DalException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        #endregion
    }
}
