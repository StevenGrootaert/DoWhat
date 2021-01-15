using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Models
{
    public class ThingEdit
    {
        public int ThingId { get; set; } // why is this here if I never want someone to edit the ThingId? -- BUT if used when writing code when populated 

        public string Heading { get; set; }

        public string SubHeading { get; set; }

        // will need to add public int CategoryId { get; set;}

        public AllottedTime TimeAllotted { get; set; }

        public bool IsCompleted { get; set; }

        // why do i not need a ModifiedUtc here?
    }
}

// If I update this time table I have to do it in sooooo many places?? 
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