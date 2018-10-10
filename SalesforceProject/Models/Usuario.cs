using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesforceProject.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Display(Name = "Nome", Description = "Digite seu nome")]
        public String NomeUsuario { get; set; }

        [Display(Name = "Email", Description = "Digite seu email")]
        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage = "Digite um email valido.")]
        public String EmailUsuario { get; set; }

        [Display(Name = "Senha", Description = "Digite a sua senha")]
        [Required(ErrorMessage = "Senha obrigatório")]
        public String SenhaUsuario { get; set; }
    }
}