using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Donations_Online_Directory.Models
{
    public class Product
    {
    public int ID { get; set; }

    public int CategoryID { get; set; }

    [Required]
    [RegularExpression(@"[a-zA-Z0-9\s-]+"), StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }
    
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}",ApplyFormatInEditMode =true)]
    public DateTime AgeOfProduct { get; set; }
    
    public string Description { get; set; }

    [BindProperty]
    public Category Category { get; set; }

       // public ICollection<Image> Image { get; set; }
    }
}
