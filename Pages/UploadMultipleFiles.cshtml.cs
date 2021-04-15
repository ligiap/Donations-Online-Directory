using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Donations_Online_Directory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Donations_Online_Directory.Data;


namespace Donations_Online_Directory.Pages
{
    public class UploadMultipleFilesModel : PageModel
    {
        private readonly Donations_Online_DirectoryContext _context;
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtensions = { ".png", ".jpg", ".jpeg" };

        public UploadMultipleFilesModel(Donations_Online_DirectoryContext context,
            IConfiguration config)
        {
            _context = context;
            _fileSizeLimit = 10000;
                //config.GetValue<long>("FileSizeLimit");
        }
        [BindProperty]
        public UploadMultipleFiles FileUpload { get; set; }

        public string Result { get; private set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostUploadAsync()
        {
            // Perform an initial check to catch FileUpload class
            // attribute violations.
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return Page();
            }

            foreach (var formFile in FileUpload.FormFiles)
            {
                    var formFileContent =
                    await FileProcessor.ProcessFormFile<UploadMultipleFiles>(
                        formFile, ModelState, _permittedExtensions,
                        _fileSizeLimit);

                // Perform a second check to catch ProcessFormFile method
                // violations. If any validation check fails, return to the
                // page.
                if (!ModelState.IsValid)
                {
                    Result = "Please correct the form.";

                    return Page();
                }
                var file = new Image()
                {
                    Content = formFileContent,
                    //UntrustedName = formFile.FileName,
                    Note = FileUpload.Note,
                    Size = formFile.Length,
                    //UploadDT = DateTime.UtcNow
                };

              _context.Image.Add(file);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }

    public class UploadMultipleFiles
    {
        [Required]
        [Display(Name = "File")]
        public List<IFormFile> FormFiles { get; set; }

        [Display(Name = "Note")]
        [StringLength(50, MinimumLength = 0)]
        public string Note { get; set; }
    }
}

