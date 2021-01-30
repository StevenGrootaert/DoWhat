using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Data
{
    public class Catagory
    {
        [Key]
        public int CatagoryId { get; set; }

        [Required]
        public Guid OwnerId { get; set; } 

        [Required]
        [Display(Name = "Catagory Name")]
        public string Name { get; set; }

        [Display(Name = "Catagory Description")]
        public string Description { get; set; }
    }
}
