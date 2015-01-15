using Europa.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Europa.Repositorio
{
    public class ProdutoRepositorio
    {
        private readonly EuropaEntities _Context = new EuropaEntities();

        public IEnumerable<Produto> SelecionarTudo
        {
            get { return _Context.Produto.ToList(); }
        }

        public Produto SelecionarPorId(int? id)
        {
            return _Context.Produto.Find(id);
        }

        public void Criar(Produto produto)
        {
            _Context.Produto.Add(produto);
            _Context.SaveChanges();
        }

        public void Editar(Produto produto)
        {
            _Context.Entry(produto).State = System.Data.Entity.EntityState.Modified;
            _Context.SaveChanges();
        }

        public void Deletar(Produto produto)
        {
            _Context.Produto.Remove(produto);
            _Context.SaveChanges();
        }
    }
}
