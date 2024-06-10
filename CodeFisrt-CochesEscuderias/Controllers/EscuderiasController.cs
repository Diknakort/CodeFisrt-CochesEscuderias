﻿using System;
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
    public class EscuderiasController : Controller
    {
        private readonly IGenericRepositorio<Escuderia> _context;

        public EscuderiasController(IGenericRepositorio<Escuderia> context)
        {
            _context = context;
        }

        // GET: Escuderias
        public async Task<IActionResult> Index()
        {
            return View(_context.DameTodos());
        }

        // GET: Escuderias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escuderia =  _context.DameTodos()
                .FirstOrDefault(m => m.Id == id);
            if (escuderia == null)
            {
                return NotFound();
            }

            return View(escuderia);
        }

        // GET: Escuderias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escuderias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Dinero")] Escuderia escuderia)
        {
            //if (ModelState.IsValid)
            //{
                _context.Agregar(escuderia);
                return RedirectToAction(nameof(Index));
            //}
            //return View(escuderia);
        }

        // GET: Escuderias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escuderia = _context.DameUno((int)id);
            if (escuderia == null)
            {
                return NotFound();
            }
            return View(escuderia);
        }

        // POST: Escuderias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Dinero")] Escuderia escuderia)
        {
            if (id != escuderia.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
                    _context.Modificar(id, escuderia);
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!EscuderiaExists(escuderia.Id))
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
            //return View(escuderia);
        }

        // GET: Escuderias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escuderia =  _context.DameTodos()
                .FirstOrDefault(m => m.Id == id);
            if (escuderia == null)
            {
                return NotFound();
            }

            return View(escuderia);
        }

        // POST: Escuderias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escuderia =  _context.DameUno((int)id);
            if (escuderia != null)
            {
                _context.Borrar(id);
            }

           
            return RedirectToAction(nameof(Index));
        }

        private bool EscuderiaExists(int id)
        {
            return _context.DameTodos().Any(e => e.Id == id);
        }
    }
}
