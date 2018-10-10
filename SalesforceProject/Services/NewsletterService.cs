using System;
using System.Net.Http;
using System.Text;
using SalesforceProject.Models;
using SalesforceProject.Exceptions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
using System.Collections.Specialized;

namespace SalesforceProject.Services
{
    public class NewsletterService : AuthenticationSalesforce
    {
        public IList<Newsletter> GetNewsletters()
        {
            var _url = "https://na59.salesforce.com/services/apexrest/v1/Newsletters/";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetToken());
            HttpResponseMessage response = client.GetAsync(_url).Result;
            if (!response.IsSuccessStatusCode) new ServiceExceptions().MappingException(response);
            string conteudoResposta = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<IList<Newsletter>>(conteudoResposta);
        }

        public Newsletter GetContatoById(string id)
        {
            var _url = "https://na59.salesforce.com/services/data/v20.0/sobjects/Newsletter__c/" + id;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetToken());
            HttpResponseMessage response = client.GetAsync(_url).Result;
            if (!response.IsSuccessStatusCode) new ServiceExceptions().MappingException(response);
            string conteudoResposta = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Newsletter>(conteudoResposta);
        }

        public void CadastrarNewsletter(Newsletter _newsletter)
        {
            string uri = "https://na59.salesforce.com/services/data/v20.0/sobjects/Newsletter__c";
            string conteudoJson = Newtonsoft.Json.JsonConvert.SerializeObject(_newsletter);
            StringContent conteudoJsonString = new StringContent(conteudoJson, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetToken());
            HttpResponseMessage resposta = client.PostAsync(uri, conteudoJsonString).Result;
            if (!resposta.IsSuccessStatusCode) new ServiceExceptions().MappingException(resposta);
        }

        public void ExcluirContato(string id)
        {
            var uri = "https://na59.salesforce.com/services/data/v20.0/sobjects/Newsletter__c/" + id;
            System.Net.Http.HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetToken());
            HttpResponseMessage response = client.DeleteAsync(uri).Result;
            if (!response.IsSuccessStatusCode) new ServiceExceptions().MappingException(response);
        }

        public IList<Newsletter> FilterContato(Newsletter _newsletter)
        {
            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            query["Name"] = _newsletter.Nome;
            query["Email__c"] = _newsletter.Email;
            string queryString = query.ToString();

            string _url = "https://na59.salesforce.com/services/apexrest/v1/Newsletters/?" + queryString;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetToken());
            HttpResponseMessage response = client.GetAsync(_url).Result;
            if (!response.IsSuccessStatusCode) new ServiceExceptions().MappingException(response);
            string conteudoResposta = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<IList<Newsletter>>(conteudoResposta);
        }
    }
}