using Bombando.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bombando.DAO
{
    public class UsuarioDAO
    {
        private Contexto contexto { get; set; }

        public UsuarioDAO(Contexto contexto)
        {
            this.contexto = contexto;
        }
        public void Adiciona(Usuario usuario)
        {
            contexto.Usuarios.Add(usuario);
            contexto.SaveChanges();

        }
        public IList<Usuario> ListarTodos()
        {
            return contexto.Usuarios.ToList();
        }

        
    }
}