using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHRMS.API
{
    public class AttendanceDriverEventArgs
    {
        public string Badge { get; set; }
        public double Confidence { get; set; }
        public AttendanceDriverEventArgs(string badge,double confidence)
        {
            Confidence = confidence;
            Badge = badge;
        }
    }
    public delegate void AttendanceDriverEventHandler(object sender, AttendanceDriverEventArgs e);
 
    public interface IAttendanceDriver
    {
        event AttendanceDriverEventHandler OnAttendanceDataReceived;
        event EventHandler OnServiceStarted;
        event EventHandler OnServiceStopped;

        void Initialize();
        void StartService();
        void StopService();
              
    }
}
