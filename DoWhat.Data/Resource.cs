using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Data
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(Thing))]
        public int ThingId { get; set; }
        public virtual Thing Thing { get; set; }

        [Display(Name ="Content Title")]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
