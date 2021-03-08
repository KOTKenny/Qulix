using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    //Описание стандартного класса
    public interface IEntity
    {
        Int32 Id { get; set; }
        String TableName { get; set; }
    }
}
