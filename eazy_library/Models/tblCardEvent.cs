using System;
using System.Collections.Generic;
using System.Text;

namespace eazy_library.Models
{
 public class tblCardEvent
    {
        public DateTime Datetime { get; set; }

        public string UserID { get; set; }

        public string CardNo { get; set; }

        public string ControllerID { get; set; }

        public string DoorID { get; set; }
        public int ReaderIndex { get; set; } 
        public bool InOut { get; set; } 
        public int EventID { get; set; }
        public string EventType { get; set; }
    }
}
