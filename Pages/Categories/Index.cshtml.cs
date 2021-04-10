using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Donations_Online_Directory.Data;
using Donations_Online_Directory.Models;

namespace Donations_Online_Directory.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Donations_Online_Directory.Data.Donations_Online_DirectoryContext _context;

        public IndexModel(Donations_Online_Directory.Data.Donations_Online_DirectoryContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category
                .Include(s=>s.Product)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
