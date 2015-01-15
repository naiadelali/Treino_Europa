using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Europa.Dao;
using Europa.Web.Ui.Adm.Controllers.Filtros;

namespace Europa.Web.Ui.Adm.Controllers
{
    [AutorizacaoFilter]
    public class UsuariosController : Controller
    {
        public PartialViewResult Menu()
        {

            string usuario = ((Usuario)Session["usuarioLogado"]).Nome;

            return PartialView("Menu",usuario);

        }
    }
}