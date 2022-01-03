#nullable disable
using HotDrinksMachine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotDrinksMachine.Pages.Methods
{
    public class DetailsModel : PageModel
    {
        private readonly HotDrinksMachine.Data.HotDrinksMachineContext _context;

        public DetailsModel(HotDrinksMachine.Data.HotDrinksMachineContext context)
        {
            _context = context;
        }

        public Method Method { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Method = await _context.Methods.FirstOrDefaultAsync(m => m.Id == id);

            if (Method == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
