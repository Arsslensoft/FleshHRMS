using System.Linq;
using PHRMS.Data;
using PHRMS.ViewModels;

namespace PHRMS.ViewModels {
    partial class WarningsCollectionViewModel
    {
        public int AllCount {
            get { return GetAllCount(); }
        }
        public int SevereCount {
            get { return GetSevereCount(); }
        }
        public int SeriousCount {
            get { return GetSeriousCount(); }
        }
        public int InconvenientCount {
            get { return GetInconvenientCount(); }
        }
        public int LowCount
        {
            get { return GetLowCount(); }
        }


        int GetSevereCount()
        {
            return Entities.Where(e => e.Severity == WarningSeverity.Severe).Count();
        }
        int GetSeriousCount()
        {
            return Entities.Where(e => e.Severity == WarningSeverity.Serious).Count();
        }
        int GetInconvenientCount()
        {
            return Entities.Where(e => e.Severity == WarningSeverity.Inconvenient).Count();
        }
        int GetLowCount()
        {
            return Entities.Where(e => e.Severity == WarningSeverity.Low).Count();
        }
      
        int GetAllCount() {
            return Entities.Count();
        }
     

    }
}
