using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Movars.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movars.Core.Models
{
    public class Request
    {
        public string Id { get; set; }
        public int RoomsCount { get; set; }
        public int Floor { get; set; }
        public DateTime PickupDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public Mover? Mover { get; set; }
        public Owner Owner { get; set; } = null!;
        public RequestStatus RequestStatus { get; set; }
        public RequestType RequestType { get; set; }

        public Address? PickupAddress { get; set; }
        public Address? DeliveryAddress { get; set; }
        public Request()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
