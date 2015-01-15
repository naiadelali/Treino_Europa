using Europa.Dao;
using Europa.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Europa.Business
{
    public class MarcaBusiness
    {
        private MarcaRepositorio _repository = new MarcaRepositorio();

        public IEnumerable<Marca> SelecionarTudo
        {
            get { return _repository.SelecionarTudo; }
        }

        public Marca SelecionarPorId(int? id)
        {
            return _repository.SelecionarPorId(id);
        }

        public void Criar(Marca marca)
        {
            _repository.Criar(marca);
        }

        public void Editar(Marca marca)
        {
            _repository.Editar(marca);
        }

        public void Deletar(Marca marca)
        {
            _repository.Deletar(marca);
        }
    }
}
