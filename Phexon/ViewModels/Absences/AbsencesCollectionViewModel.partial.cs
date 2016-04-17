using System.Linq;
using PHRMS.Data;

namespace PHRMS.ViewModels
{
    partial class AbsencesCollectionViewModel
    {
        public int AllCount
        {
            get { return GetAllCount(); }
        }

        public int MotiveWarrantedCount
        {
            get { return GetMotiveWarrantedCount(); }
        }

        public int CMWarrantedCount
        {
            get { return GetCMWarrantedCount(); }
        }

        public int UnwarrantedCount
        {
            get { return GetUnwarrantedCount(); }
        }

        public int LateCount
        {
            get { return GetLateCount(); }
        }

        private int GetUnwarrantedCount()
        {
            return Entities.Where(e => e.Kind == AbsenceType.Unwarranted).Count();
        }

        private int GetCMWarrantedCount()
        {
            return Entities.Where(e => e.Kind == AbsenceType.CertificateWarranted).Count();
        }

        private int GetMotiveWarrantedCount()
        {
            return Entities.Where(e => e.Kind == AbsenceType.MotiveWarranted).Count();
        }

        private int GetLateCount()
        {
            return Entities.Where(e => e.Kind == AbsenceType.Late).Count();
        }

        private int GetAllCount()
        {
            return Entities.Count();
        }
    }
}