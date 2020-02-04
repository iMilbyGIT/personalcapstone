using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace AdamPersonalCapstone.Models
{
    public class Device
    {
        [Key]
        public int DevicesId { get; set; }

        public string Brand { get; set; }

        public string Name { get; set; }

        public bool Owned { get; set; }
    }
}