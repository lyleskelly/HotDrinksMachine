using HotDrinksMachine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotDrinksMachine.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HotDrinksMachine.Data.HotDrinksMachineContext _context;

        public IndexModel(ILogger<IndexModel> logger, HotDrinksMachine.Data.HotDrinksMachineContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Drink> Drinks { get; set; }

        [BindProperty]
        public IList<DrinkMethod> DrinkMethods { get; set; }

        public async Task OnGetAsync()
        {
            Drinks = await _context.Drinks
                .ToListAsync();
        }

        public async Task OnPostAsync(int drinkId)
        {
            DrinkMethods = await _context.DrinkMethods
            .Include(i => i.Method)
            .Where(d => d.DrinkId == drinkId)
            .OrderBy(m => m.Step)
            .ToListAsync();
        }
    }
}