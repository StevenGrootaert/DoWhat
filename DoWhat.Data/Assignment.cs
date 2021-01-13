using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Data
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }
        // this will make an assignment based on catagory and thing

        [ForeignKey("Thing")]
        public int ThingId { get; set; }
        public virtual Thing Thing { get; set; }

        // anything else? is this even useful IDK ?? 
        // IsCompleted doesn't make sense here becuase it's tied to the assignment not the thing that needs doing.. 
        // This whole Class might be more useful fo setting up recurring tasks/things. 


        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
