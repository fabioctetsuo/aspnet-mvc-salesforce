using System;
using System.Collections.Generic;
using SalesforceProject.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using SalesforceProject.Exceptions;
using System.Web;
using System.Collections.Specialized;

namespace SalesforceProject.Services
{
    public class LojaService : AuthenticationSalesforce
    {
        public IList<Loja> GetLojas()
        {
            var _url = "https://na59.salesforce.com/services/apexrest/v1/Lojas/";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetToken());
            HttpResponseMessage response = client.GetAsync(_url).Result;
            if (!response.IsSuccessStatusCode) new ServiceExceptions().MappingException(response);
            string conteudoResposta = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<IList<Loja>>(conteudoResposta);
        }

        public Loja GetLojaById(string id)
        {
            var _url = "https://na59.salesforce.com/services/data/v20.0/sobjects/Loja__c/" + id;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetToken());
            HttpResponseMessage response = client.GetAsync(_url).Result;
            if (!response.IsSuccessStatusCode) new ServiceExceptions().MappingException(response);
            string conteudoResposta = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Loja>(conteudoResposta);
        }

        public IList<Loja> FilterLojas(Loja _loja)
        {
            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            query["endereco__c"] = _loja.Endereco;
            query["cidade__c"] = _loja.Cidade;
            query["estado__c"] = _loja.Estado;
            string queryString = query.ToString();

            string _url = "https://na59.salesforce.com/services/apexrest/v1/Lojas/?" + queryString;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetToken());
            HttpResponseMessage response = client.GetAsync(_url).Result;
            if (!response.IsSuccessStatusCode) new ServiceExceptions().MappingException(response);
            string conteudoResposta = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<IList<Loja>>(conteudoResposta);
        }

        public void InserirLoja(Loja _loja)
        {
            string url = "https://na59.salesforce.com/services/data/v20.0/sobjects/Loja__c/";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetToken());
            string conteudoJson = Newtonsoft.Json.JsonConvert.SerializeObject(_loja);
            StringContent conteudoJsonString = new StringContent(conteudoJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, conteudoJsonString).Result;
            if (!response.IsSuccessStatusCode) new ServiceExceptions().MappingException(response);
        }

        public void EditarLoja(Loja _loja)
        {
            var uri = "https://na59.salesforce.com/services/data/v20.0/sobjects/Loja__c/" + _loja.IdLoja;
            _loja.IdLoja = null; // PATCH nao permite o ID no payload
            var conteudoJson = Newtonsoft.Json.JsonConvert.SerializeObject(_loja);
            System.Net.Http.HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetToken());
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, uri) {
                Content = new StringContent(conteudoJson, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.SendAsync(request).Result;
            if (!response.IsSuccessStatusCode) new ServiceExceptions().MappingException(response);
        }

        public void ExcluirLoja(string id)
        {
            var uri = "https://na59.salesforce.com/services/data/v20.0/sobjects/Loja__c/" + id;
            System.Net.Http.HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetToken());
            HttpResponseMessage response = client.DeleteAsync(uri).Result;
            if (!response.IsSuccessStatusCode) new ServiceExceptions().MappingException(response);
        }
    }
}