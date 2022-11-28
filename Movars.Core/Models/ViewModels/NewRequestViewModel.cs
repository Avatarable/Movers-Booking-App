using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Movars.Core.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movars.Core.Models.ViewModels
{
    public class NewRequestViewModel
    {
        public int RoomsCount { get; set; }
        public int PickupFloor { get; set; }
        public int DropoffFloor { get; set; }
        public DateTime PickupDate { get; set; }
        public TimeOnly PickupTime { get; set; }
        public RequestType RequestType { get; set; }

        public string PickupAddress { get; set; }
        public string DropoffAddress { get; set; }
        public string PickupCity { get; set; }
        public string DropoffCity { get; set; }
        public string PickupState { get; set; }
        public string DropoffState { get; set; }
    }
}
