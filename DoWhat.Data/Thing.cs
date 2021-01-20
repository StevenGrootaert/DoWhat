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
        public string Heading { get; set; }

        [Required]
        public int TimeAllotted { get; set; }

        [ForeignKey(nameof(Catagory))]
        public int CatagoryId { get; set; } 
        public virtual Catagory Catagory { get; set; }

        [DefaultValue(false)]
        public bool IsCompleted { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

