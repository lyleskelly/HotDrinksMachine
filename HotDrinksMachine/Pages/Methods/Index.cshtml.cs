#nullable disable
using HotDrinksMachine.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotDrinksMachine.Pages.Methods
{
    public class IndexModel : PageModel
    {
        private readonly HotDrinksMachine.Data.HotDrinksMachineContext _context;

        public IndexModel(HotDrinksMachine.Data.HotDrinksMachineContext context)
        {
            _context = context;
        }

        public IList<Method> Method { get; set; }

        public async Task OnGetAsync()
        {
            Method = await _context.Methods.ToListAsync();
        }
    }
}
