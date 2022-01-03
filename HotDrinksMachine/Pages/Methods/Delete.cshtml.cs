#nullable disable
using HotDrinksMachine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotDrinksMachine.Pages.Methods
{
    public class DeleteModel : PageModel
    {
        private readonly HotDrinksMachine.Data.HotDrinksMachineContext _context;

        public DeleteModel(HotDrinksMachine.Data.HotDrinksMachineContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Method = await _context.Methods.FindAsync(id);

            if (Method != null)
            {
                _context.Methods.Remove(Method);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
