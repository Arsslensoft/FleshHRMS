﻿using System;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using PHRMS.Data;
using PHRMS.Modules;
using PHRMS.Services;
using ModuleResourceProvider = PHRMS.Services.Win.ModuleResourceProvider;

namespace PHRMS.ViewModels
{
    public delegate void ModuleInitializeMethod(object module);

    public class MainViewModel : ViewModelBase
    {
        static MainViewModel()
        {
            DevExpress.Mvvm.ServiceContainer.Default.RegisterService(new ModuleResourceProvider());
            DevExpress.Mvvm.ServiceContainer.Default.RegisterService(new MessageBoxService());
            DevExpress.Mvvm.ServiceContainer.Default.RegisterService(new ModuleTypesResolver());
            DevExpress.Mvvm.ServiceContainer.Default.RegisterService(new Services.ModuleResourceProvider());
        }

        public MainViewModel(IMainModule mainModule)
        {
            RegisterServices(mainModule);
        }

        public static Employee CurrentEmployee { get; set; }

        public ModuleType SelectedModuleType { get; private set; }

        public virtual object SelectedModule { get; set; }

        private void RegisterServices(IMainModule mainModule)
        {
            var mainModuleType = mainModule.GetType();
            ServiceContainer.RegisterService(new ModuleActivator(
                mainModuleType.Assembly, mainModuleType.Namespace + ".Modules"));
            ServiceContainer.RegisterService(new ReportActivator(
                mainModuleType.Assembly, "PHRMS"));
            ServiceContainer.RegisterService(new ModuleLocator(ServiceContainer));
            ServiceContainer.RegisterService(new ReportLocator(ServiceContainer));
            ServiceContainer.RegisterService(new TransitionService(mainModule));
            ServiceContainer.RegisterService(new PeekModulesHostingService(mainModule));
            ServiceContainer.RegisterService(new WorkspaceService(mainModule));
        }

        public void SetSelectedModuleType(ModuleType moduleType, ModuleInitializeMethod initialize)
        {
            if (SelectedModuleType == moduleType) return;
            var old = SelectedModuleType;
            SelectedModuleType = moduleType;
            OnSelectedModuleTypeChanged(old, initialize);
        }

        public bool CanSelectModule(ModuleType moduleType)
        {
            return SelectedModuleType != moduleType;
        }

        public void SelectModule(ModuleType moduleType)
        {
            SelectModule(moduleType, null);
        }

        public void SelectModule(ModuleType moduleType, ModuleInitializeMethod initialize)
        {
            SetSelectedModuleType(moduleType, initialize);
        }

        public bool CanDockPeekModule(ModuleType moduleType)
        {
            var peekModuleType = GetPeekModuleType(moduleType);
            return !GetService<IPeekModulesHostingService>().IsDocked(peekModuleType);
        }

        [Command]
        public void DockPeekModule(ModuleType moduleType)
        {
            var peekModuleType = GetPeekModuleType(moduleType);
            GetService<IPeekModulesHostingService>().DockModule(peekModuleType);
        }

        public bool CanShowPeekModule(ModuleType moduleType)
        {
            var peekModuleType = GetPeekModuleType(moduleType);
            return !GetService<IPeekModulesHostingService>().IsDocked(peekModuleType);
        }

        [Command]
        public void ShowPeekModule(ModuleType moduleType)
        {
            var peekModuleType = GetPeekModuleType(moduleType);
            GetService<IPeekModulesHostingService>().ShowModule(peekModuleType);
        }

        public object GetModule(ModuleType type)
        {
            return GetService<IModuleLocator>().GetModule(type);
        }

        public object GetModule(ModuleType type, object viewModel)
        {
            return GetService<IModuleLocator>().GetModule(type, viewModel);
        }

        public string GetModuleName(ModuleType type)
        {
            return GetService<IModuleTypesResolver>().GetName(type);
        }

        public Guid GetModuleID(ModuleType type)
        {
            return GetService<IModuleTypesResolver>().GetId(type);
        }

        public string GetModuleCaption(ModuleType type)
        {
            return GetService<IModuleResourceProvider>().GetCaption(type);
        }

        public object GetModuleImage(ModuleType type)
        {
            return GetService<IModuleResourceProvider>().GetModuleImage(type);
        }

        public ModuleType GetPeekModuleType(ModuleType type)
        {
            return GetService<IModuleTypesResolver>().GetPeekModuleType(type);
        }

        protected virtual void OnSelectedModuleTypeChanged(ModuleType oldType,
            ModuleInitializeMethod newModuleInitialize)
        {
            var transitionService = GetService<ITransitionService>();
            using (
                transitionService.EnterTransition((SelectedModuleType != ModuleType.Unknown) &&
                                                  (oldType != ModuleType.Unknown)))
            {
                var workspaceService = GetService<IWorkspaceService>();
                var resolver = GetService<IModuleTypesResolver>();
                if (oldType != ModuleType.Unknown)
                {
                    workspaceService.SaveWorkspace(resolver.GetName(oldType));
                }
                else
                {
                    workspaceService.SetupDefaultWorkspace();
                }
                SelectedModule = GetModule(SelectedModuleType);
                if (SelectedModuleType != ModuleType.Unknown)
                {
                    workspaceService.RestoreWorkspace(resolver.GetName(SelectedModuleType));
                }
                if (SelectedModule != null && newModuleInitialize != null) newModuleInitialize(SelectedModule);
            }
            if (ModuleTransitionCompleted != null) ModuleTransitionCompleted(SelectedModule, EventArgs.Empty);
        }

        protected virtual void OnSelectedModuleChanged(object oldModule)
        {
            if (oldModule != null)
            {
                if (ModuleRemoved != null)
                {
                    ModuleRemoved(oldModule, EventArgs.Empty);
                }
            }
            if (SelectedModule != null)
            {
                ViewModelHelper.EnsureModuleViewModel(SelectedModule, this);
                if (ModuleAdded != null)
                {
                    ModuleAdded(SelectedModule, EventArgs.Empty);
                }
            }
        }

        public TViewModel TryGetModuleViewModel<TViewModel>(ModuleType moduleType) where TViewModel : class
        {
            TViewModel moduleViewModel = null;

            var module = GetService<IModuleLocator>().GetModule(moduleType);
            if (module != null)
            {
                moduleViewModel = ((ISupportViewModel) module).ViewModel as TViewModel;
                ViewModelHelper.EnsureViewModel(moduleViewModel, this);
            }

            return moduleViewModel;
        }

        public event EventHandler ModuleAdded;
        public event EventHandler ModuleRemoved;
        public event EventHandler ModuleTransitionCompleted;
    }
}