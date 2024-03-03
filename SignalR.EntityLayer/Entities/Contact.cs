using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string OpenDay { get; set; }
        public string OpenDayDescription { get; set; }
        public string OpenHour { get; set; }
    }
}
