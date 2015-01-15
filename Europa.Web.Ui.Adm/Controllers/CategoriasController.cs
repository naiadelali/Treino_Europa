using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Europa.Dao;
using Europa.Web.Ui.Adm.Controllers.Filtros;
using Europa.Business;

namespace Europa.Web.Ui.Adm.Controllers
{
    [AutorizacaoFilter]
    public class CategoriasController : Controller
    {
        
        private CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        // GET: Categorias
        public ActionResult Index()
        {
            var categoria = categoriaBusiness.SelecionarTudo.ToList();
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Index(string nomeCategoria)
        {
            string Nome = nomeCategoria;

            var categoriaRetorno = categoriaBusiness.SelecionarTudo.ToList().Where(m => m.Nome == null || m.Nome.IndexOf(Nome, StringComparison.OrdinalIgnoreCase) != -1)
                    .OrderBy(m => m.Nome);

            if (categoriaRetorno.Count() < 0)
            {
                RedirectToAction("Index");
            }
            return View(categoriaRetorno);
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaBusiness.SelecionarPorId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCategoria,Status,Nome")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.Status = true;
                categoriaBusiness.Criar(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaBusiness.SelecionarPorId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCategoria,Status,Nome")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoriaBusiness.Editar(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaBusiness.SelecionarPorId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categoria categoria = categoriaBusiness.SelecionarPorId(id);
            categoriaBusiness.Deletar(categoria);
            return RedirectToAction("Index");
        }

    }
}
