using Europa.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Europa.Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly EuropaEntities _Context = new EuropaEntities();


        public Usuario Busca(string login, string senha)
        {
            using (var contexto = new EuropaEntities())
            {
                return contexto.Usuario.FirstOrDefault(u => u.Email == login && u.Senha == senha);
            }
        }
    }
}
