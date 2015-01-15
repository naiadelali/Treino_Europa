using Europa.Dao;
using Europa.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Europa.Business
{
    public class CategoriaBusiness
    {

        private CategoriaRepositorio _repository = new CategoriaRepositorio();

        public IEnumerable<Categoria> SelecionarTudo
        {
            get { return _repository.SelecionarTudo; }
        }

        public Categoria SelecionarPorId(int? id)
        {
            return _repository.SelecionarPorId(id);
        }

        public void Criar(Categoria categoria)
        {
            _repository.Criar(categoria);
        }

        public void Editar(Categoria categoria)
        {
            _repository.Editar(categoria);
        }

        public void Deletar(Categoria categoria)
        {
            _repository.Deletar(categoria);
        }
    }
}
