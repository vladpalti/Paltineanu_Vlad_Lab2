﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paltineanu_Vlad_Lab2.Data;
using Paltineanu_Vlad_Lab2.Models;

namespace Paltineanu_Vlad_Lab2.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly Paltineanu_Vlad_Lab2.Data.Paltineanu_Vlad_Lab2Context _context;

        public IndexModel(Paltineanu_Vlad_Lab2.Data.Paltineanu_Vlad_Lab2Context context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Member = await _context.Member.ToListAsync();
        }
    }
}
