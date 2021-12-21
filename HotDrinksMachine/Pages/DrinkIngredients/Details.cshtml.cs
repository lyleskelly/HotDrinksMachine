﻿#nullable disable
using HotDrinksMachine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HotDrinksMachine.Pages.DrinkIngredients
{
    public class DetailsModel : PageModel
    {
        private readonly HotDrinksMachine.Data.HotDrinksMachineContext _context;

        public DetailsModel(HotDrinksMachine.Data.HotDrinksMachineContext context)
        {
            _context = context;
        }

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
    }
}
