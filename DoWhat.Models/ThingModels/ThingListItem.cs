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

        [Display(Name = "Resources")]    // think I might leave this out here -- don't need it in the list view for the Things but in the details
        public int ResourceId { get; set; }

        [Display(Name = "Completed")]           // make this a real checkbox - However the general view will should ONLY show incompleted Things an ALL things view will show both completed and in completed. or ony completed. 
        public bool IsCompleted { get; set; }

        [Display(Name = "Added")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
