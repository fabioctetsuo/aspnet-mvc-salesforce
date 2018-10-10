using System;
using System.Net.Http;

namespace SalesforceProject.Exceptions
{
    public class ServiceExceptions
    {
        public void MappingException(HttpResponseMessage resposta)
        {
            switch (resposta.StatusCode)
            {
                case System.Net.HttpStatusCode.Unauthorized:
                    throw new Exception("Usuário não tem permissões para realizar essa ação.");
                case System.Net.HttpStatusCode.BadRequest:
                    throw new Exception("Dado duplicado ou campo obrigatório faltando");
                case System.Net.HttpStatusCode.InternalServerError:
                    throw new Exception("Sistema indisponível no momento, por favor tente novamente mais tarde.");
                default:
                    throw new Exception("Ocorreu um erro inesperado.");
            }
        }
    }
}