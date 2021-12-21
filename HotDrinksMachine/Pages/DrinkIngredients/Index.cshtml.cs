#nullable disable
using HotDrinksMachine.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotDrinksMachine.Pages.DrinkIngredients
{
    public class IndexModel : PageModel
    {
        private readonly HotDrinksMachine.Data.HotDrinksMachineContext _context;

        public IndexModel(HotDrinksMachine.Data.HotDrinksMachineContext context)
        {
            _context = context;
        }

        public IList<DrinkIngredient> DrinkIngredients { get; set; }

        public async Task OnGetAsync()
        {
            DrinkIngredients = await _context.DrinkIngredients
                .Include(d => d.Ingredient).ToListAsync();
        }
    }
}
