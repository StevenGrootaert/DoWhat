using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DoWhat.Models
{
    public class ThingCreate
    {
        [Required]
        [Display(Name = "Thing Heading")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(75, ErrorMessage = "Heading can not be more than 75 charaters")]
        public string Heading { get; set; }

        [Required]
        [Display(Name = "Time Alloted")]
        public int TimeAllotted { get; set; }   // selected from a dropdown in a viewbag

        [Display(Name = "Category Name")]       // selected from a dropdown of seeded default catagories?
        public int CatagoryId { get; set; }

        //[Display(Name = "Resources")]    // I don't need this when making a thing - resources get added later and then attched to things when you make a resource
        //public int ResourceId { get; set; }

        // for the drop down lists
        public IEnumerable<SelectListItem> Catagories { get; set; }
        //public IEnumerable<SlectListItem> TimeInMin { get; set; } //- this would have to come from a DbSet of time - I just want a list? 
    }
}
