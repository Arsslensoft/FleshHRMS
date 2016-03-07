namespace DevExpress.DevAV.Modules {
    using System;
    using System.Linq.Expressions;
    using DevExpress.DevAV.Common.ViewModel;
    using DevExpress.DevAV.ViewModels;
    using DevExpress.XtraBars.Navigation;
    using DevExpress.XtraEditors;

    public class BaseModuleControl : XtraUserControl, ISupportViewModel {
        BaseModuleControl() { }
        private object viewModelCore;
        protected BaseModuleControl(Func<object> viewModelnjector) {
            BindingContext = new System.Windows.Forms.BindingContext();
            viewModelCore = viewModelnjector();
            InitServices();
        }
        IBaseViewModel IViewModel {
            get { return (IBaseViewModel)viewModelCore; }
        }
        protected virtual void Return() {
        }
        protected virtual void Cancel() {
            try {
                IViewModel.Reset();
            } catch { }
            Return();
        }
        protected virtual bool CheckSave() {
            if(!Validate()) return false;
            if(IViewModel.CanSave()) {
                var res = XtraMessageBox.Show(this, "Do you want to save changes?", "HybridApp", System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Warning);
                if(res == System.Windows.Forms.DialogResult.Cancel) return false;
                if(res == System.Windows.Forms.DialogResult.No) {
                    Cancel();
                    return false;
                }
                Save();
                return false;
            }
            return true;
        }
        protected virtual bool Save() {
            if(!Validate()) {
                return false;
            }
            try {
                IViewModel.Save();
            } catch (Exception e) {
                XtraMessageBox.Show(e.Message, "Error during save", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            Return();
            return true;
        }
        int updateQueued = 0;
        protected void QueueViewModelUpdate() {
            if(!IsHandleCreated || updateQueued < 0) return;
            if(0 == updateQueued++)
                BeginInvoke(new System.Windows.Forms.MethodInvoker(DoUpdateViewModel));
        }
        void DoUpdateViewModel() {
            UpdateViewModel();
            updateQueued = 0;
        }
        protected virtual void UpdateViewModel() { }
        void InitServices() {
            var serviceContainer = GetServiceContainer();
            if(serviceContainer != null)
                OnInitServices(serviceContainer);
        }
        protected static TViewModel CreateViewModel<TViewModel>()
            where TViewModel : class, new() {
            return DevExpress.Mvvm.POCO.ViewModelSource.Create<TViewModel>();
        }
        protected static TViewModel CreateViewModel<TViewModel>(Expression<Func<TViewModel>> constructorExpression)
            where TViewModel : class, new() {
            return DevExpress.Mvvm.POCO.ViewModelSource.Create<TViewModel>(constructorExpression);
        }
        protected override void Dispose(bool disposing) {
            if(disposing) {
                if(viewModelCore != null) {
                    updateQueued = -1;
                    ReleaseModule();
                    OnDisposing();
                }
                viewModelCore = null;
            }
            base.Dispose(disposing);
        }
        void ReleaseModule() {
            var locator = GetService<Services.IModuleLocator>();
            if(locator != null) {
                locator.ReleaseModule(this);
            }
        }
        protected void ReleaseModuleReports<TEnum>()
            where TEnum : struct {
            var locator = GetService<Services.IReportLocator>();
            if(locator != null) {
                foreach(TEnum key in Enum.GetValues(typeof(TEnum))) {
                    locator.ReleaseReport(key);
                }
            }
        }
        protected virtual void OnInitServices(DevExpress.Mvvm.IServiceContainer serviceContainer) { }
        protected virtual void OnDisposing() { }
        protected TViewModel GetViewModel<TViewModel>() {
            return (TViewModel)viewModelCore;
        }
        protected TViewModel GetParentViewModel<TViewModel>() where TViewModel : class {
            object temp = ((DevExpress.Mvvm.ISupportParentViewModel)viewModelCore).ParentViewModel;
            return temp is TViewModel ? (TViewModel)temp : null;
        }
        protected TViewModel TryGetModuleViewModel<TViewModel>(ref TViewModel moduleViewModel, ModuleType moduleType) where TViewModel : class {
            if(moduleViewModel == null) {
                var module = GetService<Services.IModuleLocator>().GetModule(moduleType);
                if(module != null) {
                    object mainViewModel = ((DevExpress.Mvvm.ISupportParentViewModel)viewModelCore).ParentViewModel;
                    moduleViewModel = ((ISupportViewModel)module).ViewModel as TViewModel;
                    ViewModelHelper.EnsureViewModel(moduleViewModel, mainViewModel);
                }
            }
            return moduleViewModel;
        }
        protected TService GetService<TService>() where TService : class {
            var serviceContainer = GetServiceContainer();
            return (serviceContainer != null) ? serviceContainer.GetService<TService>() : null;
        }
        Mvvm.IServiceContainer GetServiceContainer() {
            if(!(viewModelCore is DevExpress.Mvvm.ISupportServices))
                return null;
            return ((DevExpress.Mvvm.ISupportServices)viewModelCore).ServiceContainer;
        }
        object ISupportViewModel.ViewModel {
            get { return viewModelCore; }
        }
        void ISupportViewModel.ParentViewModelAttached() {
            OnParentViewModelAttached();
        }
        protected virtual void OnParentViewModelAttached() { }
        public BottomPanelBase BottomPanel {
            get {
                if(Parent == null || Parent.Parent == null) {
                    return null;
                }
                var mainForm = Parent.Parent as MainForm;
                if(mainForm != null) {
                    return mainForm.bottomPanelBase1;
                }
                mainForm = Parent.Parent.Parent as MainForm;
                if(mainForm != null) {
                    return mainForm.bottomPanelBase1;
                }
                return null;
            }
        }
        public TileBar ProductTileBar {
            get {
                if(Parent == null || Parent.Parent == null) {
                    return null;
                }
                var mainForm = Parent.Parent as MainForm;
                if(mainForm != null) {
                    return mainForm.productTileBar;
                }
                mainForm = Parent.Parent.Parent as MainForm;
                if(mainForm != null) {
                    return mainForm.productTileBar;
                }
                return null;
            }
        }
        public TileBar MainTileBar {
            get {
                if(Parent == null || Parent.Parent == null) {
                    return null;
                }
                var mainForm = Parent.Parent as MainForm;
                if(mainForm != null) {
                    return mainForm.mainTileBar;
                }
                mainForm = Parent.Parent.Parent as MainForm;
                if(mainForm != null) {
                    return mainForm.mainTileBar;
                }
                return null;
            }
        }
        public TileBar CustomerTileBar {
            get {
                if(Parent == null || Parent.Parent == null) {
                    return null;
                }
                var mainForm = Parent.Parent as MainForm;
                if(mainForm != null) {
                    return mainForm.customTileBar;
                }
                mainForm = Parent.Parent.Parent as MainForm;
                if(mainForm != null) {
                    return mainForm.customTileBar;
                }
                return null;
            }
        }
        protected internal virtual void OnTransitionCompleted() { }
    }
}
namespace DevExpress.DevAV.ViewModels {
    public interface IBaseViewModel {
        bool Save();
        bool CanSave();
        void Reset();
    }
}
