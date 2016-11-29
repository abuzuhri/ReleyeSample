using GoTech.Framework;
using Releye.HrSystem.Data.Context;
using Releye.HrSystem.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Releye.HrSystem.Service.UnitOfWork
{
    public class AppBaseUnitOfWork : BaseGoTechUnitOfWork
    {
        public BaseDataRepository<Employee> EmployeeRepository { get; set; }
        public BaseDataRepository<Dependent> DependentRepository { get; set; }
        public BaseDataRepository<Domain> DomainRepository { get; set; }

        public AppBaseUnitOfWork()  : base(new MainContext())
        {
            EmployeeRepository = this.Repository<Employee>();
            DependentRepository = this.Repository<Dependent>();
            DomainRepository = this.Repository<Domain>();

        }
    }
}
