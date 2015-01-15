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
    public class MarcasController : Controller
    {
        private MarcaBusiness marcaBusiness = new MarcaBusiness();
        private MontadoraBusiness montadoraBusiness = new MontadoraBusiness();
        // GET: Marcas
        public ActionResult Index()
        {

            ViewBag.ListaMontadora = montadoraBusiness.SelecionarTudo.OrderBy(m => m.Nome).ToList();

            var marca = marcaBusiness.SelecionarTudo.ToList();
            return View(marca);
        }

        [HttpPost]
        public ActionResult Index(string nomeMarca, int? ddlMontadora)
        {
            string Nome = nomeMarca;
            ViewBag.ListaMontadora = montadoraBusiness.SelecionarTudo.OrderBy(m => m.Nome).ToList();
            var marcaRetorno = marcaBusiness.SelecionarTudo.ToList().Where(m => m.Nome == null || m.Nome.IndexOf(Nome, StringComparison.OrdinalIgnoreCase) != -1)
                    .OrderBy(m => m.Nome)
                    .Select(m => m.IdMontadora != null || m.IdMontadora == ddlMontadora);
                    

            if (marcaRetorno.Count() < 0)
            {
                RedirectToAction("Index");
            }
            return View(marcaRetorno);
        }

        // GET: Marcas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = marcaBusiness.SelecionarPorId(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        // GET: Marcas/Create
        public ActionResult Create()
        {
            ViewBag.ListaMontadora = montadoraBusiness.SelecionarTudo.OrderBy(m => m.Nome).ToList();
            return View();
        }

        // POST: Marcas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMarca,Nome,Descricao,IdMontadora,Status")] Marca marca)
        {

            if (ModelState.IsValid)
            {
                marca.Status = true;
                marca.DataCad = DateTime.Now;
                marca.DataUltimaAtualizacao = DateTime.Now; 
                marcaBusiness.Criar(marca);
                return RedirectToAction("Index");
            }

            return View(marca);
        }

        // GET: Marcas/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.ListaMontadora = montadoraBusiness.SelecionarTudo.OrderBy(m => m.Nome).ToList();
            Marca marca = marcaBusiness.SelecionarPorId(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        // POST: Marcas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMarca,Nome,Descricao,IdMontadora,Status, DataCad")] Marca marca)
        {
            if (ModelState.IsValid)
            {
                marca.DataUltimaAtualizacao = DateTime.Now;
                marcaBusiness.Editar(marca);
                return RedirectToAction("Index");
            }
            return View(marca);
        }

        // GET: Marcas/Delete/5
        public ActionResult Delete(int? id)
        {

            Marca marca = marcaBusiness.SelecionarPorId(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marca marca = marcaBusiness.SelecionarPorId(id);
            marcaBusiness.Deletar(marca);
            return RedirectToAction("Index");
        }
    }
}
