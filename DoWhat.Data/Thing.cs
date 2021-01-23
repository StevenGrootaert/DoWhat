using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Data
{
    public class Thing
    {
        [Key]
        public int ThingId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "Thing Heading")]
        public string Heading { get; set; }

        [Required]
        public int TimeAllotted { get; set; }

        [ForeignKey(nameof(Catagory))]
        public int CatagoryId { get; set; } 
        public virtual Catagory Catagory { get; set; }

        //public int ResourceId { get; set; } // added to try and get a list of resources to show up in the detail view of a thing
        //public virtual Resource Resource { get; set; }

        [DefaultValue(false)]
        public bool IsCompleted { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

