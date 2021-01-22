using DoWhat.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Models.ResourceModels
{
    public class ResourceDetail
    {
        public int ResourceId { get; set; }

        public int ThingId { get; set; }
        public virtual Thing Thing { get; set; }

        [Display(Name = "Content Title")]    // Website that will help me, or list of supplies
        public string Title { get; set; }

        [Required]                          // this can contain detailed notes, instructions, list of materials, URLs to youtube or blog posts. anything really? I'd like the form to be large in the view. 
        public string Content { get; set; }

        //[Required]
        [Display(Name = "Added")]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
