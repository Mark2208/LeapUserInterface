using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapUserInterface.Classes
{


    public class FileMapHandler
    {
        public string Name { get; set; }
        public int Byte_size { get; set; }
        public String Message { get; set; }
        public TimeSpan HoldTimeOn { get; set; }
        public TimeSpan HoldTimeOff { get; set; }

        public FileMapHandler(string name, int byte_size)
        {
            this.Name = name; this.Byte_size = byte_size; this.Message = ""; HoldTimeOn = TimeSpan.FromSeconds(0); HoldTimeOff = TimeSpan.FromSeconds(0);
        }

    }
}
