using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Models
{
    public class ThingListItem
    {
        public int ThingId { get; set; }

        public string Heading { get; set; }

        public int TimeAlloted { get; set; }

        [Display(Name = "Category Name")]       // selected from a dropdown of seeded default catagories?
        public int CatagoryId { get; set; }

        [Display(Name = "Additional Notes")]    // maybe just call this resources?
        public int ResourceId { get; set; }

        [Display(Name = "Completed")]           // make this a real chackbox not a glyph thing. 
        public bool IsCompleted { get; set; }

        [Display(Name = "Added")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
