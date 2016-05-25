using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bombando.Models
{
    public class UsuarioModel
    {
      
        [Required]
        [StringLength(200)]
        [Index("IX_UNICO", IsUnique = true)]
        public string Nome { get; set; }



        public string Cpf { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Compare("Senha")]
        public string ConfimacaoSenha { get; set; }
        [Compare("Nome")]
        public string ConfirmarNome { get; set; }
    }
}