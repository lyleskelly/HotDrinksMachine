#nullable disable
using HotDrinksMachine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotDrinksMachine.Pages.DrinkMethods
{
    public class DetailsModel : PageModel
    {
        private readonly HotDrinksMachine.Data.HotDrinksMachineContext _context;

        public DetailsModel(HotDrinksMachine.Data.HotDrinksMachineContext context)
        {
            _context = context;
        }

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
    }
}
