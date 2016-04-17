using System.Linq;
using PHRMS.Data;

namespace PHRMS.ViewModels
{
    partial class WarningsCollectionViewModel
    {
        public int AllCount
        {
            get { return GetAllCount(); }
        }

        public int SevereCount
        {
            get { return GetSevereCount(); }
        }

        public int SeriousCount
        {
            get { return GetSeriousCount(); }
        }

        public int InconvenientCount
        {
            get { return GetInconvenientCount(); }
        }

        public int LowCount
        {
            get { return GetLowCount(); }
        }


        private int GetSevereCount()
        {
            return Entities.Where(e => e.Severity == WarningSeverity.Severe).Count();
        }

        private int GetSeriousCount()
        {
            return Entities.Where(e => e.Severity == WarningSeverity.Serious).Count();
        }

        private int GetInconvenientCount()
        {
            return Entities.Where(e => e.Severity == WarningSeverity.Inconvenient).Count();
        }

        private int GetLowCount()
        {
            return Entities.Where(e => e.Severity == WarningSeverity.Low).Count();
        }

        private int GetAllCount()
        {
            return Entities.Count();
        }
    }
}