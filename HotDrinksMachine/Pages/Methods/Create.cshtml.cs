#nullable disable
using HotDrinksMachine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotDrinksMachine.Pages.Methods
{
    public class CreateModel : PageModel
    {
        private readonly HotDrinksMachine.Data.HotDrinksMachineContext _context;

        public CreateModel(HotDrinksMachine.Data.HotDrinksMachineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Method Method { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Methods.Add(Method);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
