using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Models
{
    public class ThingDetail
    {
        public int ThingId { get; set; } // will need this in order to pass this Id to other functions etc. . 

        public string Heading { get; set; }

        public int TimeAllotted { get; set; }
        public bool IsCompleted { get; set; }

        [Display(Name = "Category Name")]       // selected from a dropdown of seeded default catagories?
        public int CatagoryId { get; set; }

        [Display(Name = "Resources")]    // this doesn't feel right !??  Is this a list of resources??
        public int ResourceId { get; set; }

        [Display(Name = "Added")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }

}

