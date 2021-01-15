using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Models
{
    public class ThingCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Heading can not be more than 100 charaters")]
        public string Heading { get; set; }

        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(300, ErrorMessage = "Subheading can not be more than 300 charaters")]
        public string SubHeading { get; set; }

        public AllottedTime TimeAllotted { get; set; }
    }

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
