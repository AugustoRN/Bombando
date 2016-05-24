using Bombando.DAO;
using Bombando.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bombando.Controllers
{
    public class PostagemController : Controller
    {
        private PostagemDAO postagemDAO;
        private UsuarioDAO usuarioDAO;
        public PostagemController(PostagemDAO postagemDAO, UsuarioDAO usuarioDAO)
        {
            this.postagemDAO = postagemDAO;
            this.usuarioDAO = usuarioDAO;
        }
        [Authorize]
        public ActionResult Form()
        {
            ViewBag.Usuarios = usuarioDAO.ListarTodos();
            return View();
        }

        public ActionResult Adiciona(Postagem postagem)
        {
            if (ModelState.IsValid)
            {
                postagemDAO.Adiciona(postagem);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Usuarios = usuarioDAO.ListarTodos();
                return View("Form", postagem);
            }
        }
        public ActionResult Index()
        {
            IList<Postagem> postagens = postagemDAO.ListarTodos();
            return View(postagens);
        }

  
    }
}