using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Data
{
    public class Thing
    {
        [Key]
        public int ThingId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        //[Display(Name = "Task Name")]
        [MaxLength(100, ErrorMessage = "Heading can not be more than 100 charaters")]
        public string Heading { get; set; }

        //[Display(Name = "Task Summary")]
        [MaxLength(500, ErrorMessage = "Subheading can not be more than 500 charaters")]
        public string SubHeading { get; set; }

        //       ** can't create CRUD for thing w/out having catagory in place **
        //       is there a way to get this so that there's a default value set to uncatagorized?? 
        //[ForeignKey(nameof(Catagory))]      
        //public int CatagoryId { get; set; } 
        //public virtual Catagory Catagory { get; set; }

        [Required]
        public AllottedTime TimeAllotted { get; set; }

        //public int TimeValues { get; set; }
        //public int[] TimeValues = new[] { 5, 15, 30, 45, 60, 120, 180, 240 };
        //KeyValuePair<string, int>

        [DefaultValue(false)]
        public bool IsCompleted { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
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

