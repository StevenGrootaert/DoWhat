using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Data
{
    public class Resource                    // things could have more than one resource item so to add more than one URL or Note or whatever you can make resource and then use a drop down to link it to a Thing
    {
        [Key]
        public int ResourceId { get; set; }

        public Guid OwnerId { get; set; }   // again I don't know if tis is Creator, author, etc.. 

                                            // selected from a dropdown on the resource 'create' page would be awesome. - but can't create a Thing w/out resource of this was an Fkey in the Thing
                                            // What if there was a way to make a blank one that the user edits (not creates) -- wait how do we have more than one? 
                                            // maybe this (mulitiple "resource" doesn't get tied back into Thing but is pulled into it when you click to see the 'details' of the Thing !
        [ForeignKey(nameof(Thing))]
        public int ThingId { get; set; }
        public virtual Thing Thing { get; set; }


        [Display(Name ="Content Title")]    // Website that will help me, or list of supplies
        public string Title { get; set; }

        [Required]                          // this can contain detailed notes, instructions, list of materials, URLs to youtube or blog posts. anything really? I'd like the form to be large in the view. 
        public string Content { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }


    }
}
