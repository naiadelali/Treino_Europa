using Europa.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Europa.Web.Ui.Controllers
{
    public class ProdutosController : Controller
    {
        private EuropaEntities db = new EuropaEntities();
        // GET: Produtos
        public ActionResult Index()
        {
            var produto = db.Produto;
            return View(produto.ToList());
        }
    }
}