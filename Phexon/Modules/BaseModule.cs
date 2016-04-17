using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using PHRMS.Services;
using PHRMS.ViewModels;

namespace PHRMS.Modules
{
    public class BaseModuleControl : XtraUserControl, ISupportViewModel
    {
        private int updateQueued;
        private object viewModelCore;

        private BaseModuleControl()
        {
        }

        protected BaseModuleControl(Func<object> viewModelnjector)
        {
            BindingContext = new BindingContext();
            viewModelCore = viewModelnjector();
            InitServices();
        }

        private IBaseViewModel IViewModel
        {
            get { return (IBaseViewModel) viewModelCore; }
        }

        public BottomPanelBase BottomPanel
        {
            get
            {
                if (Parent == null || Parent.Parent == null)
                {
                    return null;
                }
                var mainForm = Parent.Parent as MainForm;
                if (mainForm != null)
                {
                    return mainForm.bottomPanelBase1;
                }
                mainForm = Parent.Parent.Parent as MainForm;
                if (mainForm != null)
                {
                    return mainForm.bottomPanelBase1;
                }
                return null;
            }
        }

        public TileBar MainTileBar
        {
            get
            {
                if (Parent == null || Parent.Parent == null)
                {
                    return null;
                }
                var mainForm = Parent.Parent as MainForm;
                if (mainForm != null)
                {
                    return mainForm.mainTileBar;
                }
                mainForm = Parent.Parent.Parent as MainForm;
                if (mainForm != null)
                {
                    return mainForm.mainTileBar;
                }
                return null;
            }
        }

        object ISupportViewModel.ViewModel
        {
            get { return viewModelCore; }
        }

        void ISupportViewModel.ParentViewModelAttached()
        {
            OnParentViewModelAttached();
        }

        protected virtual void Return()
        {
        }

        protected virtual void Cancel()
        {
            try
            {
                IViewModel.Reset();
            }
            catch
            {
            }
            Return();
        }

        protected virtual bool CheckSave()
        {
            if (!Validate()) return false;
            if (IViewModel.CanSave())
            {
                var res = XtraMessageBox.Show(this, "Voulez-vous enregistrer vos changements?", "Phexon",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.Cancel) return false;
                if (res == DialogResult.No)
                {
                    Cancel();
                    return false;
                }
                Save();
                return false;
            }
            return true;
        }

        protected virtual bool Save()
        {
            if (!Validate())
            {
                return false;
            }
            try
            {
                IViewModel.Save();
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Erreur d'enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            Return();
            return true;
        }

        protected void QueueViewModelUpdate()
        {
            if (!IsHandleCreated || updateQueued < 0) return;
            if (0 == updateQueued++)
                BeginInvoke(new MethodInvoker(DoUpdateViewModel));
        }

        private void DoUpdateViewModel()
        {
            UpdateViewModel();
            updateQueued = 0;
        }

        protected virtual void UpdateViewModel()
        {
        }

        private void InitServices()
        {
            var serviceContainer = GetServiceContainer();
            if (serviceContainer != null)
                OnInitServices(serviceContainer);
        }

        protected static TViewModel CreateViewModel<TViewModel>()
            where TViewModel : class, new()
        {
            return ViewModelSource.Create<TViewModel>();
        }

        protected static TViewModel CreateViewModel<TViewModel>(Expression<Func<TViewModel>> constructorExpression)
            where TViewModel : class, new()
        {
            return ViewModelSource.Create(constructorExpression);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (viewModelCore != null)
                {
                    updateQueued = -1;
                    ReleaseModule();
                    OnDisposing();
                }
                viewModelCore = null;
            }
            base.Dispose(disposing);
        }

        private void ReleaseModule()
        {
            var locator = GetService<IModuleLocator>();
            if (locator != null)
            {
                locator.ReleaseModule(this);
            }
        }

        protected void ReleaseModuleReports<TEnum>()
            where TEnum : struct
        {
            var locator = GetService<IReportLocator>();
            if (locator != null)
            {
                foreach (TEnum key in Enum.GetValues(typeof(TEnum)))
                {
                    locator.ReleaseReport(key);
                }
            }
        }

        protected virtual void OnInitServices(IServiceContainer serviceContainer)
        {
        }

        protected virtual void OnDisposing()
        {
        }

        protected TViewModel GetViewModel<TViewModel>()
        {
            return (TViewModel) viewModelCore;
        }

        protected TViewModel GetParentViewModel<TViewModel>() where TViewModel : class
        {
            var temp = ((ISupportParentViewModel) viewModelCore).ParentViewModel;
            return temp is TViewModel ? (TViewModel) temp : null;
        }

        protected TViewModel TryGetModuleViewModel<TViewModel>(ref TViewModel moduleViewModel, ModuleType moduleType)
            where TViewModel : class
        {
            if (moduleViewModel == null)
            {
                var module = GetService<IModuleLocator>().GetModule(moduleType);
                if (module != null)
                {
                    var mainViewModel = ((ISupportParentViewModel) viewModelCore).ParentViewModel;
                    moduleViewModel = ((ISupportViewModel) module).ViewModel as TViewModel;
                    ViewModelHelper.EnsureViewModel(moduleViewModel, mainViewModel);
                }
            }
            return moduleViewModel;
        }

        protected TViewModel TryGetModuleViewModel<TViewModel>(ModuleType moduleType) where TViewModel : class
        {
            TViewModel moduleViewModel = null;

            var module = GetService<IModuleLocator>().GetModule(moduleType);
            if (module != null)
            {
                var mainViewModel = ((ISupportParentViewModel) viewModelCore).ParentViewModel;
                moduleViewModel = ((ISupportViewModel) module).ViewModel as TViewModel;
                ViewModelHelper.EnsureViewModel(moduleViewModel, mainViewModel);
            }

            return moduleViewModel;
        }

        protected TService GetService<TService>() where TService : class
        {
            var serviceContainer = GetServiceContainer();
            return serviceContainer != null ? serviceContainer.GetService<TService>() : null;
        }

        private IServiceContainer GetServiceContainer()
        {
            if (!(viewModelCore is ISupportServices))
                return null;
            return ((ISupportServices) viewModelCore).ServiceContainer;
        }

        protected virtual void OnParentViewModelAttached()
        {
        }

        protected internal virtual void OnTransitionCompleted()
        {
        }
    }
}

namespace PHRMS.ViewModels
{
    public interface IBaseViewModel
    {
        bool Save();
        bool CanSave();
        void Reset();
    }
}