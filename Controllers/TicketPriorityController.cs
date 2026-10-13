using Microsoft.AspNetCore.Mvc;
using UserRoles.Data;
using UserRoles.Models;

namespace UserRoles.Controllers
{
    public class TicketPriorityController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public TicketPriorityController(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<TicketPriority> TicketPriorityList = _appDbContext.TicketPriorities.ToList();
            return View(TicketPriorityList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketPriority ticketPriority)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.TicketPriorities.Add(ticketPriority);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(ticketPriority);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ticketPriority = _appDbContext.TicketPriorities.Find(id);
            if (ticketPriority == null)
            {
                return NotFound();
            }
            return View(ticketPriority);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TicketPriority ticketPriority)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.TicketPriorities.Update(ticketPriority);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticketPriority);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var ticketPriority = _appDbContext.TicketPriorities.Find(id);
            if (ticketPriority == null)
            {
                return NotFound();
            }

            _appDbContext.TicketPriorities.Remove(ticketPriority);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
