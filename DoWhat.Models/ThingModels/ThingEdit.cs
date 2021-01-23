using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Models.ThingModels
{
    public class ThingEdit
    {
        public int ThingId { get; set; } // why is this here if I never want someone to edit the ThingId? -- BUT if used when writing code when populated 

        public string Heading { get; set; }

        public int TimeAllotted { get; set; }

        public bool IsCompleted { get; set; }

        [Display(Name = "Category Name")]       // selected from a dropdown of seeded default catagories?
        public int CatagoryId { get; set; }

        [Display(Name = "Additional Notes")]    // maybe just call this resources?
        public int ResourceId { get; set; }

        // why do i not need a ModifiedUtc here?
    }
}