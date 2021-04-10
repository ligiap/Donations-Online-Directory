using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Donations_Online_Directory.Models
{
    public class Category
    {
    public int ID { get; set; }

    [Required]
    [RegularExpression(@"[a-zA-Z0-9\s-]+"),StringLength(100,MinimumLength=3)]
    public string Name { get; set; }

    public ICollection<Product> Product { get; set; }
    }
}
