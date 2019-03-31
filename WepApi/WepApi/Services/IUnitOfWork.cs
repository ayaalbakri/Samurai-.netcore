using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Domain_Models;

namespace WepApi.Services
{
    public interface IUnitOfWork : IDisposable
    {
        #region Context
        ApplicationDbContext Context { set; get; }
        #endregion

        #region commit changes
        void Commit();
        #endregion
    }
}
