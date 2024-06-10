using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFisrt_CochesEscuderias.Models;
using CodeFisrt_CochesEscuderias.Services.Repositorio;

namespace CodeFisrt_CochesEscuderias.Controllers
{
    public class CochesController : Controller
    {
        //private readonly ICocheRepositorio _context;
        private readonly IGenericRepositorio<Coche> _context;
        private readonly IGenericRepositorio<Escuderia> _escuderiaContext;

        public CochesController(IGenericRepositorio<Coche> context, IGenericRepositorio<Escuderia> escuderiaContext/*, ICocheRepositorio context*/)
        {
            _context = context;
            _escuderiaContext = escuderiaContext;
            //_repositorio = repositorio;
        }

        // GET: Coches
        public async Task<IActionResult> Index()
        {
            return View( await _context.DameTodos());
        }

        // GET: Coches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coche = await _context.DameTodos();
                //.FirstOrDefaultAsync(m => m.Id == id);
            if (coche == null)
            {
                return NotFound();
            }

            return  Ok(coche);
        }

        // GET: Coches/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["EscuderiaId"] = new SelectList( await _escuderiaContext.DameTodos(), "Id", "Nombre");
            return View();
        }

        // POST: Coches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Motor,Nombre,EscuderiaId")] Coche coche)
        {
            //if (ModelState.IsValid)
            //{
                await _context.Agregar(coche);
                return  RedirectToAction(nameof(Index));
            //}
            //return View(coche);
        }

        // GET: Coches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coche = _context.DameUno((int)id);
            if (coche == null)
            {
                return NotFound();
            }
            return  Ok(coche);
        }

        // POST: Coches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Motor,Nombre,EscuderiaId")] Coche coche)
        {
            if (id != coche.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
                   await _context.Modificar(id, coche);
                    
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!CocheExists(coche.Id))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                return RedirectToAction(nameof(Index));
            //}
            //return View(coche);
        }

        // GET: Coches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coche = await _context.DameTodos();
                //.FirstOrDefault(m => m.Id == id);
            if (coche == null)
            {
                return NotFound();
            }

            return Ok(coche);
        }

        // POST: Coches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coche = await _context.DameUno((int)id);
            if (coche != null)
            {
                await _context.Borrar(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CocheExists(int id)
        {
            var elemento = await _context.DameTodos();
            return elemento.Any(e => e.Id == id);
        }
    }
}
