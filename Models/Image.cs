using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Donations_Online_Directory.Models
{
    public class Image
    {
    public int ID { get; set; }
    public string path { get; set; }
    public string description { get; set; }
    
    [NotMapped]
    public IFormFile file { get; set; }

    }
}
