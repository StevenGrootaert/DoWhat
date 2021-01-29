using DoWhat.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhat.Models.CatagoryModels
{
    public class CatagoryCreate
    {
        public int CatagoryId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Catagory Name can not be more than 100 charaters")]
        [Display(Name = "Catagory Name")]
        public string Name { get; set; }

        [Display(Name = "Catagory Description")]
        [MaxLength(300, ErrorMessage = "Description can not be more than 300 charaters")]
        public string Description { get; set; }
    }
}
