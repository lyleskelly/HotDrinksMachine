#nullable disable
using HotDrinksMachine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotDrinksMachine.Pages.DrinkIngredients
{
    public class DeleteModel : PageModel
    {
        private readonly HotDrinksMachine.Data.HotDrinksMachineContext _context;

        public DeleteModel(HotDrinksMachine.Data.HotDrinksMachineContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DrinkIngredient DrinkIngredients { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DrinkIngredients = await _context.DrinkIngredients
                .Include(d => d.Ingredient).FirstOrDefaultAsync(m => m.Id == id);

            if (DrinkIngredients == null)
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

            DrinkIngredients = await _context.DrinkIngredients.FindAsync(id);

            if (DrinkIngredients != null)
            {
                _context.DrinkIngredients.Remove(DrinkIngredients);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
