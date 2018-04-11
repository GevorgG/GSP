using System;

namespace OmniSenseNetwork.GSP.Common
{
    public static class CommonUtils
    {
        public static class Exceptions
        {
            public static T CreateException<T>(string errorKey, string[] userData = null) where T : Exception
            {
                return CreateException<T>(new object[] { errorKey }, userData);
            }

            public static T CreateException<T>(string errorKey, Exception innnerException, string[] userData = null) where T : Exception
            {
                return CreateException<T>(new object[] { errorKey, innnerException }, userData);
            }

            private static T CreateException<T>(object[] data, string[] userData = null) where T : Exception
            {
                T exception = Activator.CreateInstance(typeof(T), data) as T;

                for (int i = 0; i < userData?.Length; i++)
                    exception.Data.Add(i, userData[i]);

                return exception;
            }
        }
    }
}
