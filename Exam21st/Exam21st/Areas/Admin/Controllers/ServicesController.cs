using Exam21st.Areas.Admin.Models;
using Exam21st.Areas.Admin.ViewModels;
using Exam21st.Context;
using Exam21st.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam21st.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ServicesController : Controller
    {
        ApplicationDbContext _context { get; }
        IWebHostEnvironment _environment { get; }
        public ServicesController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }
       
            public async Task<IActionResult> Index()
            {
                var items = await _context.services.Select(s => new ServicesIndexVM
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    ImageUrl = s.ImageUrl
                    
                    
                   
                }).ToListAsync();
                return View(items);
            }
        

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ServicesCreateVM vM)
        {
            if (!ModelState.IsValid)
            {
                return View(vM);
            }
            string uniqueFileName = null;
            if (vM.formFile != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + vM.formFile.FileName;
                using var fs = new FileStream(Path.Combine(uploadsFolder, uniqueFileName), FileMode.Create);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                await vM.formFile.CopyToAsync(fs);
            }
            OurServices services = new()
            {
                Name = vM.Name,
                Description = vM.Description,
                ImageUrl = uniqueFileName

            };
            await _context.services.AddAsync(services);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            
          

        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id <= 0) return BadRequest();
            var service=await _context.services.FirstOrDefaultAsync(s => s.Id == id);

            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ServicesUpdateVM vM)
        {
            if (!ModelState.IsValid)
            {
                return View(vM);
            }
            string uniqueFileName = null;
            if (vM.formFile != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + vM.formFile.FileName;
                using var fs = new FileStream(Path.Combine(uploadsFolder, uniqueFileName), FileMode.Truncate);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                await vM.formFile.CopyToAsync(fs);
            }
            OurServices services = new()
            {
                Name = vM.Name,
                Description = vM.Description,
                ImageUrl = uniqueFileName

            };
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));




        }

        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            var services = await _context.services.FindAsync(id);
            _context.services.Remove(services);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //PAGER tetbiqi tam ede bilmedim
        //public async IActionResult AllServices(int pg = 1)
        //{
        //    List<OurServices> services = _context.services.ToList();
        //    const int pageSize = 9;

        //    if (pg < 1)
        //        pg = 1;

        //    int recsCount = services.Count();
        //    var pager = new Pager(recsCount, pg, pageSize);
        //    int recSkip = (pg - 1) * pageSize;
        //    var data = services.Skip(recSkip).Take(pager.PageSize).ToList();
        //    this.ViewBag.Pager = pager;

        //    return View(data);
        }

    }


