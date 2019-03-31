using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepApi.Domain_Models
{
    public interface IRepository<T> where T : class
    {
        #region General Functions
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Create(T entity,int cityId=0);

        void Update(T entity);

        void Delete(int id);
        #endregion
    }
}
