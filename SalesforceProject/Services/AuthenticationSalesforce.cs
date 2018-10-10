using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace SalesforceProject.Services
{
    public class AuthenticationSalesforce
    {
        public string GetToken() {
            var _securityKey = "eNLwDGbTHGrpY9gW2Cn5BqEx"; // Recebido por email
            var _clientSecret = "2123731770950628317";
            var _clientId = "3MVG9zlTNB8o8BA2hEvwZ863A3FZmyxgfelzJjxfLM.q8biMgHHfUQ.08mUuSjpXeRGD2SWfXMuzFK1m8EbSr";
            var _redirectUri = "http://www.fiap.com.br";
            var _grantAcess = "password";
            var _userName = "erickamaroamaro@gmail.com";
            var _password = "Lardocecasa!1" + _securityKey;
            var _urlSalesForceAuth = "https://login.salesforce.com/services/oauth2/token";

            var parameters = new Dictionary<string, string> {
                { "client_id", _clientId },
                { "client_secret", _clientSecret },
                { "redirect_uri" , _redirectUri },
                { "grant_type" , _grantAcess },
                { "username" , _userName },
                { "password" , _password },
            };

            var encodedContent = new FormUrlEncodedContent(parameters);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpClient client = new HttpClient();
            var response = client.PostAsync(_urlSalesForceAuth, encodedContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;
                dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(conteudoResposta);

                return json.access_token;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}