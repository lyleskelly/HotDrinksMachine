#nullable disable
using HotDrinksMachine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotDrinksMachine.Pages.DrinkMethods
{
    public class EditModel : PageModel
    {
        private readonly HotDrinksMachine.Data.HotDrinksMachineContext _context;

        public EditModel(HotDrinksMachine.Data.HotDrinksMachineContext context)
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
            ViewData["MethodId"] = new SelectList(_context.Methods, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DrinkMethods).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkMethodsExists(DrinkMethods.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DrinkMethodsExists(int id)
        {
            return _context.DrinkMethods.Any(e => e.Id == id);
        }
    }
}
