using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Movars.Core.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movars.Core.Models.ViewModels
{
    public class NewRequestViewModel
    {
        public int PickupFloor { get; set; }
        public int DropoffFloor { get; set; }
        public DateTime PickupDate { get; set; }

        public string PickupAddress { get; set; }
        public string DropoffAddress { get; set; }
        public string PickupCity { get; set; }
        public string DropoffCity { get; set; }
        public string PickupState { get; set; }
        public string DropoffState { get; set; }
        public string RbType { get; set; }
        //public bool RbOffice { get; set; } = false;
        //public bool RbLabour { get; set; } = false;
        //public bool RbOthers { get; set; } = false;
        public string RbRoom { get; set; }
        //public bool RbRoom2 { get; set; } = false;
        //public bool RbRoom3 { get; set; } = false;
        //public bool RbRoom4 { get; set; } = false;
        //public bool RbRoomS { get; set; } = false;
    }
}
