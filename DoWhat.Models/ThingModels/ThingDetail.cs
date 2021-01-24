using DoWhat.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Models.ThingModels
{
    public class ThingDetail
    {
        public int ThingId { get; set; } // will need this in order to pass this Id to other functions etc. . 

        public string Heading { get; set; }

        public int TimeAllotted { get; set; }
        public bool IsCompleted { get; set; }

        [Display(Name = "Category Name")]
        public int CatagoryId { get; set; }
        public virtual Catagory Catagory { get; set; }

        [Display(Name = "Resources")]    // this doesn't feel right !??  Is this a list of resources?? I want to see the resources in detail view for the thing
        public int ResourceId { get; set; }
        public virtual Resource Resource { get; set; }

        [Display(Name = "Added")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }

}

