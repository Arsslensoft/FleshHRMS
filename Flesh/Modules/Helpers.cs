namespace DevExpress.DevAV {
    using DevExpress.Mvvm;
    using DevExpress.DevAV.Modules;

    public static class ViewModelHelper {
        public static TViewModel GetParentViewModel<TViewModel>(object viewModel) {
            var parentViewModelSupport = viewModel as ISupportParentViewModel;
            if (parentViewModelSupport != null) {
                return (TViewModel)parentViewModelSupport.ParentViewModel;
            }
            return default(TViewModel);
        }
        public static void EnsureModuleViewModel(object module, object parentViewModel, object parameter = null) {
            var vm = module as ISupportViewModel;
            if (vm != null) {
                object oldParentViewModel = null;
                var parentViewModelSupport = vm.ViewModel as ISupportParentViewModel;
                if (parentViewModelSupport != null) {
                    oldParentViewModel = parentViewModelSupport.ParentViewModel;
                }
                EnsureViewModel(vm.ViewModel, parentViewModel, parameter);
                if (oldParentViewModel != parentViewModel) {
                    vm.ParentViewModelAttached();
                }
            }
        }
        public static void EnsureViewModel(object viewModel, object parentViewModel, object parameter = null) {
            var parentViewModelSupport = viewModel as ISupportParentViewModel;
            if (parentViewModelSupport != null) {
                parentViewModelSupport.ParentViewModel = parentViewModel;
            }
            var parameterSupport = viewModel as ISupportParameter;
            if (parameterSupport != null && parameter != null) {
                parameterSupport.Parameter = parameter;
            }
        }
    }
}
