using System;
using OmniSenseNetwork.GSP.Common.DataContracts;
using OmniSenseNetwork.GSP.DAL.Interfaces;

namespace OmniSenseNetwork.GSP.BLL.Interfaces
{
    public interface IBLFactory
    {
        IDalFactory DalFactory { get; set; }

        IClientBL CreateClientBL(IClientDal dal, SessionInfo sessionInfo, bool isReadOnly = false);
    }
}
