using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Services;

namespace WepApi.Domain_Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IUnitOfWork _unitOfWork;
        #region constructor
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion


        #region Create
        public virtual void Create(T entity,int cityId=0)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
            _unitOfWork.Commit();
        }
        #endregion


        #region Delete
        public void Delete(int id)
        {
            T entity =  GetById(id);
            _unitOfWork.Context.Set<T>().Remove(entity);
            _unitOfWork.Commit();
        }
        #endregion

        #region "GetAll"
        public IEnumerable<T> GetAll()
        {
           return  _unitOfWork.Context.Set<T>().ToList();
        }
        #endregion

        #region "GetById"
        public virtual T GetById(int id)
        {
            T entity = _unitOfWork.Context.Set<T>()
               .Find(id);
            return entity;
        }
        #endregion

        #region Update
        public void Update(T entity)
        {
            var x = _unitOfWork.Context.Set<T>().Update(entity);
            _unitOfWork.Commit();
        }
        #endregion
    }
}
