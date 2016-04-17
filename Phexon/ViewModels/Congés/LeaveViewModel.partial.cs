using System;
using System.Linq;
using PHRMS.Data;

namespace PHRMS.ViewModels
{
    partial class LeaveViewModel : IBaseViewModel
    {
        public new bool IsNew()
        {
            return base.IsNew();
        }

        public IQueryable<Employee> GetEmployees()
        {
            return UnitOfWork.Employees.GetEntities();
        }

        public Leave CreateLeave()
        {
            return CreateEntity();
        }

        public event EventHandler EntityChanged;

        protected override void OnEntityChanged()
        {
            base.OnEntityChanged();
            var handler = EntityChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        internal Employee FindEmployeeId(Employee employee)
        {
            if (employee == null) return null;
            return UnitOfWork.Employees.Find(employee.Id);
        }

        protected override string GetTitle()
        {
            if (Entity.Owner != null) return Entity.Owner.FullName;
            return string.Empty;
        }
    }
}