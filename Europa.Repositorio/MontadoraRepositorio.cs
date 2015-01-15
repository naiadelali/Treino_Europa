using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Europa.Dao;

namespace Europa.Repositorio
{
    public class MontadoraRepositorio
    {
        private readonly EuropaEntities _Context = new EuropaEntities();

        public IEnumerable<Montadora> SelecionarTudo
        {
            get { return _Context.Montadora.ToList();  }
        }

        public Montadora SelecionarPorId(int? id)
        {
          return _Context.Montadora.Find(id);
        }

        public void Criar(Montadora montadora)
        {
            _Context.Montadora.Add(montadora);
            _Context.SaveChanges();
        }

        public void Editar(Montadora montadora)
        {
            _Context.Entry(montadora).State = System.Data.Entity.EntityState.Modified;
            _Context.SaveChanges();
        }

        public void Deletar(Montadora montadora)
        {
            _Context.Montadora.Remove(montadora);
            _Context.SaveChanges();
        }

       
    }
}
