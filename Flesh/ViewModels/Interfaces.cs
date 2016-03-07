using DevExpress.Utils.Menu;

namespace DevExpress.DevAV {
    public enum ModuleType {
        Unknown,

        EmployeeView,
        EmployeeEdit,
        EmployeesPrint,
        EmployeeMailMerge,
        Employees,

        CustomersFilterPane,
        CustomersPeek,
        CustomerEditableView,
        CustomersModule,
        CustomerDetails,


        Dashboard,
        Tasks,
        EditTask,
        TaskPrint,

        Products,
        ProductsEditableView,

        Sales,
        SalesPrint,
        OrderView,
        Opportunities,
        EditNotes,
        Notes,

    }
    public interface IMainModule : IPeekModulesHost,
    ISupportModuleLayout, ISupportTransitions, IDXMenuManagerProvider {
    }
    public interface ISupportTransitions {
        void StartTransition(bool effective);
        void EndTransition(bool effective);
    }
    public interface ISupportModuleLayout {
        void SaveLayoutToStream(System.IO.MemoryStream ms);
        void RestoreLayoutFromStream(System.IO.MemoryStream ms);
    }
    public interface IPeekModulesHost {
        bool IsDocked(ModuleType type);
        void DockModule(ModuleType moduleType);
        void ShowPeek(ModuleType moduleType);
    }
}
