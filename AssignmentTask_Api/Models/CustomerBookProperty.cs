using System.ComponentModel.DataAnnotations;

namespace AssignmentTask_Api.Models
{
    public class CustomerBookProperty
    {
        [Key]
        public int  CustomerId { get; set; }
        public bool IsAlreadyBooked { get; set; }
    }
}
