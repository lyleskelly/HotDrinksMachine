#nullable disable
using HotDrinksMachine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotDrinksMachine.Pages.DrinkMethods
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
            ViewData["MethodId"] = new SelectList(_context.Methods, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public DrinkMethod DrinkMethods { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DrinkMethods.Add(DrinkMethods);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
