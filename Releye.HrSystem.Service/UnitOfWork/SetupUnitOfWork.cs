using GoTech.Framework.Pagination;
using Releye.HrSystem.Data.Entity;
using Releye.HrSystem.Data.Utils;
using Releye.HrSystem.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Releye.HrSystem.Service.UnitOfWork
{
    public class SetupUnitOfWork : AppBaseUnitOfWork
    {
        #region Employees
        public IList<Employee> getEmployeeList(EmployeeSearch search)
        {
            var qry = EmployeeRepository.Table;
            if (!string.IsNullOrEmpty(search.Name))
                qry = qry.Where(a => a.Name.Contains(search.Name));


            qry = qry.OrderBy(a => a.ID);
            PagedList<Employee> list = new PagedList<Employee>(qry, search);
            return list;
        }
        public void AddEmployee(Employee employee)
        {
            EmployeeRepository.Insert(employee);
            Save();
        }

        public void EditEmployee(Employee employee)
        {
            EmployeeRepository.Update(employee);
            Save();
        }

        public void DeleteEmployee(long ID)
        {
            EmployeeRepository.Delete(ID);
            Save();
        }
        #endregion

        #region Author
        public IList<Domain> getListOfDomains(Constants.DomainKeys Key)
        {
            return DomainRepository.Table.Where(a => a.Key == Key.ToString()).ToList();
        }
        #endregion
    }
}
