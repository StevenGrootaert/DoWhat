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

        public string SubHeading { get; set; }

        public AllottedTime TimeAlloted { get; set; }

        [UIHint("Checked")]
        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }

        [Display(Name = "Added")]
        public DateTimeOffset CreatedUtc { get; set; }

        public enum AllottedTime    // is there a better way to put this as a numeric value? 
        {
            FiveMin = 5,
            FiveteenMin = 15,
            ThirtyMin = 30,
            FortyFiveMin = 45,
            OneHour = 60,
            HourAndHalf = 90,
            TwoHours = 120,
            ThreeHours = 180,
            FourHours = 240,
        }
    }
}
