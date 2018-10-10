using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace SalesforceProject.Models
{
    public class Loja
    {
        [Key]
        [JsonProperty("Id")]
        public string IdLoja { get; set; }

        [JsonProperty("Name")]
        [Display(Name = "Nome", Description = "Digite o nome da loja")]
        [Required(ErrorMessage = "Nome obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O campo Nome deve possuir no mínimo 5 e no máximo 100 caracteres")]
        public string Nome { get; set; }

        [JsonProperty("cep__c")]
        [Display(Name = "CEP", Description = "Digite o cep da loja")]
        [Required(ErrorMessage = "CEP obrigatório")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "O campo Cep deve possuir no mínimo 5 e no máximo 100 caracteres")]
        public string Cep { get; set; }

        [JsonProperty("endereco__c")]
        [Display(Name = "Endereço", Description = "Digite o endereço da loja")]
        [Required(ErrorMessage = "Endereço obrigatório")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O campo Endereço deve possuir no mínimo 10 e no máximo 100 caracteres")]
        public string Endereco { get; set; }

        [JsonProperty("numeroLoja__c")]
        [Display(Name = "Número", Description = "Digite o endereço da loja")]
        [Required(ErrorMessage = "Número obrigatório")]
        public double Numero { get; set; }

        [JsonProperty("complemento__c")]
        [Display(Name = "Complemento", Description = "Digite o complemento da loja")]
        public string Complemento { get; set; }

        [JsonProperty("cidade__c")]
        [Display(Name = "Cidade", Description = "Digite a cidade")]
        [Required(ErrorMessage = "Endereço obrigatório")]
        public string Cidade { get; set; }


        [JsonProperty("estado__c")]
        [Display(Name = "Estado", Description = "Selecione o estado")]
        [Required(ErrorMessage = "Estado obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo Estado deve possuir no mínimo 2 caracteres")]
        public string Estado { get; set; }
    }
}