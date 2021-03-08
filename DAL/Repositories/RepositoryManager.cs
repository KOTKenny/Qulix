using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private DataManager _dataManager;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;
        private ICompanyTypeRepository _companyTypeRepository;
        private IEmployeeTypeRepository _employeeTypeRepository;
        public RepositoryManager(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public ICompanyRepository Company
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new CompanyRepository(_dataManager);

                return _companyRepository;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_dataManager);

                return _employeeRepository;
            }
        }

        public ICompanyTypeRepository CompanyType
        {
            get
            {
                if (_companyTypeRepository == null)
                    _companyTypeRepository = new CompanyTypeRepository(_dataManager);

                return _companyTypeRepository;
            }
        }

        public IEmployeeTypeRepository EmployeeType
        {
            get
            {
                if (_employeeTypeRepository == null)
                    _employeeTypeRepository = new EmployeeTypeRepository(_dataManager);

                return _employeeTypeRepository;
            }
        }
    }
}
