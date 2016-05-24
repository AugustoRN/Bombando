using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bombando.Domain
{
    public class Usuario
    {
        
        public int Id { get; set; }


        [Required]
        [StringLength(200)]
        [Index("IX_UNICO", IsUnique = true)] 
        public string Nome{get;set;}


        
        public string Cpf { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}