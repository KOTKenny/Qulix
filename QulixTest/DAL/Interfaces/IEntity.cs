using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QulixTest.DAL.Interfaces
{
    //Описание стандартного класса
    public interface IEntity
    {
        Int32 Id { get; set; }
        String TableName { get; set; }

        void Create();
        void Delete(Int32 id);
        void Update();

        DataSet GetAllItems();
        DataSet GetAllItems(string orderBy, string direction, string whereField);
        dynamic GetById();
    }
}
