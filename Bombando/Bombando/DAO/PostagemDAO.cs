using Bombando.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bombando.DAO
{
    public class PostagemDAO
    {
        private Contexto contexto;

        public PostagemDAO(Contexto contexto)
        {
            this.contexto = contexto;
        }
        public void Adiciona(Postagem postagem)
        {
            contexto.Postagens.Add(postagem);
            contexto.SaveChanges();
        }
        public IList<Postagem> ListarTodos()
        {
            return contexto.Postagens.ToList();
        }
    }
}