namespace DevExpress.DevAV.ViewModel {
    using System;
    using DevExpress.DevAV.Common.DataModel;
    using DevExpress.DevAV.Common.ViewModel;
    using DevExpress.Mvvm;

    public abstract class ReportViewModelBase<TReportType> : ISupportParameter
        where TReportType : struct {
        public virtual TReportType ReportType { get; set; }
        protected virtual void OnReportTypeChanged() {
            RaiseReportTypeChanged();
        }
        public event EventHandler ReportTypeChanged;
        private void RaiseReportTypeChanged() {
            EventHandler handler = ReportTypeChanged;
            if(handler != null) {
                handler(this, EventArgs.Empty);
            }
        }
        object ISupportParameter.Parameter {
            get {
                return ReportType;
            }
            set {
                ReportType = (TReportType)value;
                OnParameterChanged();
            }
        }
        protected virtual void OnParameterChanged() {
        }
    }
    public class ReportViewModelBase<TReportType, TEntity, TPrimaryKey, TUnitOfWork> : ReportViewModelBase<TReportType>
        where TReportType : struct
        where TEntity : class
        where TUnitOfWork : class, IUnitOfWork {
        protected override void OnParameterChanged() {
            base.OnParameterChanged();
            CheckReportEntityKey();
        }
        public virtual object ReportEntityKey { get; set; }
        protected virtual void OnReportEntityKeyChanged() {
            RaiseReportEntityKeyChanged();
        }
        public event EventHandler ReportEntityKeyChanged;
        private void RaiseReportEntityKeyChanged() {
            EventHandler handler = ReportEntityKeyChanged;
            if(handler != null) {
                handler(this, EventArgs.Empty);
            }
        }
        public void OnLoad() {
            CheckReportEntityKey();
        }
        private void CheckReportEntityKey() {
            ReportEntityKey = GetSelectedEntityKey();
        }
        public TPrimaryKey GetSelectedEntityKey() {
            var collectionViewModel = GetCollectionViewModel();
            if(collectionViewModel != null) {
                return collectionViewModel.SelectedEntityKey;
            }
            var so = GetSingleObjectViewModel();
            if(so != null) return so.EntityKey;
            return default(TPrimaryKey);

        }
        protected CollectionViewModel<TEntity, TPrimaryKey, TUnitOfWork> GetCollectionViewModel() {
            var supportParent = this as ISupportParentViewModel;
            if(supportParent != null) {
                return supportParent.ParentViewModel as CollectionViewModel<TEntity, TPrimaryKey, TUnitOfWork>;
            }
            return null;
        }
        protected SingleObjectViewModel<TEntity, TPrimaryKey, TUnitOfWork> GetSingleObjectViewModel() {
            var supportParent = this as ISupportParentViewModel;
            if(supportParent != null) {
                return supportParent.ParentViewModel as SingleObjectViewModel<TEntity, TPrimaryKey, TUnitOfWork>;
            }
            return null;
        }
    }
}
