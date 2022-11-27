using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Movars.Core.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movars.Core.Models
{
    public class Bid
    {
        public string Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public BidStatus Status { get; set; }

        [Required]
        public Mover Mover { get; set; }

        [Required]
        public Request Request { get; set; }
        public Bid()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
