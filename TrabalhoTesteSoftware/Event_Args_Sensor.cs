using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoTesteSoftware
{
    public class Event_Args_Sensor : EventArgs
    {
        public Sensor Sensor { get; set; }

        public Event_Args_Sensor( Sensor s )
        {
            this.Sensor = s;
        }
    }
}
