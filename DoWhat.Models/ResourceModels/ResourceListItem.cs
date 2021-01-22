using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DoWhat.Models.ResourceModels
{
    public class ResourceListItem
    {
        public int ResourceId { get; set; }

        [Display(Name = "Content Title")]    // Website that will help me, or list of supplies
        public string Title { get; set; }

        [Required]                          // this can contain detailed notes, instructions, list of materials, URLs to youtube or blog posts. anything really? I'd like the form to be large in the view. 
        public string Content { get; set; }

        [Display(Name = "Added")]
        public DateTimeOffset CreatedUtc { get; set; }

        public int ThingId { get; set; }
        public virtual Data.Thing Thing { get; set; }

        //public IEnumerable<SelectListItem> Things { get; set; } //to get the thing Heading to show up in the Resource Index view
    }
}
