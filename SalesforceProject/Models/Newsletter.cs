using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SalesforceProject.Models
{
    public class Newsletter
    {
        [Key]
        [JsonProperty("Id")]
        public string idNewsletter { get; set; }

        [JsonProperty("Name")]
        [Display(Name = "Nome", Description = "Digite o nome da loja")]
        [Required(ErrorMessage = "Nome obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O campo Nome deve possuir no mínimo 5 e no máximo 100 caracteres")]
        public string Nome { get; set; }

        [JsonProperty("Email__c")]
        [Display(Name = "E-mail", Description = "Digite o seu e-mail")]
        [Required(ErrorMessage = "E-mail obrigatório")]
        [EmailAddress(ErrorMessage = "O campo Nome deve possuir no mínimo 5 e no máximo 100 caracteres")]
        public string Email { get; set; }
    }
}