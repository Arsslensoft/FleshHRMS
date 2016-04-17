using System;
using System.Linq;
using PHRMS.Data;

namespace PHRMS.ViewModels
{
    partial class EmployeeViewModel : IBaseViewModel
    {
        protected override string GetTitle()
        {
            return Entity.FullName;
        }

        public IQueryable<Employee> GetEmployyes()
        {
            return UnitOfWork.Employees.GetEntities();
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
    }
}