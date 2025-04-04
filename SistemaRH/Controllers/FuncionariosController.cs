using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaRH.Data;
using SistemaRH.Models;

namespace SistemaRH.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly AppDBContext _context;

        public FuncionariosController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Funcionario.Include(f => f.Departamento).Include(f => f.Empresa);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .Include(f => f.Departamento)
                .Include(f => f.Empresa)
                .Include(f => f.Tarefa)
                .FirstOrDefaultAsync(m => m.FuncionarioID == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            ViewBag.Departamentos = new SelectList(_context.Departamento, "DepartamentoID", "Name");
            ViewBag.Empresas = new SelectList(_context.Empresa, "EmpresaID", "Nome");
            //ViewBag.Tarefas = new SelectList(_context.Tarefa, "TarefaID", "Nome");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncionarioID,Nome,Cpf,DepartamentoID,EmpresaID")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoID"] = new SelectList(_context.Set<Departamento>(), "DepartamentoID", "DepartamentoID", funcionario.DepartamentoID);
            ViewData["EmpresaID"] = new SelectList(_context.Set<Empresa>(), "EmpresaID", "Cnpj", funcionario.EmpresaID);
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoID"] = new SelectList(_context.Set<Departamento>(), "DepartamentoID", "DepartamentoID", funcionario.DepartamentoID);
            ViewData["EmpresaID"] = new SelectList(_context.Set<Empresa>(), "EmpresaID", "Cnpj", funcionario.EmpresaID);
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncionarioID,Nome,Cpf,DepartamentoID,EmpresaID")] Funcionario funcionario)
        {
            if (id != funcionario.FuncionarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.FuncionarioID))
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
            ViewData["DepartamentoID"] = new SelectList(_context.Set<Departamento>(), "DepartamentoID", "DepartamentoID", funcionario.DepartamentoID);
            ViewData["EmpresaID"] = new SelectList(_context.Set<Empresa>(), "EmpresaID", "Cnpj", funcionario.EmpresaID);
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .Include(f => f.Departamento)
                .Include(f => f.Empresa)
                .Include(f => f.Tarefa)
                .FirstOrDefaultAsync(m => m.FuncionarioID == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario != null)
            {
                _context.Funcionario.Remove(funcionario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(e => e.FuncionarioID == id);
        }
    }
}
