using System.Linq;
using FHRMS.Data;
using FHRMS.DevAVDbDataModel;
using FHRMS.ViewModels;

namespace FHRMS.ViewModels {
    partial class AbsencesCollectionViewModel
    {
        public int AllCount {
            get { return GetAllCount(); }
        }
        public int MotiveWarrantedCount {
            get { return GetMotiveWarrantedCount(); }
        }
        public int CMWarrantedCount {
            get { return GetCMWarrantedCount(); }
        }
        public int UnwarrantedCount {
            get { return GetUnwarrantedCount(); }
        }

        int GetUnwarrantedCount()
        {
            return Entities.Where(e => e.Kind == AbsenceType.Unwarranted).Count();
        }
        int GetCMWarrantedCount()
        {
            return Entities.Where(e => e.Kind == AbsenceType.CertificateWarranted).Count();
        }

        int GetMotiveWarrantedCount()
        {
            return Entities.Where(e => e.Kind == AbsenceType.MotiveWarranted).Count();
        }
      
        int GetAllCount() {
            return Entities.Count();
        }
     

    }
}
