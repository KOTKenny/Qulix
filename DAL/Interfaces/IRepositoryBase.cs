using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        void Delete(T entity);
        DataSet GetAllItems(T entity);
        DataSet GetItemsByCondition(T entity, string orderBy, string direction, Dictionary<string, string> whereFields);
        dynamic GetById(T entity);
        void Update(T entity);
        DataSet GetItemsByCondition(T entity, string orderBy, string direction, string whereField);
    }
}
