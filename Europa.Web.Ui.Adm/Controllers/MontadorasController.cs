using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Europa.Dao;
using Europa.Business;
using Europa.Web.Ui.Adm.Controllers.Filtros;
using System.IO;
using Europa.Web.Ui.Adm.Models;

namespace Europa.Web.Ui.Adm.Controllers
{
    [AutorizacaoFilter]
    public class MontadorasController : Controller
    {
        
        private MontadoraBusiness montadoraBusiness = new MontadoraBusiness();

        // GET: Montadoras
        public ActionResult Index()
        {
             
            var montadora = montadoraBusiness.SelecionarTudo.ToList();

            return View(montadora);
        }

        [HttpPost]
        public ActionResult Index(string nomeMontadora)
        {
            string Nome = nomeMontadora;

            var montadoraRetorno = montadoraBusiness.SelecionarTudo.ToList().Where(m => m.Nome == null || m.Nome.IndexOf(Nome, StringComparison.OrdinalIgnoreCase) != -1)
                    .OrderBy(m=> m.Descricao);

            if (montadoraRetorno.Count()<0)
            {
                RedirectToAction("Index");
            }
            return View(montadoraRetorno);
        }

        // GET: Montadoras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Montadora montadora = montadoraBusiness.SelecionarPorId(id);
            if (montadora == null)
            {
                return HttpNotFound();
            }
            return View(montadora);
        }

        // GET: Montadoras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Montadoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMontadora,Nome,Descricao,Logo")] Montadora montadora)
        {
            if (ModelState.IsValid)
            {
                montadoraBusiness.Criar(montadora);
                return RedirectToAction("Index");
            }

            return View(montadora);
        }

        // GET: Montadoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Montadora montadora = montadoraBusiness.SelecionarPorId(id);
            if (montadora == null)
            {
                return HttpNotFound();
            }
            return View(montadora);
        }

        public ViewResult AlterarImagem(int id)
        {
            Montadora montadora = montadoraBusiness.SelecionarPorId(id);
            MontadoraImagemViewModel model = new MontadoraImagemViewModel
            {
                logo=montadora.Logo,
                IdMontadora = montadora.IdMontadora,
                Nome = montadora.IdMontadora.ToString()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AlterarImagem(MontadoraImagemViewModel model)
        {
            Montadora montadora = montadoraBusiness.SelecionarPorId(Convert.ToInt32(model.Nome));

            int id =Convert.ToInt32(model.Nome);
            if (!string.IsNullOrEmpty(model.Foto.FileName))
            {
                string extensao = Path.GetExtension(model.Foto.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/images/Montadoras/"), model.Nome + extensao);
                model.Foto.SaveAs(path);

                montadora.Logo = model.Nome + extensao;
                //Salva o cracha em algum lugar e retorna para a página inicial
                montadoraBusiness.Editar(montadora);
               
            }
            return RedirectToAction("AlterarImagem", "Montadoras", new { id = id });
        }
        // POST: Montadoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMontadora,Nome,Descricao,Logo")] Montadora montadora)
        {
            if (ModelState.IsValid)
            {
                montadoraBusiness.Editar(montadora);
                return RedirectToAction("Index");
            }
            return View(montadora);
        }

        // GET: Montadoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Montadora montadora = montadoraBusiness.SelecionarPorId(id);
            if (montadora == null)
            {
                return HttpNotFound();
            }
            return View(montadora);
        }

        // POST: Montadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Montadora montadora = montadoraBusiness.SelecionarPorId(id);
            montadoraBusiness.Deletar(montadora);
            return RedirectToAction("Index");
        }

       
    }
}
