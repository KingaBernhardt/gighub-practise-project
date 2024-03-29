﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gighub.Models
{
    public class Attendance
    {
        public Gig Gig { get; set; }
        public ApplicationUser Attende { get; set; }
        [Key]
        [Column(Order= 1)]
        public int GigId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string AttendeId { get; set; }
    }
}