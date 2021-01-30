using DoWhat.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DoWhat.Models.ThingModels
{
    public class ThingListByCatagory
    {
        public int ThingId { get; set; }

        [Display(Name = "Thing Heading")]
        public string Heading { get; set; }

        [Display(Name = "Time Alloted in Min")]
        public int TimeAlloted { get; set; }

        [Display(Name = "Category Name")]
        public int CatagoryId { get; set; }
        public virtual Catagory Catagory { get; set; }

        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }

        [Display(Name = "Added")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
