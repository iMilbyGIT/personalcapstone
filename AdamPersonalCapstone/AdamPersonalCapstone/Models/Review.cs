﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdamPersonalCapstone.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Feedback")]
        public string FeedBack { get; set; }

        [Display(Name = "From User")]
        public string From { get; set; }

        [Display(Name = "Time Sent")]
        public DateTime DatePosted { get; set; }
    }
}