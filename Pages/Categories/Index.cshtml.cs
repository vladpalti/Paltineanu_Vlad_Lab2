using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paltineanu_Vlad_Lab2.Data;
using Paltineanu_Vlad_Lab2.Models;

namespace Paltineanu_Vlad_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Paltineanu_Vlad_Lab2.Data.Paltineanu_Vlad_Lab2Context _context;

        public IndexModel(Paltineanu_Vlad_Lab2.Data.Paltineanu_Vlad_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;
        public List<Book> BooksInSelectedCategory { get; set; } = new List<Book>();
        public int? SelectedCategoryId { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Category = await _context.Category.ToListAsync();

            if (id != null)
            {
                SelectedCategoryId = id;

                BooksInSelectedCategory = await _context.Book
                    .Include(b => b.Author)
                    .Include(b => b.BookCategories)
                    .Where(b => b.BookCategories.Any(bc => bc.CategoryID == id))
                    .ToListAsync();
            }
        }
    }
}
