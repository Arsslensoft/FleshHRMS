using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using PHRMS.Data;

namespace PHRMS.ViewModels
{
    partial class EmployeeCollectionViewModel
    {
        public int AllCount
        {
            get { return GetAllCount(); }
        }

        public int SalairedCount
        {
            get { return GetSalairedCount(); }
        }

        public int CommissionCount
        {
            get { return GetCommissionCount(); }
        }

        public int ProbationCount
        {
            get { return GetProbationCount(); }
        }

        public int TerminatedCount
        {
            get { return GetTerminatedCount(); }
        }

        public int OnLeaveCount
        {
            get { return GetOnLeaveCount(); }
        }

        public IList<FilterGroup> Filters { get; private set; }
        public virtual string ActiveFilterString { get; set; }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            Filters = new BindingList<FilterGroup>
            {
                new FilterGroup("Favorites"),
                new FilterGroup("Custom Filters"),
                new FilterGroup("Groups")
            };
        }

        private int GetOnLeaveCount()
        {
            return Entities.Where(e => e.Status == EmployeeStatus.OnLeave).Count();
        }

        private int GetTerminatedCount()
        {
            return Entities.Where(e => e.Status == EmployeeStatus.Terminated).Count();
        }

        private int GetProbationCount()
        {
            return Entities.Where(e => e.Status == EmployeeStatus.Contract).Count();
        }

        private int GetCommissionCount()
        {
            return Entities.Where(e => e.Status == EmployeeStatus.Commission).Count();
        }

        private int GetSalairedCount()
        {
            return Entities.Where(e => e.Status == EmployeeStatus.Salaried).Count();
        }

        private int GetAllCount()
        {
            return Entities.Count();
        }


        protected override void OnSelectedEntityChanged()
        {
            base.OnSelectedEntityChanged();
            this.RaiseCanExecuteChanged(x => x.ShowMap());
        }

        [Command]
        public void ShowMap()
        {
            DocumentManagerService.CreateDocument("MapView", null, SelectedEntity.Id, this).Show();
        }

        protected virtual void OnActiveFilterStringChanged()
        {
            if (ActiveFilterStringChanged != null)
            {
                ActiveFilterStringChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler ActiveFilterStringChanged;

        public class FilterTreeNode
        {
            public FilterTreeNode(string name)
            {
                Name = name;
            }

            public string Name { get; private set; }
        }

        public class FilterGroup : FilterTreeNode
        {
            private readonly BindingList<FilterTreeNode> itemsCore;

            public FilterGroup(string name)
                : base(name)
            {
                itemsCore = new BindingList<FilterTreeNode>();
                itemsCore.Add(new FilterItem("Item0"));
                itemsCore.Add(new FilterItem("Item1"));
            }

            public IList<FilterTreeNode> Items
            {
                get { return itemsCore; }
            }
        }

        public class FilterItem : FilterTreeNode
        {
            public FilterItem(string name)
                : base(name)
            {
            }

            public string FilterString { get; private set; }
        }
    }
}