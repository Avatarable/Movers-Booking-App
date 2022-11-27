using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Movars.Core.Models.Enums
{
    public enum RequestStatus
    { 
        [Description("Not Done")]
        NotDone,
        [Description("Pending")]
        Pending,
        [Description("In Progress")]
        InProgress,
        [Description("Completed")]
        Completed
    }
}
