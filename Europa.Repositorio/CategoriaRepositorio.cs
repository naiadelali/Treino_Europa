using Europa.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Europa.Repositorio
{
    public class CategoriaRepositorio
    {
        private readonly EuropaEntities _Context = new EuropaEntities();

        public IEnumerable<Categoria> SelecionarTudo
        {
            get { return _Context.Categoria.ToList(); }
        }

        public Categoria SelecionarPorId(int? id)
        {
            return _Context.Categoria.Find(id);
        }

        public void Criar(Categoria categoria)
        {
            _Context.Categoria.Add(categoria);
            _Context.SaveChanges();
        }

        public void Editar(Categoria categoria)
        {
            _Context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
            _Context.SaveChanges();
        }

        public void Deletar(Categoria categoria)
        {
            _Context.Categoria.Remove(categoria);
            _Context.SaveChanges();
        }
    }
}
