using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarrosWebApp.Data;
using CarrosWebApp.Models;
using System.Threading.Tasks;

namespace CarrosWebApp.Controllers
{
    public class ModelosCarrosController : Controller
    {
        private readonly CarrosContext _context;

        public ModelosCarrosController(CarrosContext context)
        {
            _context = context;
        }

        // GET: ModelosCarros
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModelosCarros.ToListAsync());
        }

        // GET: ModelosCarros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var modeloCarro = await _context.ModelosCarros.FirstOrDefaultAsync(m => m.Id == id);
            if (modeloCarro == null) return NotFound();

            return View(modeloCarro);
        }

        // GET: ModelosCarros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModelosCarros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Ano")] ModeloCarro modeloCarro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modeloCarro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modeloCarro);
        }

        // GET: ModelosCarros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var modeloCarro = await _context.ModelosCarros.FindAsync(id);
            if (modeloCarro == null) return NotFound();

            return View(modeloCarro);
        }

        // POST: ModelosCarros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Ano")] ModeloCarro modeloCarro)
        {
            if (id != modeloCarro.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modeloCarro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloCarroExists(modeloCarro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(modeloCarro);
        }

        // GET: ModelosCarros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var modeloCarro = await _context.ModelosCarros.FirstOrDefaultAsync(m => m.Id == id);
            if (modeloCarro == null) return NotFound();

            return View(modeloCarro);
        }

        // POST: ModelosCarros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modeloCarro = await _context.ModelosCarros.FindAsync(id);
            _context.ModelosCarros.Remove(modeloCarro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloCarroExists(int id)
        {
            return _context.ModelosCarros.Any(e => e.Id == id);
        }
    }
}
