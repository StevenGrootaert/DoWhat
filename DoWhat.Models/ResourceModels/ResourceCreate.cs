﻿using DoWhat.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Models.ResourceModels
{
    public class ResourceCreate
    {
        public int ResourceId { get; set; }

        public int ThingId { get; set; }
        public virtual Thing Thing { get; set; }

        [MaxLength(100, ErrorMessage = "Content Title can not be more than 100 charaters")]
        [Display(Name = "Content Title")]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Content can not be more than 1000 charaters")]
        public string Content { get; set; }
    }
}