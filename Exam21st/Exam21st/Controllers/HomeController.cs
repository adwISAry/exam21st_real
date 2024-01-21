using Exam21st.Areas.Admin.ViewModels;
using Exam21st.Context;
using Exam21st.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Exam21st.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context { get; }
        
        public HomeController(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            var items = await _context.services.ToListAsync();
            return View(items);
        }


      
      
    }
}