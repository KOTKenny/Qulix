using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QulixTest.DAL.Interfaces
{
    public interface IDataManager
    {
        //Метод для работы со стандартными запросами SQL (Нужен для GetAllData)
        DataSet QueryWithReturnData(string query);
        //Метод для работы со стандартными запросами SQL (Нужен для Create, Update, Delete)
        void QueryWithoutReturnData(SqlCommand commandIn, string query);

        //Методы работы с объектами
        void CreateData<T>(T entity);
        void DeleteData<T>(T entity);
        void UpdateData<T>(T entity) where T : new();

        //Методы получения данных
        DataSet GetAllData<T>(T entity, string orderBy, string direction, string whereField);
        DataSet GetAllDataWithWhere<T>(T entity, string orderBy, string direction, Dictionary<string, string> whereFields);
        dynamic GetDataBy<T>(T obj, string fieldName, string secondFieldName);
    }
}
