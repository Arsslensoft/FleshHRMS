using FHRMS.Automatics;
using FHRMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace AutopilotTest
{
    class Program
    {
        static void Main(string[] args)
        {
            PhexonPilot pp = new PhexonPilot();
            pp.DatabaseManager.Employees.Load();
            List<Employee> s = pp.DatabaseManager.Employees.Local.ToList();
        }
    }
}
