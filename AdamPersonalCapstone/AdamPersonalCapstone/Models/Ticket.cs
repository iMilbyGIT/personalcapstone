using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdamPersonalCapstone.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId{ get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId{ get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Device")]
        public int DeviceId { get; set; }
        public Device Device { get; set; }

        [Display(Name = "Message Sent At")]
        public DateTime? MessageSent { get; set; }

        [Display(Name = "Message Received At")]
        public DateTime? MessageReceived { get; set; }

        [Display(Name = "Ticket Subject")]
        public string Subject { get; set; }

        [Display(Name = "Ticket Message")]
        public string Message { get; set; }

        public bool isClaimed { get; set; }

        public bool isCompleted { get; set; }
    }
}