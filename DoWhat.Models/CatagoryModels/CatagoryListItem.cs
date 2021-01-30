using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Models.CatagoryModels
{
    public class CatagoryListItem
    {
        public int CatagoryId { get; set; }

        [Display(Name = "Catagory Name")]
        public string Name { get; set; }

        [Display(Name = "Catagory Description")]
        public string Description { get; set; }
    }
}
