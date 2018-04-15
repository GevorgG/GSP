using System;
using OmniSenseNetwork.GSP.BLL.Interfaces;
using OmniSenseNetwork.GSP.Common.DataContracts;
using OmniSenseNetwork.GSP.DAL.Interfaces;

namespace OmniSenseNetwork.GSP.BLL.Core
{
    public class BLFactory : IBLFactory
    {
        #region Ctors
        public BLFactory()
        {
        }
        #endregion

        #region IBLFactory
        public IDalFactory DalFactory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IClientBL CreateClientBL(IClientDal dal, SessionInfo sessionInfo, bool isReadOnly = false)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}