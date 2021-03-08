using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL.Interfaces
{
    public interface ICompanyTypeService
    {
        List<SelectListItem> GetCompanyTypes();
        List<SelectListItem> GetCompanyTypesToSortDDL();
    }
}
