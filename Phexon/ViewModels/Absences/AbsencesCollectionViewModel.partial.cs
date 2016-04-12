using System.Linq;
using PHRMS.Data;
using PHRMS.ViewModels;

namespace PHRMS.ViewModels {
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
        public int LateCount
        {
            get { return GetLateCount(); }
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

        int GetLateCount()
        {
            return Entities.Where(e => e.Kind == AbsenceType.Late).Count();
        }
        int GetAllCount() {
            return Entities.Count();
        }
     

    }
}
