using Europa.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Europa.Repositorio
{
    public class MarcaRepositorio
    {
        private readonly EuropaEntities _Context = new EuropaEntities();

        public IEnumerable<Marca> SelecionarTudo
        {
            get { return _Context.Marca.ToList(); }
        }

        public Marca SelecionarPorId(int? id)
        {
            return _Context.Marca.Find(id);
        }

        public void Criar(Marca marca)
        {
            _Context.Marca.Add(marca);
            _Context.SaveChanges();
        }

        public void Editar(Marca marca)
        {
            _Context.Entry(marca).State = System.Data.Entity.EntityState.Modified;
            _Context.SaveChanges();
        }

        public void Deletar(Marca marca)
        {
            _Context.Marca.Remove(marca);
            _Context.SaveChanges();
        }
    }
}
