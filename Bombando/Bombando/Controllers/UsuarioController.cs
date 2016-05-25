using Bombando.DAO;
using Bombando.Domain;
using Bombando.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Bombando.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAO usuarioDAO;

        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult RegistrarUsuario(UsuarioModel model)
        {
            bool usuarioExistente = false;
          
            if (ModelState.IsValid)
            {
                try
                {
                    
                    Usuario usuario = new Usuario
                    {
                        Nome = model.Nome,
                        Email = model.Email,
                        Cpf = model.Cpf,
                        Senha = model.Senha

                    };
                    foreach(Usuario u in usuarioDAO.ListarTodos()){
                        if (u.Nome.Equals(usuario.Nome))
                        {
                            usuarioExistente = true;
                        }
                    }
                    if (!usuarioExistente)
                    {
                        usuarioDAO.Adiciona(usuario);
                        WebSecurity.CreateAccount(model.Nome, model.Senha);
                    }

                  
                    return RedirectToAction("Index");
                }
                catch (MemberAccessException e)
                {
                    ModelState.AddModelError("usuario.Invalido", e.Message);
                    return View("Form", model);
                }
                
            }
            else
            {
                return View("Form", model);
            }
        }
        public ActionResult Index()
        {
            IList<Usuario> usuarios = usuarioDAO.ListarTodos();
            return View(usuarios);
        }
    }
}