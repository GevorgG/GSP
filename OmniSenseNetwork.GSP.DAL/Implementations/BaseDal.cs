using System;
using OmniSenseNetwork.GSP.DAL.Entities;
using OmniSenseNetwork.GSP.DAL.Interfaces;

namespace OmniSenseNetwork.GSP.DAL.Repositories
{
    public class BaseDal : IBaseDal //TODO
    {
        #region Members
        private bool _isDisposed = false;
        #endregion

        #region Properties
        public bool IsChild { get; }
        public bool IsReadOnly { get; }
        protected GSPEntities Db { get; set; }
        #endregion

        #region Ctors
        public BaseDal(string connectionString = null, bool isReadOnly = false)
        {
            IsChild = false;
            IsReadOnly = isReadOnly;
            if (connectionString != null)
                connectionString.Trim();
            Db = string.IsNullOrEmpty(connectionString) ? new GSPEntities() : new GSPEntities(connectionString);
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
            {
                if (!IsChild)
                    Db.Dispose();

                Db = null;
            }

            _isDisposed = true;
        }
        #endregion
    }
}
