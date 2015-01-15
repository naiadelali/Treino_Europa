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
using Europa.Web.Ui.Adm.Models;
using System.IO;

namespace Europa.Web.Ui.Adm.Controllers
{
    [AutorizacaoFilter]
    public class ProdutosController : Controller
    {
        private MarcaBusiness marcaBusiness = new MarcaBusiness();
        private ProdutoBusiness produtoBusiness = new ProdutoBusiness();
        private MontadoraBusiness montadoraBusiness = new MontadoraBusiness();
        private CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        public int ProdutosPorPagina = 3;
        // GET: Produtos
        public ActionResult Index()
        {
            ViewBag.ListaCategoria = categoriaBusiness.SelecionarTudo.OrderBy(m => m.Nome).ToList().Where(m => m.Status);
            ViewBag.ListaMontadora = montadoraBusiness.SelecionarTudo.OrderBy(m => m.Nome).ToList();
            var produto = produtoBusiness.SelecionarTudo.ToList();
            return View(produto);
        }

        [HttpPost]
        public ActionResult Index(string nomeProduto, int? ddlMontadora, int? ddlMarca, int? ddlCategoria)
        {
            string Nome = nomeProduto;
            ViewBag.ListaCategoria = categoriaBusiness.SelecionarTudo.OrderBy(m => m.Nome).ToList().Where(m => m.Status);
            ViewBag.ListaMontadora = montadoraBusiness.SelecionarTudo.OrderBy(m => m.Nome).ToList();

            var listaMarca = marcaBusiness.SelecionarTudo.ToList().Select(m => m.IdMontadora == ddlMontadora);
            var produtoRetorno = produtoBusiness.SelecionarTudo.ToList().Where(m => m.Nome == null || m.Nome.IndexOf(Nome, StringComparison.OrdinalIgnoreCase) != -1)
                    .OrderBy(m => m.Nome);

            if (ddlMarca == null)
                produtoRetorno.Select(m => m.Marca.Where(mo => mo.IdMontadora != null || mo.IdMontadora == ddlMontadora));
            else
                produtoRetorno.Select(m => m.Marca.Where(mo => mo.IdMarca != null || mo.IdMarca == ddlMarca));

            produtoRetorno.Select(m => m.IdCategoria == null || m.IdCategoria == ddlCategoria);
            if (produtoRetorno.Count() < 0)
            {
                RedirectToAction("Index");
            }
            return View(produtoRetorno);
        }

       

        public JsonResult PegaMarcas(int id)
        {


            IEnumerable<Marca> marca = marcaBusiness.SelecionarTudo.ToList().Where(m => m.IdMontadora == id);

            List<SelectListItem> states = new List<SelectListItem>();

            foreach (var item in marca)
            {
                states.Add(new SelectListItem { Text = item.Nome, Value = item.IdMarca.ToString() });
            }
            return Json(new SelectList(states, "Value", "Text"));
        }


        public ViewResult AlterarImagem(int id)
        {
            Produto produto = produtoBusiness.SelecionarPorId(id);
            ProdutosImagemViewModel model = new ProdutosImagemViewModel
            {
                logo = produto.Logo,
                IdProduto = produto.IdProduto,
                Nome = produto.IdProduto.ToString()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AlterarImagem(MontadoraImagemViewModel model)
        {
            Produto produto = produtoBusiness.SelecionarPorId(Convert.ToInt32(model.Nome));

            int id = Convert.ToInt32(model.Nome);
            if (!string.IsNullOrEmpty(model.Foto.FileName))
            {
                string extensao = Path.GetExtension(model.Foto.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/images/Produtos/"), model.Nome + extensao);
                model.Foto.SaveAs(path);

                produto.Logo = model.Nome + extensao;
                //Salva o cracha em algum lugar e retorna para a página inicial
                produtoBusiness.Editar(produto);

            }
            return RedirectToAction("AlterarImagem", "Produtos", new { id = id });
        }


        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produto produto = produtoBusiness.SelecionarPorId(id);
            var produtos = produtoBusiness.SelecionarTudo;
            IEnumerable<string> listaMarca = marcaBusiness.SelecionarTudo.Where(m => m.Produto == produtos.Select(p => p.IdProduto == id)).Select(m => m.Nome);
            ViewBag.ListaMarca = listaMarca;
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.ListaMontadora = montadoraBusiness.SelecionarTudo.OrderBy(m => m.Nome).ToList();
            ViewBag.ListaCategoria = categoriaBusiness.SelecionarTudo.OrderBy(m => m.Nome).ToList().Where(m => m.Status);
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProduto,Nome,Descricao,Logo,IdCategoria,Status")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ListaCategoria = categoriaBusiness.SelecionarTudo.OrderBy(m => m.Nome).ToList().Where(m => m.Status);
                Marca marca = marcaBusiness.SelecionarPorId(6);
                produto.Status = true;
                produto.DataCad = DateTime.Now;

                produto.DataUltimaAtualizacao = DateTime.Now;
                produtoBusiness.Criar(produto);

                int idProduto = produto.IdProduto;

                //using (var context = new EuropaEntities())
                //{

                //    string name = "marcaProduo";
                //    long id = 10001;
                //    var sql = "INSERT INTO [dbo].[MarcaProduto] ([IdMarca], [IdProduto]) VALUES (" + marca.IdMarca + ", " + idProduto + ")";
                //    context.Database.ExecuteSqlCommand(sql, name, id);
                //}
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.ListaMontadora = montadoraBusiness.SelecionarTudo.OrderBy(m => m.Nome).ToList();
            ViewBag.ListaCategoria = categoriaBusiness.SelecionarTudo.OrderBy(m => m.Nome).ToList().Where(m => m.Status);
            Produto produto = produtoBusiness.SelecionarPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProduto,Nome,Descricao,Logo,IdCategoria,Status,DataCad")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ListaCategoria = categoriaBusiness.SelecionarTudo.OrderBy(m => m.Nome).ToList().Where(m => m.Status);
                Marca marca = marcaBusiness.SelecionarPorId(8);
                produto.Status = true;

                produto.DataUltimaAtualizacao = DateTime.Now;
                produtoBusiness.Editar(produto);

                int idProduto = produto.IdProduto;

                //using (var context = new EuropaEntities())
                //{

                //    string name = "DeletaMarcaProduo";
                //    long id = 10001;
                //    var sql = "DELETE FROM [dbo].[MarcaProduto] WHERE [IdProduto] = " + idProduto;
                //    context.Database.ExecuteSqlCommand(sql, name, id);
                //}

                //using (var context = new EuropaEntities())
                //{

                //    string name = "marcaProduo";
                //    long id = 10001;
                //    var sql = "INSERT INTO [dbo].[MarcaProduto] ([IdMarca], [IdProduto]) VALUES (" + marca.IdMarca + ", " + idProduto + ")";
                //    context.Database.ExecuteSqlCommand(sql, name, id);
                //}

                return RedirectToAction("SelecionaMarca", new { id = idProduto });
            }
            return View(produto);
        }

        // GET: Produtos/SelecionaMarca/5

        public ActionResult SelecionaMarca(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.IdMarca = marcaBusiness.SelecionarTudo.OrderBy(obj=>obj.Nome);
            ViewBag.IdMontadora = montadoraBusiness.SelecionarTudo.OrderBy(m => m.Nome).ToList();
            

            Produto produto = produtoBusiness.SelecionarPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            Produto produto = produtoBusiness.SelecionarPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = produtoBusiness.SelecionarPorId(id);
            produtoBusiness.Deletar(produto);
            return RedirectToAction("Index");
        }

    }
}
