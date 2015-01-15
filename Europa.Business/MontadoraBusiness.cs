using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Europa.Repositorio;
using Europa.Dao;

namespace Europa.Business
{
    public class MontadoraBusiness
    {
        private MontadoraRepositorio _repository = new MontadoraRepositorio();

        public IEnumerable<Montadora> SelecionarTudo
        {
            get { return _repository.SelecionarTudo; }
        }

        public Montadora SelecionarPorId(int? id)
        {
            return _repository.SelecionarPorId(id);
        }

        public void Criar(Montadora montadora)
        {
            _repository.Criar(montadora);
        }

        public void Editar(Montadora montadora)
        {
            _repository.Editar(montadora);
        }

        public void Deletar(Montadora montadora)
        {
            _repository.Deletar(montadora);
        }
    }
}
