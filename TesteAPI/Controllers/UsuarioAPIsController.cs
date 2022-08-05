using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteAPI.DAL;
using TesteAPI.MLL;

namespace TesteAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    //[ApiVersion("1")]
    public class UsuarioAPIsController : ControllerBase
    {
        public UsuarioAPIsController()
        {         
            
        }

        // GET: UsuarioAPIs
        //[HttpGet]
        //public async Task<ActionResult<IList<MLL.Aluno>>> Pesquisar()
        //{ 
            
        //}

        //// GET: UsuarioAPIs/Details/5
        //public async Task<ActionResult<MLL.UsuarioAPI>> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var usuarioAPI = await _context.Usuarios
        //        .FirstOrDefaultAsync(m => m.Codigo == id);
        //    if (usuarioAPI == null)
        //    {
        //        return NotFound();
        //    }

        //    return usuarioAPI;
        //}

        ////// GET: UsuarioAPIs/Create
        ////public IActionResult Create()
        ////{
        ////    return View();
        ////}

        //// POST: UsuarioAPIs/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult<MLL.UsuarioAPI>> Create([Bind("Codigo,Nome,Senha,Email")] UsuarioAPI usuarioAPI)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(usuarioAPI);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return usuarioAPI;
        //}

        //// GET: UsuarioAPIs/Edit/5
        //public async Task<ActionResult<MLL.UsuarioAPI>> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var usuarioAPI = await _context.Usuarios.FindAsync(id);
        //    if (usuarioAPI == null)
        //    {
        //        return NotFound();
        //    }
        //    return usuarioAPI;
        //}

        //// POST: UsuarioAPIs/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult<MLL.UsuarioAPI>> Edit(int id, [Bind("Codigo,Nome,Senha,Email")] UsuarioAPI usuarioAPI)
        //{
        //    if (id != usuarioAPI.Codigo)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(usuarioAPI);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UsuarioAPIExists(usuarioAPI.Codigo))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return usuarioAPI;
        //}

        //// GET: UsuarioAPIs/Delete/5
        //public async Task<ActionResult<MLL.UsuarioAPI>> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var usuarioAPI = await _context.Usuarios
        //        .FirstOrDefaultAsync(m => m.Codigo == id);
        //    if (usuarioAPI == null)
        //    {
        //        return NotFound();
        //    }

        //    return usuarioAPI;
        //}

        //// POST: UsuarioAPIs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var usuarioAPI = await _context.Usuarios.FindAsync(id);
        //    _context.Usuarios.Remove(usuarioAPI);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UsuarioAPIExists(int id)
        //{
        //    return _context.Usuarios.Any(e => e.Codigo == id);
        //}
    }
}
