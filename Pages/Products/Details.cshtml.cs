using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Donations_Online_Directory.Data;
using Donations_Online_Directory.Models;

namespace Donations_Online_Directory.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly Donations_Online_Directory.Data.Donations_Online_DirectoryContext _context;

        public DetailsModel(Donations_Online_Directory.Data.Donations_Online_DirectoryContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product
                .Include(s=>s.Category)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
