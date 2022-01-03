#nullable disable
using HotDrinksMachine.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotDrinksMachine.Pages.DrinkMethods
{
    public class IndexModel : PageModel
    {
        private readonly HotDrinksMachine.Data.HotDrinksMachineContext _context;

        public IndexModel(HotDrinksMachine.Data.HotDrinksMachineContext context)
        {
            _context = context;
        }

        public IList<DrinkMethod> DrinkMethods { get; set; }

        public async Task OnGetAsync()
        {
            DrinkMethods = await _context.DrinkMethods
                .Include(d => d.Method).ToListAsync();
        }
    }
}
