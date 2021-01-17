using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Models
{
    public class ThingCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(75, ErrorMessage = "Heading can not be more than 75 charaters")]
        public string Heading { get; set; }

        [Required]
        public int TimeAllotted { get; set; }   // selected from a dropdown in a viewbag

        [Display(Name = "Category Name")]       // selected from a dropdown of seeded default catagories?
        public int CatagoryId { get; set; }

        [Display(Name = "Additional Notes")]    // maybe just call this resources?
        public int ResourceId { get; set; }
    }
}
