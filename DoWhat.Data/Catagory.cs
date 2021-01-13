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
                 // need an entry for none of "defualt/ uncatagorized" like home 
        public int CatagoryId { get; set; }

        //public string CreatorId { get; set; } // not sure I need this here??  why doesn't public Guid OwnerId work? why does it have to nbe CreatorID
        //when the logged in user edits this it will set this UserId == CreatorId This was in the walkthrough somewhere

        [Required]
        public Guid OwnerId { get; set; } // IDK when/if to use CreatorID AuthorID etc. 

        [Required]
        [Display(Name = "Catagory Name")]
        public string Name { get; set; }

        [Display(Name = "Catagory Description")]
        public string Description { get; set; }
 
    }
}
