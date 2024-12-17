using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaGestionConstructora.Data;
using SistemaGestionConstructora.Models;
using System.Threading.Tasks;

namespace SistemaGestionConstructora.Controllers
{
    public class AsignacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsignacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Asignaciones
        public async Task<IActionResult> Index()
        {
            var asignaciones = _context.Asignaciones.Include(a => a.Empleado).Include(a => a.Proyecto);
            return View(await asignaciones.ToListAsync());
        }

        // GET: Asignaciones/Create
        public IActionResult Create()
        {
            ViewData["IDEmpleado"] = new SelectList(_context.Empleados, "IDEmpleado", "NombreCompleto");
            ViewData["IDProyecto"] = new SelectList(_context.Proyectos, "IDProyecto", "NombreDescriptivo");
            return View();
        }

        // POST: Asignaciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDAsignacion,IDEmpleado,IDProyecto,FechaAsignacion")] Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDEmpleado"] = new SelectList(_context.Empleados, "IDEmpleado", "NombreCompleto", asignacion.IDEmpleado);
            ViewData["IDProyecto"] = new SelectList(_context.Proyectos, "IDProyecto", "NombreDescriptivo", asignacion.IDProyecto);
            return View(asignacion);
        }

        // GET: Asignaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            ViewData["IDEmpleado"] = new SelectList(_context.Empleados, "IDEmpleado", "NombreCompleto", asignacion.IDEmpleado);
            ViewData["IDProyecto"] = new SelectList(_context.Proyectos, "IDProyecto", "NombreDescriptivo", asignacion.IDProyecto);
            return View(asignacion);
        }

        // POST: Asignaciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDAsignacion,IDEmpleado,IDProyecto,FechaAsignacion")] Asignacion asignacion)
        {
            if (id != asignacion.IDAsignacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionExists(asignacion.IDAsignacion))
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
            ViewData["IDEmpleado"] = new SelectList(_context.Empleados, "IDEmpleado", "NombreCompleto", asignacion.IDEmpleado);
            ViewData["IDProyecto"] = new SelectList(_context.Proyectos, "IDProyecto", "NombreDescriptivo", asignacion.IDProyecto);
            return View(asignacion);
        }

        // GET: Asignaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                .Include(a => a.Empleado)
                .Include(a => a.Proyecto)
                .FirstOrDefaultAsync(m => m.IDAsignacion == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // POST: Asignaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignacion = await _context.Asignaciones.FindAsync(id);
            _context.Asignaciones.Remove(asignacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionExists(int id)
        {
            return _context.Asignaciones.Any(e => e.IDAsignacion == id);
        }
    }
}
