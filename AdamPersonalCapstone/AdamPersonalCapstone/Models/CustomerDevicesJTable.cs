using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdamPersonalCapstone.Models
{
    public class CustomerDevicesJTable
    {
        [Key]
        public int CustomerDevicesJTableId{ get; set; }

        [ForeignKey("Device")]
        public int DevicesId { get; set; }
        public Device Device { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}