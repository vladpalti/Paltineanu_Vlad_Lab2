using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Paltineanu_Vlad_Lab2.Data;
using Paltineanu_Vlad_Lab2.Models;

namespace Paltineanu_Vlad_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Paltineanu_Vlad_Lab2.Data.Paltineanu_Vlad_Lab2Context _context;

        public IndexModel(Paltineanu_Vlad_Lab2.Data.Paltineanu_Vlad_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; }
        public SelectList AuthorList { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? AuthorID { get; set; }

        public async Task OnGetAsync()
        {
            var authors = await _context.Author.ToListAsync();
            AuthorList = new SelectList(authors, "ID", "Name");

            var booksQuery = _context.Book.Include(b => b.Publisher).Include(b => b.Author).AsQueryable();

            if (AuthorID.HasValue)
            {
                booksQuery = booksQuery.Where(b => b.AuthorID == AuthorID);
            }

            Book = await booksQuery.ToListAsync();
        }
    }
}
