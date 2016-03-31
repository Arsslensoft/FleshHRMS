using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaner
{
    class Program
    {
      static  string[] files = new string[] { "Credential.cs",
"Notification.cs",
"Holiday.cs",
"Shift.cs",
"Warnings.cs",
"Done\\Address.cs",
"Common\\DataDirectoryHelper.cs",
"Common\\IDataErrorInfoHelper.cs",
"Common\\ValidationAttributes.cs",
"DatabaseObject.cs",
"DevAVDb.cs",
"Employee.cs",
"Done\\Absence.cs",
"Attendance.cs",
"Picture.cs",
"Properties\\AssemblyInfo.cs",
"Done\\StateEnum.cs",
"Done\\Leave.cs"};
      static bool Ex(string f)
      {
          foreach (string fi in files)
              if (f.ToLower().EndsWith(fi.ToLower()))
                  return true;


          return false;
      }
        static void Main(string[] args)
        {

            foreach (string file in System.IO.Directory.GetFiles(@"E:\Research\FHRMS\FHRMS.Data", "*.cs", System.IO.SearchOption.AllDirectories))
                if (!Ex(file))
                        System.IO.File.Delete(file);


        }
    }
}
