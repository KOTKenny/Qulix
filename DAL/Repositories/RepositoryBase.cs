using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        private DataManager DM;

        public RepositoryBase(DataManager dataManager)
        {
            DM = dataManager;
        }
        public void Create(T entity)
        {
            DM.CreateData(entity);
        }

        public void Delete(T entity)
        {
            DM.DeleteData(entity);
        }

        public DataSet GetAllItems(T entity)
        {
            return DM.GetDataByCondition(entity, null, null, null);
        }

        public DataSet GetItemsByCondition(T entity, string orderBy, string direction, Dictionary<string, string> whereFields)
        {
            return DM.GetDataByConditionWithMultiplyWhere(entity, orderBy, direction, whereFields);
        }

        public dynamic GetById(T entity)
        {
            return DM.GetDataBy(entity, "Id", null);
        }

        public void Update(T entity)
        {
            DM.UpdateData(entity);
        }

        public DataSet GetItemsByCondition(T entity, string orderBy, string direction, string whereField)
        {
            return DM.GetDataByCondition(entity, orderBy, direction, whereField);
        }
    }
}
