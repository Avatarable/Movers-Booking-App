using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Movars.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movars.Core.Models.ViewModels
{
    public class NewBidViewModel
    {
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public BidStatus Status { get; set; }
    }
}
