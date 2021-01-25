using DoWhat.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Models.ThingModels
{
    public class ThingListItem
    {
        public int ThingId { get; set; }

        [Display(Name = "Thing Heading")]
        public string Heading { get; set; }

        [Display(Name = "Time Alloted in Min")]
        public int TimeAlloted { get; set; }

        [Display(Name = "Category Name")]
        public int CatagoryId { get; set; }
        public virtual Catagory Catagory { get; set; }

        [Display(Name = "Completed")]           // make this a real checkbox - However the general view will should ONLY show incompleted Things an ALL things view will show both completed and in completed. or ony completed. 
        public bool IsCompleted { get; set; }

        [Display(Name = "Added")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
