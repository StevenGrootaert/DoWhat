using DoWhat.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DoWhat.Models.ResourceModels
{
    public class ResourceListByThing
    {
        public int ResourceId { get; set; }

        [Display(Name = "Content Title")]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Display(Name = "Added")]
        public DateTimeOffset CreatedUtc { get; set; }

        [ForeignKey("Thing")]
        [Display(Name = "Thing Id")]
        public int ThingId { get; set; }
        public virtual Thing Thing { get; set; }

        public IEnumerable<SelectListItem> Things { get; set; } // not sure I need this here
    }
}
