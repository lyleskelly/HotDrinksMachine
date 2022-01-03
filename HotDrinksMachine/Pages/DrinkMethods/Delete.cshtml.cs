#nullable disable
using HotDrinksMachine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotDrinksMachine.Pages.DrinkMethods
{
    public class DeleteModel : PageModel
    {
        private readonly HotDrinksMachine.Data.HotDrinksMachineContext _context;

        public DeleteModel(HotDrinksMachine.Data.HotDrinksMachineContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DrinkMethod DrinkMethods { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DrinkMethods = await _context.DrinkMethods
                .Include(d => d.Method).FirstOrDefaultAsync(m => m.Id == id);

            if (DrinkMethods == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DrinkMethods = await _context.DrinkMethods.FindAsync(id);

            if (DrinkMethods != null)
            {
                _context.DrinkMethods.Remove(DrinkMethods);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
