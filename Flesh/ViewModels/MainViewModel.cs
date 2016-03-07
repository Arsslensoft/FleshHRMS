namespace DevExpress.DevAV.ViewModels {
    using System;
    using DevExpress.DevAV.Services;
    using DevExpress.Mvvm;

    public delegate void ModuleInitializeMethod(object module);
    public class MainViewModel : DevExpress.Mvvm.ViewModelBase {
        static MainViewModel() {
            DevExpress.Mvvm.ServiceContainer.Default.RegisterService(new Services.Win.ModuleResourceProvider());
            DevExpress.Mvvm.ServiceContainer.Default.RegisterService(new Services.MessageBoxService());
            DevExpress.Mvvm.ServiceContainer.Default.RegisterService(new Services.ModuleTypesResolver());
            DevExpress.Mvvm.ServiceContainer.Default.RegisterService(new Services.ModuleResourceProvider());
        }
        public MainViewModel(IMainModule mainModule) {
            RegisterServices(mainModule);
        }
        private void RegisterServices(IMainModule mainModule) {
            var mainModuleType = mainModule.GetType();
            ServiceContainer.RegisterService(new Services.ModuleActivator(
                mainModuleType.Assembly, mainModuleType.Namespace + ".Modules"));
            ServiceContainer.RegisterService(new Services.ReportActivator(
                mainModuleType.Assembly, "DevExpress.DevAV.Reports"));
            ServiceContainer.RegisterService(new Services.ModuleLocator(ServiceContainer));
            ServiceContainer.RegisterService(new Services.ReportLocator(ServiceContainer));
            ServiceContainer.RegisterService(new Services.TransitionService(mainModule));
            ServiceContainer.RegisterService(new Services.PeekModulesHostingService(mainModule));
            ServiceContainer.RegisterService(new Services.WorkspaceService(mainModule));
        }
        ModuleType selectedModuleType;
        public ModuleType SelectedModuleType { get { return selectedModuleType; } }
        public void SetSelectedModuleType(ModuleType moduleType, ModuleInitializeMethod initialize) {
            if(SelectedModuleType == moduleType) return;
            var old = SelectedModuleType;
            this.selectedModuleType = moduleType;
            OnSelectedModuleTypeChanged(old, initialize);
        }
        public virtual object SelectedModule { get;
            set; }
        public bool CanSelectModule(ModuleType moduleType) {
            return SelectedModuleType != moduleType;
        }
        public void SelectModule(ModuleType moduleType) { SelectModule(moduleType, null); }
        public void SelectModule(ModuleType moduleType, ModuleInitializeMethod initialize) {
            SetSelectedModuleType(moduleType, initialize);
        }
        public bool CanDockPeekModule(ModuleType moduleType) {
            var peekModuleType = GetPeekModuleType(moduleType);
            return !GetService<IPeekModulesHostingService>().IsDocked(peekModuleType);
        }
        [DevExpress.Mvvm.DataAnnotations.Command]
        public void DockPeekModule(ModuleType moduleType) {
            var peekModuleType = GetPeekModuleType(moduleType);
            GetService<IPeekModulesHostingService>().DockModule(peekModuleType);
        }
        public bool CanShowPeekModule(ModuleType moduleType) {
            var peekModuleType = GetPeekModuleType(moduleType);
            return !GetService<IPeekModulesHostingService>().IsDocked(peekModuleType);
        }
        [DevExpress.Mvvm.DataAnnotations.Command]
        public void ShowPeekModule(ModuleType moduleType) {
            var peekModuleType = GetPeekModuleType(moduleType);
            GetService<IPeekModulesHostingService>().ShowModule(peekModuleType);
        }
        public object GetModule(ModuleType type) {
            return GetService<Services.IModuleLocator>().GetModule(type);
        }
        public object GetModule(ModuleType type, object viewModel) {
            return GetService<Services.IModuleLocator>().GetModule(type, viewModel);
        }
        public string GetModuleName(ModuleType type) {
            return GetService<Services.IModuleTypesResolver>().GetName(type);
        }
        public System.Guid GetModuleID(ModuleType type) {
            return GetService<Services.IModuleTypesResolver>().GetId(type);
        }
        public string GetModuleCaption(ModuleType type) {
            return GetService<Services.IModuleResourceProvider>().GetCaption(type);
        }
        public object GetModuleImage(ModuleType type) {
            return GetService<Services.IModuleResourceProvider>().GetModuleImage(type);
        }
        public ModuleType GetPeekModuleType(ModuleType type) {
            return GetService<Services.IModuleTypesResolver>().GetPeekModuleType(type);
        }
        protected virtual void OnSelectedModuleTypeChanged(ModuleType oldType, ModuleInitializeMethod newModuleInitialize) {
            var transitionService = GetService<Services.ITransitionService>();
            using (transitionService.EnterTransition((SelectedModuleType != ModuleType.Unknown) && (oldType != ModuleType.Unknown))) {
                var workspaceService = GetService<Services.IWorkspaceService>();
                var resolver = GetService<IModuleTypesResolver>();
                if (oldType != ModuleType.Unknown) {
                    workspaceService.SaveWorkspace(resolver.GetName(oldType));
                } else {
                    workspaceService.SetupDefaultWorkspace();
                }
                SelectedModule = GetModule(SelectedModuleType);
                if (SelectedModuleType != ModuleType.Unknown) {
                    workspaceService.RestoreWorkspace(resolver.GetName(SelectedModuleType));
                }
                if(SelectedModule != null && newModuleInitialize != null) newModuleInitialize(SelectedModule);
            }
            if(ModuleTransitionCompleted != null) ModuleTransitionCompleted(SelectedModule, EventArgs.Empty);

        }
        protected virtual void OnSelectedModuleChanged(object oldModule) {
            if (oldModule != null) {
                if (ModuleRemoved != null) {
                    ModuleRemoved(oldModule, EventArgs.Empty);
                }
            }
            if (SelectedModule != null) {
                ViewModelHelper.EnsureModuleViewModel(SelectedModule, this);
                if (ModuleAdded != null) {
                    ModuleAdded(SelectedModule, EventArgs.Empty);
                }
            }
        }
        public event EventHandler ModuleAdded;
        public event EventHandler ModuleRemoved;
        public event EventHandler ModuleTransitionCompleted;
    }
}
