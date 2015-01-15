using Europa.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Europa.Web.Ui.Adm.Models
{
    public class ProdutosViewModel
    {

        public IEnumerable<Europa.Dao.Produto> Produtos { get; set; }

        public Paginacao Paginacao { get; set; }

        public string CategoriaAtual { get; set; }
    }
}