using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Region.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        TEntity GetById(int id);
        int Save(TEntity tEntity);
        bool Update(TEntity tEntity);
        bool Delete(int id);
        bool DropTables();
        bool EnsureCreated();
    }
}
