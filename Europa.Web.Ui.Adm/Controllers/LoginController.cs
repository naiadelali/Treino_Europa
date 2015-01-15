using Europa.Business;
using Europa.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Europa.Web.Ui.Adm.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Autentica(string Email, string Senha)
        {
            try
            {


                Usuario usuario = usuarioBusiness.Busca(Email, Senha);

                if (usuario != null)
                {
                    Session["usuarioLogado"] = usuario;
                    return RedirectToAction("Index", "Home");
                }
                else
                    return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index","Login");
            }
        }
    }
}