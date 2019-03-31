using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Domain_Models;

namespace WepApi.Services
{
    public class UnitOfWork :IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
        }
        public ApplicationDbContext Context { set; get; }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
