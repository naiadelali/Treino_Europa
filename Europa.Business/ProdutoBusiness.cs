using Europa.Dao;
using Europa.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Europa.Business
{
    public class ProdutoBusiness
    {
        private ProdutoRepositorio _repository = new ProdutoRepositorio();

        public IEnumerable<Produto> SelecionarTudo
        {
            get { return _repository.SelecionarTudo; }
        }

        public Produto SelecionarPorId(int? id)
        {
            return _repository.SelecionarPorId(id);
        }

        public void Criar(Produto produto)
        {
            _repository.Criar(produto);
        }

        public void Editar(Produto produto)
        {
            _repository.Editar(produto);
        }

        public void Deletar(Produto produto)
        {
            _repository.Deletar(produto);
        }
    }
}
