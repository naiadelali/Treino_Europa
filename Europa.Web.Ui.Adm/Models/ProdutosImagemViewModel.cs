using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Europa.Web.Ui.Adm.Models
{
    public class ProdutosImagemViewModel
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string logo { get; set; }
        public HttpPostedFileBase Foto { get; set; }
    }
}