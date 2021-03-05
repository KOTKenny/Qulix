using QulixTest.DAL.Attributes;
using QulixTest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace QulixTest.DAL
{
    public class DataManager : IDataManager
    {

        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }

        #region General Methods
        //Методы работы с Query.

        public void QueryWithoutReturnData(SqlCommand commandIn, string query)
        {
            //Используем контекст
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                //Открываем подключение
                connection.Open();
                var command = new SqlCommand();

                if (commandIn != null)
                {
                    command = commandIn;
                }

                command.CommandText = query;
                command.Connection = connection;

                command.ExecuteNonQuery(); //Выполняем команду без возврата данных
            }
        }

        //Аналогия с первым методом
        public DataSet QueryWithReturnData(string query)
        {
            var ds = new DataSet();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                connection.Open();

                var command = new SqlCommand { CommandText = query, Connection = connection };
                //Используем адаптер для команды
                var adapter = new SqlDataAdapter(command);
                //Заполняем DataSet данными
                adapter.Fill(ds);
            }

            return ds;
        }
        #endregion

        public void CreateData<T>(T entity)
        {
            Type type = entity.GetType();
            var tableName = type.GetProperty("TableName").GetValue(entity); //Получаем свойство TableName и находим его значение (для SqlQuery)
            var id = type.GetProperty("Id").GetValue(entity, null);
            var properties = type.GetProperties(); //Получаем все свойства
            var dataSetAttribute = typeof(DataSetAttribute); //TODO: разделить на Create/Update атрибуты
            var values = string.Empty; //для SqlQuery
            var fields = string.Empty; //для SqlQuery

            var command = new SqlCommand();

            foreach (PropertyInfo property in properties) //проходимся по свойствам
            {
                var value = property.GetValue(entity);
                var field = property.Name;

                var attributes = property.GetCustomAttributes(dataSetAttribute); //Проверяем соответствие атрибуту, чтобы понять какие поля можно изменять
                if (!attributes.Any())
                    continue;

                command.Parameters.AddWithValue("@" + field, value);
                fields += field + ",";
                values += "@" + field + ",";
            }

            var sql = String.Format("INSERT INTO {0} ({1}) VALUES({2})", tableName, fields.Remove(fields.Length - 1), values.Remove(values.Length - 1));
            this.QueryWithoutReturnData(command, sql);
        }

        public void DeleteData<T>(T entity)
        {
            var type = entity.GetType();
            var tableName = type.GetProperty("TableName").GetValue(entity, null);
            var id = type.GetProperty("Id").GetValue(entity, null);

            var sql = String.Format("DELETE FROM {1} WHERE Id = {0}", id, tableName);

            this.QueryWithoutReturnData(null, sql);
        }

        public DataSet GetAllData<T>(T entity, string orderBy, string direction, string whereField)
        {
            orderBy = orderBy ?? "Id";
            direction = direction ?? "Desc";

            var sql = string.Empty;

            var tableName = entity.GetType().GetProperty("TableName").GetValue(entity);

            if (whereField != null)
            {
                var whereFieldValue = entity.GetType().GetProperty(whereField).GetValue(entity);
                sql = String.Format("SELECT * FROM {0} WHERE {1} = '{2}' ORDER BY {3} {4}", tableName,
                    whereField, whereFieldValue, orderBy, direction);
            }
            else
            {
                sql = String.Format("SELECT * FROM {0} ORDER BY {1} {2}", tableName, orderBy, direction);
            }

            return QueryWithReturnData(sql);
        }

        public DataSet GetAllDataWithWhere<T>(T entity, string orderBy, string direction, Dictionary<string, string> whereFields)
        {
            orderBy = orderBy ?? "Id";
            direction = direction ?? "Desc";

            var sql = string.Empty;

            var tableName = entity.GetType().GetProperty("TableName").GetValue(entity);

            if (whereFields != null && whereFields.Count > 0)
            {
                var searchString = String.Empty;

                foreach (var searchParameter in whereFields)
                {
                    if (!string.IsNullOrEmpty(searchParameter.Value))
                    {
                        searchString = searchString + searchParameter.Key + " = '" + searchParameter.Value + "' AND ";
                    }
                }

                sql = String.Format("SELECT * FROM {0} WHERE {1} ORDER BY {2} {3}", tableName,
                    searchString.Remove(searchString.Length - 4), orderBy, direction);
            }
            else
            {
                sql = String.Format("SELECT * FROM {0} ORDER BY {1} {2}", tableName, orderBy, direction);
            }

            return QueryWithReturnData(sql);
        }

        public void UpdateData<T>(T entity) where T : new()
        {
            Type type = entity.GetType();
            var properties = type.GetProperties();
            var dateSetAttribute = typeof(DataSetAttribute);
            var id = type.GetProperty("Id").GetValue(entity, null);
            var tableName = type.GetProperty("TableName").GetValue(entity, null);

            var seter = String.Empty;

            var command = new SqlCommand();

            var oldEntity = new T();
            oldEntity.GetType().GetProperty("Id").SetValue(oldEntity, id, null);

            var oldEntityDB = new T();
            oldEntityDB = GetDataBy(oldEntity, "Id", null);

            //создаем sql & command
            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(entity, null);
                var field = property.Name;
                var oldValue = oldEntityDB.GetType().GetProperty(field).GetValue(oldEntityDB, null) ?? String.Empty;
                var attributes = property.GetCustomAttributes(dateSetAttribute, true);
                if (value != null && (oldValue.ToString() != value.ToString()) && field != "CreateDate" && attributes.Any())
                {
                    command.Parameters.AddWithValue("@" + field, value);
                    seter += field + "=@" + field + ",";
                }
                //если поле было проинициализировано && если поля изменились
                // && если поле не CreateDate && если помечено аттрибутом DateSetAttribute

            }

            if (seter.Length > 1)
            {
                var sql = String.Format("UPDATE {0} SET {1} WHERE ID = {2};", tableName, seter.Remove(seter.Length - 1), id);
                this.QueryWithoutReturnData(command, sql);
            }
        }

        public dynamic GetDataBy<T>(T obj, string fieldName, string secondFieldName)
        {
            Type type = obj.GetType();
            var properties = type.GetProperties();
            var tableName = type.GetProperty("TableName").GetValue(obj, null);

            var fields = String.Empty;
            var searchField = String.Empty;
            var searchValue = String.Empty;
            var secondSearchField = String.Empty;
            var secondSearchValue = String.Empty;
            var dataGetAttribute = typeof(DataGetAttribute);

            foreach (PropertyInfo property in properties)
            {
                var field = property.Name;
                var attributes = property.GetCustomAttributes(dataGetAttribute, true);
                if (!attributes.Any()) continue; //выбираем только те properties, которые помечены атрибутом DataGetAttribute
                fields += field + ",";
                if (field == fieldName) //Ищем поле по которому ищем информацию в БД
                {
                    searchField = field;
                    var prop = property.GetValue(obj, null);
                    searchValue = prop != null ? prop.ToString() : "";
                }
                if (secondFieldName != null) //Если нужно доп. поле для сортировки
                {
                    if (field == secondFieldName)
                    {
                        secondSearchField = field;
                        secondSearchValue = property.GetValue(obj, null).ToString();
                    }
                }
            }

            string sql;

            sql = secondFieldName != null ?
            String.Format("SELECT {1} FROM {3} WHERE {0} = \"{2}\" AND {4} = '{5}'", searchField, fields.Remove(fields.Length - 1), searchValue, tableName, secondSearchField, secondSearchValue)
            :
            String.Format("SELECT {1} FROM {3} WHERE {0} = '{2}' ", searchField, fields.Remove(fields.Length - 1), searchValue, tableName);

            var dataset = new DataSet();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand { CommandText = sql, Connection = connection };
                var adapter = new SqlDataAdapter { SelectCommand = command };

                adapter.Fill(dataset);

                foreach (PropertyInfo property in properties)
                {
                    var field = property.Name;
                    var attributes = property.GetCustomAttributes(dataGetAttribute, true);
                    if (!attributes.Any()) continue; //выбираем только те properties, которые помечены атрибутом DataBaseGetAttribute
                    if ((dataset.Tables.Count > 0) && (dataset.Tables[0].Rows.Count > 0) && dataset.Tables[0].Rows[0][field] != DBNull.Value)
                    {
                        property.SetValue(obj, dataset.Tables[0].Rows[0][field], null);
                    }
                }
            }

            return obj;
        }

    }
}