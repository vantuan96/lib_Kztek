using System.Collections.Generic;

namespace eazy_library.Models
{
    public class AccessDeviceModel
    {
        public List<string> controllers { get; set; }

        public List<string> cardnumbers { get; set; }

        public string levelid { get; set; }

        public string type { get; set; } //UPLOAD - DELETE
    }

    public class AccessDeviceModel_Event
    {
        public string CardNumber { get; set; }

        public string ControllerId { get; set; }

        public string PCId { get; set; }

        public string DateEvent { get; set; }
    }
}