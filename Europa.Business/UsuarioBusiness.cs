using Europa.Dao;
using Europa.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Europa.Business
{
    public class UsuarioBusiness
    {
        private UsuarioRepositorio _repository = new UsuarioRepositorio();

        public Usuario Busca(string login, string senha)
        {
            return _repository.Busca(login, senha);
        }
    }
}
