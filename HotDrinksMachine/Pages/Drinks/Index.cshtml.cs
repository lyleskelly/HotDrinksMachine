#nullable disable
using HotDrinksMachine.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotDrinksMachine.Pages.Drinks
{
    public class IndexModel : PageModel
    {
        private readonly HotDrinksMachine.Data.HotDrinksMachineContext _context;

        public IndexModel(HotDrinksMachine.Data.HotDrinksMachineContext context)
        {
            _context = context;
        }

        public IList<Drink> Drinks { get; set; }

        public async Task OnGetAsync()
        {
            Drinks = await _context.Drinks.ToListAsync();
        }
    }
}
