using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DoWhat.Models.ThingModels
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
        public int TimeAllotted { get; set; }

        [Display(Name = "Category Name")]
        public int CatagoryId { get; set; }


        // for the drop down lists
        public IEnumerable<SelectListItem> Catagories { get; set; }
    }
}
