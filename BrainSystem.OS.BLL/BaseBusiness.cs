using BrainSystem.OS.BLL.Interface;
using System;
using System.Collections.Generic;

namespace BrainSystem.OS.BLL
{
    public class BaseBusiness<TEntity> : IDisposable, IBaseBusiness<TEntity> where TEntity : class
    {




        public void Add(TEntity obj)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
