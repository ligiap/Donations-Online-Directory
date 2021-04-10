using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donations_Online_Directory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Donations_Online_Directory.Pages
{
    public class Upload_ImagesModel : PageModel
    {
        [BindProperty]
        public Image image { get; set; }
        [BindProperty]
        public Product product { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        { 
        }
    }
}
