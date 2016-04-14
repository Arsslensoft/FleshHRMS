using DevExpress.Utils.Menu;

namespace PHRMS {
    public enum ModuleType {
        Unknown,
        CustomersPeek,
        CustomersFilterPane,

        Dashboard,

        EmployeeView,
        ModifierEmployé,
        ImprimerEmployé,
        Employés,

     

        Congés,
        ModifierCongés,
        ImprimerCongé,

      
        Absences,
        ModifierAbsence,
        ImprimerAbsence,

        Attendances,
        ModifierPointage,
        ImprimerPointage,

        Avertissements,
        ModifierAvertissement,
        ImprimerAvertissements,

        ModifierPlaning,
        ModifierFérier,

        Statistiques,
        Notifications,
        Shifts,
        Holidays

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
