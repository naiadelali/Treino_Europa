using Europa.Business;
using Europa.Web.Ui.Adm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Europa.Web.Ui.Adm.Controllers
{
    public class ProdutoController : Controller
    {
        private MarcaBusiness marcaBusiness = new MarcaBusiness();
        private ProdutoBusiness produtoBusiness = new ProdutoBusiness();
        private MontadoraBusiness montadoraBusiness = new MontadoraBusiness();
        private CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        public int ProdutosPorPagina = 3;
        // GET: Produto
        public ActionResult Index(int pagina = 1)
        {
            ProdutosViewModel model = new ProdutosViewModel
            {

                Produtos = produtoBusiness.SelecionarTudo
                    .OrderBy(p => p.Descricao)
                    .Skip((pagina - 1) * ProdutosPorPagina)
                    .Take(ProdutosPorPagina),



                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutosPorPagina,
                    ItensTotal = produtoBusiness.SelecionarTudo.Count()
                },


            };


            return View(model);
        }
    }
}